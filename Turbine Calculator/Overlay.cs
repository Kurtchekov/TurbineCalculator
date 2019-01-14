using System;
using System.Windows.Forms;

namespace Turbine_Calculator {
    public partial class Overlay : UserControl {

        public event EventHandler Abort_Clicked;

        public Overlay() {
            InitializeComponent();
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.Dock = DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 0);

            
        }

        private void Abort(object sender, EventArgs e) {
            if (Abort_Clicked == null) return;
            Abort_Clicked(sender, e);
        }
    }
}
