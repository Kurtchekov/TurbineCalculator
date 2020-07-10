using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Turbine_Calculator {
    public partial class TurbineCalculator : Form {
        
        public TurbineCalculator() {
            instance = this;
            InitializeComponent();
            fuelList.SelectedIndex = 0;
            overlay = new Overlay();
            overlay.Abort_Clicked += new EventHandler(Abort);
            toolTip.SetToolTip(runBTN, "Retrieves the optimal turbine configuration for the chosen length");
            toolTip.SetToolTip(runAllBTN, "Retrieves the optimal turbine configuration amongst all lengths up to the chosen number. Can be pretty slow!!!");

            LoadSettings();

            usedList.SetObjects(blades);
            availableList.SetObjects(availableBlades);

            currentBlades = new Blade[maxLength];
            bestBlades = new Blade[maxLength];
            targets = new double[maxLength];
            currentCoefficients = new double[maxLength];
            currentCoefficientsBizarre = new double[maxLength];
            currentEfficiencySum = new double[maxLength];
            rotors = new int[maxLength];
        }

        public static string fileName = "Turbine Calculator.json";

        public static TurbineCalculator instance;

        public static double fuelExpansion;
        public static double rfpermb;
        public static int segments;
        public static double[] targets;

        public static Blade stator = new Blade("stator", .75, 0, true);
        public static Blade steel = new Blade("steel", 1.4, 1, false);
        public static Blade extreme = new Blade("extreme", 1.6, 1.1, false);
        public static Blade SiC = new Blade("SiC", 1.8, 1.2, false);

        public static List<Blade> blades = new List<Blade>();
        public static List<Blade> availableBlades = new List<Blade>();
        public static Blade[] currentBlades;
        public static double[] currentCoefficients;
        public static double[] currentCoefficientsBizarre;
        public static double[] currentEfficiencySum;
        public static int[] rotors;
        public static Blade[] bestBlades;
        public static double bestEfficiency;
        public static double bestExpansion;
        public static double bestPossibleEfficiency;
        public static Stopwatch stopwatch = new Stopwatch();
        public static CancellationTokenSource cancel;
        public static Overlay overlay;
        public static int bestLengthOfAll;
        public static int maxLength = 24;

        private void Abort(object sender, EventArgs e) {
            if (cancel != null) cancel.Cancel();
        }

        public void Setup() {
            segments = (int)lengthInput.Value;
            if (fuelMode.SelectedTab == autoMode) {
                switch (fuelList.SelectedIndex) {
                    case 0: //High Pressure Steam
                    fuelExpansion = 4;
                    rfpermb = 16;
                    break;
                    case 1: //Low Pressure Steam
                    fuelExpansion = 2;
                    rfpermb = 4;
                    break;
                    case 2: //Low Pressure Steam
                    fuelExpansion = 2;
                    rfpermb = 4;
                    break;
                }
            } else {
                fuelExpansion = (int)expansionInput.Value;
                rfpermb = (int)rfpermbInput.Value;
            }
            output.Text = "";
        }

        public bool CheckValidBlades() {
            bool validRotors = false;
            bool validStators = false;
            foreach (Blade blade in blades) {
                if (blade.isStator) validStators = true;
                else validRotors = true;
            }
            if (!validStators) output.Text = "Make sure to have at least one valid stator blade available!";
            if (!validRotors) output.Text = "Make sure to have at least one valid rotor blade available!";
            return validRotors && validStators;
        }

        public void Run(object sender, EventArgs e) {
            if (!CheckValidBlades()) return;
            EnableGUI(false);
            Setup();
            stopwatch.Reset();
            cancel = new CancellationTokenSource();
            Task t = Task.Factory.StartNew(() => Calculate(segments, false), cancel.Token).ContinueWith(task => DisplayResults(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void RunAll(object sender, EventArgs e) {
            if (!CheckValidBlades()) return;
            EnableGUI(false);
            cancel = new CancellationTokenSource();
            CancellationToken cancelToken = cancel.Token;
            Setup();
            stopwatch.Reset();
            Task previousTask = Task.Factory.StartNew(() => Calculate(1, false), cancelToken);
            for (int length = 2; length <= segments; length++) {
                previousTask = previousTask.ContinueWith((task,len) => Calculate((int)len, true), length, cancelToken);
            }

            previousTask.ContinueWith(task => DisplayResults(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void EnableGUI(bool shouldEnable) {
            if (!shouldEnable) {
                if (!Controls.Contains(overlay)) Controls.Add(overlay);
                overlay.BringToFront();
            } else if (Controls.Contains(overlay)) Controls.Remove(overlay);
        }

        public void DisplayResults() {
            if (cancel.IsCancellationRequested) output.Text = "Operation Aborted!";
            else {
                resultsList.ClearObjects();
                if (bestLengthOfAll == 0) {
                    output.Text = "No valid blade configuration found.";
                    EnableGUI(true);
                    return;
                }

                output.Text += "Best combination for fuel expansion " + fuelExpansion + " and " + bestLengthOfAll + " blocks long shaft:\r\n";

                for (int segment = 0; segment < bestLengthOfAll; segment++) {
                    targets[segment] = Math.Pow(fuelExpansion, ((segment + .5) / bestLengthOfAll));
                }

                //output.Text += "Targets (I:R:E):\r\n";
                for (int x = 0; x < bestLengthOfAll; x++) {
                    if (x == 0) {
                        currentCoefficients[x] = bestBlades[x].coefficient;
                        currentCoefficientsBizarre[x] = Average(1, currentCoefficients[x]);
                        if (bestBlades[x].isStator) {
                            currentEfficiencySum[x] = 0;
                            rotors[x] = 0;
                        } else {
                            currentEfficiencySum[x] = bestBlades[x].efficiency * Ratio(targets[x], currentCoefficients[x]);
                            rotors[x] = 1;
                        }
                    } else {
                        currentCoefficients[x] = currentCoefficients[x - 1] * bestBlades[x].coefficient;
                        currentCoefficientsBizarre[x] = Average(currentCoefficients[x - 1], currentCoefficients[x]);
                        if (bestBlades[x].isStator) {
                            currentEfficiencySum[x] = currentEfficiencySum[x - 1];
                            rotors[x] = rotors[x - 1];
                        } else {                            
                            currentEfficiencySum[x] = currentEfficiencySum[x - 1] + bestBlades[x].efficiency * Ratio(targets[x], currentCoefficients[x]);
                            rotors[x] = rotors[x - 1] + 1;
                        }
                    }

                    //if (bestBlades[x].isStator) continue;
                    //output.Text += targets[x] + ":" + currentCoefficients[x] + ":" + currentEfficiencySum[x] + "\r\n";
                    resultsList.AddObject(new Result(x, targets[x], currentCoefficientsBizarre[x], bestBlades[x].name));
                }

                output.Text += "Blade Multiplier:" + currentEfficiencySum[bestLengthOfAll - 1] / rotors[bestLengthOfAll - 1]+"\r\n";

                string list = "";
                for (int x = 0; x < bestLengthOfAll; x++) list += bestBlades[x].name + ", ";
                list = list.Substring(0, list.Length - 2);
                output.Text += list + "\r\n";
                output.Text += (fuelExpansion * bestExpansion).ToString("P") +
                    " [" + fuelExpansion + " x " + bestExpansion.ToString("P") + "]\r\n";
                output.Text += "RF per mb (coil efficiency not taken into account!): " + rfpermb * bestEfficiency + "\r\n";
                output.Text += "Time taken: " + stopwatch.ElapsedMilliseconds + " milliseconds\r\n";
            }
            EnableGUI(true);
        }

        public static bool IsExpansionHighEnough(int depth, Blade currentStator) {
            double bestCurrentEfficiency = 0;
            double bestLaterEfficiency = 0;
            for (int blade = 0; blade < blades.Count; blade++) {
                Blade actualBlade = blades[blade];
                if (actualBlade.isStator) continue;
                double currentCoefficient = Average(currentCoefficients[depth - 1], currentCoefficients[depth - 1] * actualBlade.coefficient);
                double currentEfficiency = Ratio(currentCoefficient, targets[depth]) * actualBlade.efficiency;
                if (bestCurrentEfficiency < currentEfficiency) bestCurrentEfficiency = currentEfficiency;
                double laterCoefficient = Average(currentCoefficients[depth - 1] * currentStator.coefficient, currentCoefficients[depth - 1] * currentStator.coefficient * actualBlade.coefficient);
                double laterEfficiency = Ratio(laterCoefficient, targets[depth + 1]) * actualBlade.efficiency;
                if (bestLaterEfficiency < laterEfficiency) bestLaterEfficiency = laterEfficiency;
            }
            return bestLaterEfficiency > bestCurrentEfficiency;
        }

        public static bool IsEfficiencyGoodEnough(int depth, int length) {
            int remainingSegments = length - depth - 1;
            return (currentEfficiencySum[depth] + (bestPossibleEfficiency * remainingSegments)) / 
                (rotors[depth] + remainingSegments) > bestEfficiency;
        }

        public void Calculate(int length, bool softReset) {
            if (softReset) SoftResetVariables(length);
            else ResetVariables(length);
            stopwatch.Start();
            RecursiveCheck(0, length);
            stopwatch.Stop();
        }

        public void SoftResetVariables(int length) {
            for (int segment = 0; segment < length; segment++) {
                targets[segment] = Math.Pow(fuelExpansion, ((segment + .5) / length));
            }
            for (int pos = 0; pos < length; pos++) currentBlades[pos] = blades[0];
        }

        public void ResetVariables(int length) {
            SoftResetVariables(length);
            bestExpansion = 0;
            bestEfficiency = 0;
            bestLengthOfAll = 0;
            for (int pos = 0; pos < length; pos++)  bestBlades[pos] = blades[0];
            bestPossibleEfficiency = 0;
            for (int blade = 0; blade < blades.Count; blade++) {
                if (blades[blade].isStator) continue;
                if (blades[blade].efficiency > bestPossibleEfficiency) bestPossibleEfficiency = blades[blade].efficiency;
            }
        }

        public static double Average(double a, double b) {
            return (a + b) / 2;
        }

        public static double Ratio(double a, double b) {
            return Math.Min(a, b) / Math.Max(a, b);
        }

        public static void RecursiveCheck(int depth, int length) {
            if (cancel.IsCancellationRequested) return;
            for (int blade = 0; blade < blades.Count; blade++) {
                Blade actualBlade = blades[blade];
                currentBlades[depth] = actualBlade;

                if (depth == 0) {
                    currentCoefficients[0] = actualBlade.coefficient;
                    currentCoefficientsBizarre[0] = actualBlade.sqrtCoefficient;
                    if (!actualBlade.isStator) {
                        currentEfficiencySum[0] = Ratio(currentCoefficientsBizarre[0], targets[0]) * actualBlade.efficiency;
                        rotors[0] = 1;
                    } else {
                        rotors[0] = 0;
                        currentEfficiencySum[0] = 0;
                    }
                } else {
                    currentCoefficients[depth] = currentCoefficients[depth - 1] * actualBlade.coefficient;
                    currentCoefficientsBizarre[depth] = currentCoefficients[depth - 1] * actualBlade.sqrtCoefficient;
                    if (!actualBlade.isStator) {
                        if (targets[depth] < currentCoefficientsBizarre[depth - 1]) continue;
                        currentEfficiencySum[depth] = currentEfficiencySum[depth - 1] + 
                            (Ratio(currentCoefficientsBizarre[depth], targets[depth]) * actualBlade.efficiency);
                        rotors[depth] = rotors[depth - 1] + 1;
                    } else {
                        if (targets[depth] > currentCoefficientsBizarre[depth - 1] &&
                            depth + 1 < length && !IsExpansionHighEnough(depth, actualBlade)) continue;
                        rotors[depth] = rotors[depth - 1];
                        currentEfficiencySum[depth] = currentEfficiencySum[depth - 1];
                    }
                }

                if (!IsEfficiencyGoodEnough(depth, length)) continue;

                if (depth + 1 < length) RecursiveCheck(depth + 1, length);
                else { //last segment
                    double averageEfficiency = currentEfficiencySum[depth] / rotors[depth];
                    double expansionCoefficient = Ratio(currentCoefficients[depth], fuelExpansion);
                    double finalEfficiency = averageEfficiency * expansionCoefficient;
                    if (finalEfficiency > bestEfficiency) {
                        bestEfficiency = finalEfficiency;
                        bestExpansion = currentCoefficients[depth] / fuelExpansion;
                        bestLengthOfAll = length;
                        for (int x = 0; x < length; x++) bestBlades[x] = currentBlades[x];
                    }
                }
            }
        }

        private void addBTN_Click(object sender, EventArgs e) {
            Blade toAdd = (Blade)availableList.SelectedObject;
            availableBlades.Remove(toAdd);
            blades.Add(toAdd);
            usedList.BuildList();
            availableList.BuildList();
            deleteBTN.Enabled = addBTN.Enabled = editBTN.Enabled = false;
        }

        private void removeBTN_Click(object sender, EventArgs e) {
            Blade toRemove = (Blade)usedList.SelectedObject;
            blades.Remove(toRemove);
            availableBlades.Add(toRemove);
            usedList.BuildList();
            availableList.BuildList();
            deleteBTN.Enabled = removeBTN.Enabled = editBTN.Enabled = false;
        }

        private void availableList_SelectedIndexChanged(object sender, EventArgs e) {
            addBTN.Enabled = editBTN.Enabled = deleteBTN.Enabled = (availableList.SelectedIndex >= 0);
        }

        private void usedList_SelectedIndexChanged(object sender, EventArgs e) {
            removeBTN.Enabled = editBTN.Enabled = deleteBTN.Enabled = (usedList.SelectedIndex >= 0 && blades.Count > 1);
        }

        private void usedList_Leave(object sender, EventArgs e) {
            if (!removeBTN.ContainsFocus && !editBTN.ContainsFocus && !deleteBTN.ContainsFocus) usedList.SelectedIndex = -1;
        }

        private void availableList_Leave(object sender, EventArgs e) {
            if (!addBTN.ContainsFocus && !editBTN.ContainsFocus && !deleteBTN.ContainsFocus) availableList.SelectedIndex = -1;
        }

        EditBladeForm editForm;
        Blade beingEdited;

        private void editBTN_Click(object sender, EventArgs e) {
            beingEdited = usedList.SelectedObject != null ? (Blade)usedList.SelectedObject : (Blade)availableList.SelectedObject;
            editForm = new EditBladeForm(beingEdited, false);
            editForm.Show();
            this.Enabled = false;
            editForm.FormClosing += EditForm_FormClosing;
        }

        public void LoadSettings() {
            if (!File.Exists(fileName)) {
                blades.Add(stator);
                blades.Add(steel);
                blades.Add(extreme);
                blades.Add(SiC);
            } else {
                SaveFile save = JsonConvert.DeserializeObject<SaveFile>(File.ReadAllText(fileName));
                blades = save.used;
                availableBlades = save.available;
                lengthInput.Value = save.shaftLength;
                fuelMode.SelectedIndex = save.fuelMode;
                rfpermbInput.Value = save.rfpermb;
                expansionInput.Value = save.expansion;
                fuelList.SelectedIndex = save.selectedFuel;
            }
        }

        private void EditForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (!editForm.canceled) {
                if (editForm.newBlade) blades.Add(beingEdited);
                beingEdited.name = editForm.nameBox.Text;
                beingEdited.efficiency = (double)editForm.efficiencyBox.Value;
                beingEdited.coefficient = (double)editForm.coefficientBox.Value;
                beingEdited.isStator = editForm.statorCheckbox.Checked;
                usedList.BuildList();
                availableList.BuildList();
            }
            this.Enabled = true;
        }

        private void newBTN_Click(object sender, EventArgs e) {
            beingEdited = new Blade("New Blade", 1, 1, false, true);
            editForm = new EditBladeForm(beingEdited, true);
            editForm.Show();
            this.Enabled = false;
            editForm.FormClosing += EditForm_FormClosing;
        }

        private void TurbineCalculator_FormClosing(object sender, FormClosingEventArgs e) {
            SaveFile save = new SaveFile();
            save.used = blades;
            save.available = availableBlades;
            save.shaftLength = (int)lengthInput.Value;
            save.fuelMode = fuelMode.SelectedIndex;
            save.rfpermb = rfpermbInput.Value;
            save.expansion = expansionInput.Value;
            save.selectedFuel = fuelList.SelectedIndex;
            File.WriteAllText(fileName, JsonConvert.SerializeObject(save));
        }

        private void deleteBTN_Click(object sender, EventArgs e) {
            deleteBTN.Enabled = addBTN.Enabled = removeBTN.Enabled = editBTN.Enabled = false;
            if (usedList.SelectedObject != null) {
                blades.Remove((Blade)usedList.SelectedObject);
                usedList.BuildList();
            } else {
                availableBlades.Remove((Blade)availableList.SelectedObject);
                availableList.BuildList();
            }
        }
    }
}
