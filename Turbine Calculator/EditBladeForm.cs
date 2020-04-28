using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turbine_Calculator {
    public partial class EditBladeForm : Form {
        public EditBladeForm(Blade blade, bool newBlade) {
            this.newBlade = newBlade;
            InitializeComponent();
            nameBox.Text = blade.name;
            efficiencyBox.Value = (decimal)blade.efficiency;
            coefficientBox.Value = (decimal)blade.coefficient;
            statorCheckbox.Checked = blade.isStator;
        }

        public bool newBlade;
        public bool canceled = false;

        private void cancelBTN_Click(object sender, EventArgs e) {
            canceled = true;
            this.Close();
        }

        private void nameBox_TextChanged(object sender, EventArgs e) {
            confirmBTN.Enabled = (nameBox.Text != "");
        }

        private void confirmBTN_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
