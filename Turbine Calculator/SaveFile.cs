using System.Collections.Generic;

namespace Turbine_Calculator {
    class SaveFile {

        public List<Blade> used;
        public List<Blade> available;
        public int shaftLength;
        public int fuelMode;
        public decimal rfpermb;
        public decimal expansion;
        public int selectedFuel;
        public bool overhaulMode;
    }
}
