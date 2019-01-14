namespace Turbine_Calculator {
    partial class TurbineCalculator {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TurbineCalculator));
            this.SettingsBox1 = new System.Windows.Forms.GroupBox();
            this.sicCheck = new System.Windows.Forms.CheckBox();
            this.extremeCheck = new System.Windows.Forms.CheckBox();
            this.steelCheck = new System.Windows.Forms.CheckBox();
            this.statorCheck = new System.Windows.Forms.CheckBox();
            this.lengthInput = new System.Windows.Forms.NumericUpDown();
            this.SettingsBox3 = new System.Windows.Forms.GroupBox();
            this.fuelList = new System.Windows.Forms.ListBox();
            this.SettingsBox2 = new System.Windows.Forms.GroupBox();
            this.fuelMode = new System.Windows.Forms.TabControl();
            this.autoMode = new System.Windows.Forms.TabPage();
            this.manualMode = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rfpermbInput = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.expansionInput = new System.Windows.Forms.NumericUpDown();
            this.runBTN = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.TextBox();
            this.runAllBTN = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SettingsBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthInput)).BeginInit();
            this.SettingsBox3.SuspendLayout();
            this.SettingsBox2.SuspendLayout();
            this.fuelMode.SuspendLayout();
            this.autoMode.SuspendLayout();
            this.manualMode.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rfpermbInput)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expansionInput)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsBox1
            // 
            this.SettingsBox1.Controls.Add(this.sicCheck);
            this.SettingsBox1.Controls.Add(this.extremeCheck);
            this.SettingsBox1.Controls.Add(this.steelCheck);
            this.SettingsBox1.Controls.Add(this.statorCheck);
            this.SettingsBox1.Location = new System.Drawing.Point(13, 13);
            this.SettingsBox1.Name = "SettingsBox1";
            this.SettingsBox1.Size = new System.Drawing.Size(134, 116);
            this.SettingsBox1.TabIndex = 0;
            this.SettingsBox1.TabStop = false;
            this.SettingsBox1.Text = "Blade Types to be used";
            // 
            // sicCheck
            // 
            this.sicCheck.AutoSize = true;
            this.sicCheck.Checked = true;
            this.sicCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sicCheck.Location = new System.Drawing.Point(7, 89);
            this.sicCheck.Name = "sicCheck";
            this.sicCheck.Size = new System.Drawing.Size(71, 17);
            this.sicCheck.TabIndex = 3;
            this.sicCheck.Text = "SiC Rotor";
            this.sicCheck.UseVisualStyleBackColor = true;
            this.sicCheck.CheckedChanged += new System.EventHandler(this.CheckCheckboxes);
            // 
            // extremeCheck
            // 
            this.extremeCheck.AutoSize = true;
            this.extremeCheck.Checked = true;
            this.extremeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.extremeCheck.Location = new System.Drawing.Point(7, 66);
            this.extremeCheck.Name = "extremeCheck";
            this.extremeCheck.Size = new System.Drawing.Size(93, 17);
            this.extremeCheck.TabIndex = 2;
            this.extremeCheck.Text = "Extreme Rotor";
            this.extremeCheck.UseVisualStyleBackColor = true;
            this.extremeCheck.CheckedChanged += new System.EventHandler(this.CheckCheckboxes);
            // 
            // steelCheck
            // 
            this.steelCheck.AutoSize = true;
            this.steelCheck.Checked = true;
            this.steelCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.steelCheck.Location = new System.Drawing.Point(7, 43);
            this.steelCheck.Name = "steelCheck";
            this.steelCheck.Size = new System.Drawing.Size(79, 17);
            this.steelCheck.TabIndex = 1;
            this.steelCheck.Text = "Steel Rotor";
            this.steelCheck.UseVisualStyleBackColor = true;
            this.steelCheck.CheckedChanged += new System.EventHandler(this.CheckCheckboxes);
            // 
            // statorCheck
            // 
            this.statorCheck.AutoSize = true;
            this.statorCheck.Checked = true;
            this.statorCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statorCheck.Location = new System.Drawing.Point(7, 20);
            this.statorCheck.Name = "statorCheck";
            this.statorCheck.Size = new System.Drawing.Size(54, 17);
            this.statorCheck.TabIndex = 0;
            this.statorCheck.Text = "Stator";
            this.statorCheck.UseVisualStyleBackColor = true;
            this.statorCheck.CheckedChanged += new System.EventHandler(this.CheckCheckboxes);
            // 
            // lengthInput
            // 
            this.lengthInput.Location = new System.Drawing.Point(6, 19);
            this.lengthInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lengthInput.Name = "lengthInput";
            this.lengthInput.Size = new System.Drawing.Size(92, 20);
            this.lengthInput.TabIndex = 1;
            this.lengthInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // SettingsBox3
            // 
            this.SettingsBox3.Controls.Add(this.lengthInput);
            this.SettingsBox3.Location = new System.Drawing.Point(362, 12);
            this.SettingsBox3.Name = "SettingsBox3";
            this.SettingsBox3.Size = new System.Drawing.Size(104, 48);
            this.SettingsBox3.TabIndex = 2;
            this.SettingsBox3.TabStop = false;
            this.SettingsBox3.Text = "Shaft Length";
            // 
            // fuelList
            // 
            this.fuelList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.fuelList.FormattingEnabled = true;
            this.fuelList.Items.AddRange(new object[] {
            "High Pressure Steam",
            "Low Pressure Steam",
            "Steam"});
            this.fuelList.Location = new System.Drawing.Point(3, 3);
            this.fuelList.Name = "fuelList";
            this.fuelList.Size = new System.Drawing.Size(177, 52);
            this.fuelList.TabIndex = 3;
            // 
            // SettingsBox2
            // 
            this.SettingsBox2.Controls.Add(this.fuelMode);
            this.SettingsBox2.Location = new System.Drawing.Point(153, 12);
            this.SettingsBox2.Name = "SettingsBox2";
            this.SettingsBox2.Size = new System.Drawing.Size(203, 117);
            this.SettingsBox2.TabIndex = 4;
            this.SettingsBox2.TabStop = false;
            this.SettingsBox2.Text = "Fuel";
            // 
            // fuelMode
            // 
            this.fuelMode.Controls.Add(this.autoMode);
            this.fuelMode.Controls.Add(this.manualMode);
            this.fuelMode.Location = new System.Drawing.Point(7, 19);
            this.fuelMode.Name = "fuelMode";
            this.fuelMode.SelectedIndex = 0;
            this.fuelMode.Size = new System.Drawing.Size(191, 88);
            this.fuelMode.TabIndex = 0;
            // 
            // autoMode
            // 
            this.autoMode.Controls.Add(this.fuelList);
            this.autoMode.Location = new System.Drawing.Point(4, 22);
            this.autoMode.Name = "autoMode";
            this.autoMode.Padding = new System.Windows.Forms.Padding(3);
            this.autoMode.Size = new System.Drawing.Size(183, 62);
            this.autoMode.TabIndex = 0;
            this.autoMode.Text = "Auto Mode";
            this.autoMode.UseVisualStyleBackColor = true;
            // 
            // manualMode
            // 
            this.manualMode.Controls.Add(this.groupBox5);
            this.manualMode.Controls.Add(this.groupBox4);
            this.manualMode.Location = new System.Drawing.Point(4, 22);
            this.manualMode.Name = "manualMode";
            this.manualMode.Padding = new System.Windows.Forms.Padding(3);
            this.manualMode.Size = new System.Drawing.Size(183, 62);
            this.manualMode.TabIndex = 1;
            this.manualMode.Text = "Manual Mode";
            this.manualMode.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rfpermbInput);
            this.groupBox5.Location = new System.Drawing.Point(93, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(81, 48);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RF/mb";
            // 
            // rfpermbInput
            // 
            this.rfpermbInput.Location = new System.Drawing.Point(6, 19);
            this.rfpermbInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rfpermbInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rfpermbInput.Name = "rfpermbInput";
            this.rfpermbInput.Size = new System.Drawing.Size(69, 20);
            this.rfpermbInput.TabIndex = 1;
            this.rfpermbInput.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.expansionInput);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(81, 48);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Expansion";
            // 
            // expansionInput
            // 
            this.expansionInput.Location = new System.Drawing.Point(6, 19);
            this.expansionInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.expansionInput.Name = "expansionInput";
            this.expansionInput.Size = new System.Drawing.Size(69, 20);
            this.expansionInput.TabIndex = 1;
            this.expansionInput.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // runBTN
            // 
            this.runBTN.Location = new System.Drawing.Point(362, 64);
            this.runBTN.Name = "runBTN";
            this.runBTN.Size = new System.Drawing.Size(104, 30);
            this.runBTN.TabIndex = 5;
            this.runBTN.Text = "This length only";
            this.runBTN.UseVisualStyleBackColor = true;
            this.runBTN.Click += new System.EventHandler(this.Run);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(13, 135);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(453, 223);
            this.output.TabIndex = 6;
            // 
            // runAllBTN
            // 
            this.runAllBTN.Location = new System.Drawing.Point(362, 99);
            this.runAllBTN.Name = "runAllBTN";
            this.runAllBTN.Size = new System.Drawing.Size(104, 30);
            this.runAllBTN.TabIndex = 7;
            this.runAllBTN.Text = "All lengths up to";
            this.runAllBTN.UseVisualStyleBackColor = true;
            this.runAllBTN.Click += new System.EventHandler(this.RunAll);
            // 
            // TurbineCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 374);
            this.Controls.Add(this.runAllBTN);
            this.Controls.Add(this.output);
            this.Controls.Add(this.runBTN);
            this.Controls.Add(this.SettingsBox2);
            this.Controls.Add(this.SettingsBox3);
            this.Controls.Add(this.SettingsBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TurbineCalculator";
            this.Text = "Turbine Calculator";
            this.SettingsBox1.ResumeLayout(false);
            this.SettingsBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthInput)).EndInit();
            this.SettingsBox3.ResumeLayout(false);
            this.SettingsBox2.ResumeLayout(false);
            this.fuelMode.ResumeLayout(false);
            this.autoMode.ResumeLayout(false);
            this.manualMode.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rfpermbInput)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expansionInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox SettingsBox1;
        private System.Windows.Forms.CheckBox sicCheck;
        private System.Windows.Forms.CheckBox extremeCheck;
        private System.Windows.Forms.CheckBox steelCheck;
        private System.Windows.Forms.CheckBox statorCheck;
        private System.Windows.Forms.NumericUpDown lengthInput;
        private System.Windows.Forms.GroupBox SettingsBox3;
        private System.Windows.Forms.ListBox fuelList;
        private System.Windows.Forms.GroupBox SettingsBox2;
        private System.Windows.Forms.TabControl fuelMode;
        private System.Windows.Forms.TabPage autoMode;
        private System.Windows.Forms.TabPage manualMode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown rfpermbInput;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown expansionInput;
        private System.Windows.Forms.Button runBTN;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.Button runAllBTN;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

