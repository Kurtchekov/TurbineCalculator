using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Turbine_Calculator {
    public partial class TurbineCalculator : Form {
        public TurbineCalculator() {
            InitializeComponent();
            fuelList.SelectedIndex = 0;
        }

        public static double fuelExpansion = 4;
        public static double rfpermb = 16;
        public static int segments = 20;
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

        private void runBTN_Click(object sender, EventArgs e) {
            Setup();
            targets = new double[segments];
            //output.Text += "target values for each segment:\r\n";
            for (int segment = 0; segment < segments; segment++) {
                targets[segment] = Math.Pow(fuelExpansion, ((segment + .5) / segments));
                //output.Text += segment + ": " + targets[segment] + "\r\n";
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            Calculate();
            output.Text += "Best combination for fuel expansion " + fuelExpansion + " and " + segments + " blocks long shaft:\r\n";
            string list = "";
            for (int x = 0; x < segments; x++) list += bestBlades[x].name + ", ";
            list = list.Substring(0, list.Length - 2);
            output.Text += list + "\r\n";
            output.Text += (fuelExpansion * bestExpansion).ToString("P") +
                " [" + fuelExpansion + " x " + bestExpansion.ToString("P") + "]\r\n";
            output.Text += "RF per mb (coil efficiency not taken into account!): " + rfpermb * bestEfficiency + "\r\n";
            output.Text += "Time taken: " + stopwatch.ElapsedMilliseconds + " milliseconds\r\n";
        }

        public void Setup() {
            bestExpansion = 0;
            bestEfficiency = 0;
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

        public static void Calculate() {
            currentBlades = new Blade[segments];
            bestBlades = new Blade[segments];
            for (int blade = 0; blade < segments; blade++) bestBlades[blade] = currentBlades[blade] = blades[0];
            currentCoefficients = new double[segments];
            currentEfficiencySum = new double[segments];
            rotors = new int[segments];
            bladesAvailable = blades.Count;
            recursiveCheck(0);
        }

        public static bool checkLowerBound(int depth, Blade currentStator) {
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

        public static void recursiveCheck(int depth) {
            for (int blade = 0; blade < bladesAvailable; blade++) {
                Blade actualBlade = blades[blade];
                currentBlades[depth] = actualBlade;

                if (depth == 0) {
                    currentCoefficients[0] = actualBlade.coefficient;
                    if (!actualBlade.isStator) {
                        currentEfficiencySum[0] = (Math.Min(currentCoefficients[0], targets[0]) /
                            Math.Max(currentCoefficients[0], targets[0])) * actualBlade.efficiency;
                        rotors[0] = 1;
                    } else {
                        rotors[0] = 0;
                        currentEfficiencySum[0] = 0;
                    }
                } else {
                    currentCoefficients[depth] = currentCoefficients[depth - 1] * actualBlade.coefficient;
                    if (!actualBlade.isStator) {
                        if (targets[depth] < currentCoefficients[depth - 1]) continue;
                        currentEfficiencySum[depth] = currentEfficiencySum[depth - 1] + (
                        (Math.Min(currentCoefficients[depth], targets[depth]) /
                        Math.Max(currentCoefficients[depth], targets[depth])) * actualBlade.efficiency);
                        rotors[depth] = rotors[depth - 1] + 1;
                    } else {
                        if (targets[depth] > currentCoefficients[depth - 1] &&
                            depth + 1 < segments) if (!checkLowerBound(depth, actualBlade)) continue;
                        rotors[depth] = rotors[depth - 1];
                        currentEfficiencySum[depth] = currentEfficiencySum[depth - 1];
                    }
                }

                if (depth + 1 < segments) recursiveCheck(depth + 1);
                else { //last segment
                    double averageEfficiency = currentEfficiencySum[depth] / rotors[depth];
                    double expansionCoefficient = Math.Min(currentCoefficients[depth], fuelExpansion) / Math.Max(currentCoefficients[depth], fuelExpansion);
                    double finalEfficiency = averageEfficiency * expansionCoefficient;
                    if (finalEfficiency > bestEfficiency) {
                        bestEfficiency = finalEfficiency;
                        bestExpansion = expansionCoefficient;
                        for (int x = 0; x < segments; x++) bestBlades[x] = currentBlades[x];
                    }
                }
            }
        }
    }

    public struct Blade {

        public int uid;
        public string name;
        public double coefficient;
        public double efficiency;
        public bool isStator;

        /// <param name="u">A Unique IDentifier</param>
        /// <param name="n">Human-friendly name</param>
        /// <param name="c">Coefficient number</param>
        /// <param name="f">Efficiency Number</param>
        /// <param name="s">Is this an stator?</param>
        public Blade(int u, string n, double c, double f, bool s) {
            uid = u;
            name = n;
            coefficient = c;
            efficiency = f;
            isStator = s;
        }

        public static bool operator ==(Blade obj1, Blade obj2) {
            return (obj1.uid == obj2.uid);
        }

        public static bool operator !=(Blade obj1, Blade obj2) {
            return (obj1.uid != obj2.uid);
        }

        public override bool Equals(Object obj) {
            return (obj is Blade) && ((Blade)obj).uid == uid;
        }

        public override int GetHashCode() {
            return uid;
        }
    }
}
