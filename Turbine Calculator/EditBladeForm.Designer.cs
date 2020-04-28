namespace Turbine_Calculator {
    partial class EditBladeForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.coefficientBox = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.efficiencyBox = new System.Windows.Forms.NumericUpDown();
            this.statorCheckbox = new System.Windows.Forms.CheckBox();
            this.confirmBTN = new System.Windows.Forms.Button();
            this.cancelBTN = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coefficientBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efficiencyBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(7, 20);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(119, 20);
            this.nameBox.TabIndex = 0;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.coefficientBox);
            this.groupBox2.Location = new System.Drawing.Point(13, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 49);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Coefficient";
            // 
            // coefficientBox
            // 
            this.coefficientBox.DecimalPlaces = 2;
            this.coefficientBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.coefficientBox.Location = new System.Drawing.Point(7, 20);
            this.coefficientBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.coefficientBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            393216});
            this.coefficientBox.Name = "coefficientBox";
            this.coefficientBox.Size = new System.Drawing.Size(120, 20);
            this.coefficientBox.TabIndex = 0;
            this.coefficientBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.efficiencyBox);
            this.groupBox3.Location = new System.Drawing.Point(13, 123);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(133, 49);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Efficiency";
            // 
            // efficiencyBox
            // 
            this.efficiencyBox.DecimalPlaces = 2;
            this.efficiencyBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.efficiencyBox.Location = new System.Drawing.Point(7, 20);
            this.efficiencyBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.efficiencyBox.Name = "efficiencyBox";
            this.efficiencyBox.Size = new System.Drawing.Size(120, 20);
            this.efficiencyBox.TabIndex = 0;
            this.efficiencyBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // statorCheckbox
            // 
            this.statorCheckbox.AutoSize = true;
            this.statorCheckbox.Location = new System.Drawing.Point(13, 179);
            this.statorCheckbox.Name = "statorCheckbox";
            this.statorCheckbox.Size = new System.Drawing.Size(71, 17);
            this.statorCheckbox.TabIndex = 3;
            this.statorCheckbox.Text = "Is Stator?";
            this.statorCheckbox.UseVisualStyleBackColor = true;
            // 
            // confirmBTN
            // 
            this.confirmBTN.Enabled = false;
            this.confirmBTN.Location = new System.Drawing.Point(9, 202);
            this.confirmBTN.Name = "confirmBTN";
            this.confirmBTN.Size = new System.Drawing.Size(61, 23);
            this.confirmBTN.TabIndex = 4;
            this.confirmBTN.Text = "Done";
            this.confirmBTN.UseVisualStyleBackColor = true;
            this.confirmBTN.Click += new System.EventHandler(this.confirmBTN_Click);
            // 
            // cancelBTN
            // 
            this.cancelBTN.Location = new System.Drawing.Point(82, 202);
            this.cancelBTN.Name = "cancelBTN";
            this.cancelBTN.Size = new System.Drawing.Size(65, 23);
            this.cancelBTN.TabIndex = 5;
            this.cancelBTN.Text = "Cancel";
            this.cancelBTN.UseVisualStyleBackColor = true;
            this.cancelBTN.Click += new System.EventHandler(this.cancelBTN_Click);
            // 
            // EditBladeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(159, 236);
            this.Controls.Add(this.cancelBTN);
            this.Controls.Add(this.confirmBTN);
            this.Controls.Add(this.statorCheckbox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditBladeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Blade";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coefficientBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efficiencyBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button confirmBTN;
        private System.Windows.Forms.Button cancelBTN;
        public System.Windows.Forms.TextBox nameBox;
        public System.Windows.Forms.NumericUpDown coefficientBox;
        public System.Windows.Forms.NumericUpDown efficiencyBox;
        public System.Windows.Forms.CheckBox statorCheckbox;
    }
}