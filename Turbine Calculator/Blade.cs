using System;

namespace Turbine_Calculator {
    public struct Blade {

        public int uid { set; get; }
        public string name { set; get; }
        public double coefficient { set; get; }
        public double efficiency { set; get; }
        public bool isStator { set; get; }
        public bool isCustom { set; get; }

        /// <param name="u">A Unique IDentifier</param>
        /// <param name="n">Human-friendly name</param>
        /// <param name="c">Coefficient number</param>
        /// <param name="f">Efficiency Number</param>
        /// <param name="s">Is this an stator?</param>
        public Blade(int u, string n, double c, double f, bool s, bool custom = false) {
            uid = u;
            name = n;
            coefficient = c;
            efficiency = f;
            isStator = s;
            isCustom = custom;
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
