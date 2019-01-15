﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turbine_Calculator {
    public partial class TurbineCalculator : Form {
        
        public TurbineCalculator() {
            InitializeComponent();
            fuelList.SelectedIndex = 0;
            overlay = new Overlay();
            overlay.Abort_Clicked += new EventHandler(Abort);
            toolTip.SetToolTip(runBTN, "Retrieves the optimal turbine configuration for the chosen length");
            toolTip.SetToolTip(runAllBTN, "Retrieves the optimal turbine configuration amongst all lengths up to the chosen number. Can be pretty slow!!!");

            currentBlades = new Blade[maxLength];
            bestBlades = new Blade[maxLength];
            targets = new double[maxLength];
            currentCoefficients = new double[maxLength];
            currentEfficiencySum = new double[maxLength];
            rotors = new int[maxLength];
        }

        public static double fuelExpansion;
        public static double rfpermb;
        public static int segments;
        public static double[] targets;

        public static Blade stator = new Blade(0, "stator", .75, -1, true);
        public static Blade steel = new Blade(1, "steel", 1.4, 1, false);
        public static Blade extreme = new Blade(2, "extreme", 1.6, 1.1, false);
        public static Blade SiC = new Blade(3, "SiC", 1.8, 1.25, false);

        public static List<Blade> blades = new List<Blade>();

        public static Blade[] currentBlades;
        public static double[] currentCoefficients;
        public static double[] currentEfficiencySum;
        public static int[] rotors;
        public static Blade[] bestBlades;
        public static double bestEfficiency;
        public static double bestExpansion;
        public static int bladesAvailable;
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
            blades.Clear();
            if (statorCheck.Checked) blades.Add(stator);
            if (steelCheck.Checked) blades.Add(steel);
            if (extremeCheck.Checked) blades.Add(extreme);
            if (sicCheck.Checked) blades.Add(SiC);
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

        public void Run(object sender, EventArgs e) {
            EnableGUI(false);
            Setup();
            stopwatch.Reset();
            cancel = new CancellationTokenSource();
            Task t = Task.Factory.StartNew(() => Calculate(segments, false), cancel.Token).ContinueWith(task => DisplayResults(), TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void RunAll(object sender, EventArgs e) {
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
                output.Text += "Best combination for fuel expansion " + fuelExpansion + " and " + bestLengthOfAll + " blocks long shaft:\r\n";
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
            for (int blade = 0; blade < bladesAvailable; blade++) {
                Blade actualBlade = blades[blade];
                if (actualBlade.isStator) continue;
                double currentCoefficient = currentCoefficients[depth - 1] * actualBlade.coefficient;
                double currentEfficiency = (Math.Min(currentCoefficient, targets[depth]) /
                        Math.Max(currentCoefficient, targets[depth])) * actualBlade.efficiency;
                if (bestCurrentEfficiency < currentEfficiency) bestCurrentEfficiency = currentEfficiency;
                double laterCoefficient = currentCoefficients[depth - 1] * currentStator.coefficient * actualBlade.coefficient;
                double laterEfficiency = (Math.Min(laterCoefficient, targets[depth + 1]) /
                        Math.Max(laterCoefficient, targets[depth + 1])) * actualBlade.efficiency;
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
            bladesAvailable = blades.Count;
            bestPossibleEfficiency = 0;
            for (int blade = 0; blade < bladesAvailable; blade++) {
                if (blades[blade].isStator) continue;
                if (blades[blade].efficiency > bestPossibleEfficiency) bestPossibleEfficiency = blades[blade].efficiency;
            }
        }

        public static double Ratio(double a, double b) {
            return Math.Min(a, b) / Math.Max(a, b);
        }

        public static void RecursiveCheck(int depth, int length) {
            if (cancel.IsCancellationRequested) return;
            for (int blade = 0; blade < bladesAvailable; blade++) {
                Blade actualBlade = blades[blade];
                currentBlades[depth] = actualBlade;

                if (depth == 0) {
                    currentCoefficients[0] = actualBlade.coefficient;
                    if (!actualBlade.isStator) {
                        currentEfficiencySum[0] = Ratio(currentCoefficients[0], targets[0]) * actualBlade.efficiency;
                        rotors[0] = 1;
                    } else {
                        rotors[0] = 0;
                        currentEfficiencySum[0] = 0;
                    }
                } else {
                    currentCoefficients[depth] = currentCoefficients[depth - 1] * actualBlade.coefficient;
                    if (!actualBlade.isStator) {
                        if (targets[depth] < currentCoefficients[depth - 1]) continue;
                        currentEfficiencySum[depth] = currentEfficiencySum[depth - 1] + 
                            (Ratio(currentCoefficients[depth], targets[depth]) * actualBlade.efficiency);
                        rotors[depth] = rotors[depth - 1] + 1;
                    } else {
                        if (targets[depth] > currentCoefficients[depth - 1] &&
                            depth + 1 < length) if (!IsExpansionHighEnough(depth, actualBlade)) continue;
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
                        bestExpansion = expansionCoefficient;
                        bestLengthOfAll = length;
                        for (int x = 0; x < length; x++) bestBlades[x] = currentBlades[x];
                    }
                }
            }
        }

        void CheckCheckboxes(object sender, EventArgs e) {
            int checkedOnes = 0;
            if (statorCheck.Checked) checkedOnes++;
            if (steelCheck.Checked) checkedOnes++;
            if (extremeCheck.Checked) checkedOnes++;
            if (sicCheck.Checked) checkedOnes++;
            if (checkedOnes == 1) {
                statorCheck.Enabled = !statorCheck.Checked;
                steelCheck.Enabled = !steelCheck.Checked;
                extremeCheck.Enabled = !extremeCheck.Checked;
                sicCheck.Enabled = !sicCheck.Checked;
            } else {
                statorCheck.Enabled = true;
                steelCheck.Enabled = true;
                extremeCheck.Enabled = true;
                sicCheck.Enabled = true;
            }
        }
    }
}