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
            System.Windows.Forms.SplitContainer splitContainer1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TurbineCalculator));
            this.bladesBox = new System.Windows.Forms.GroupBox();
            this.deleteBTN = new System.Windows.Forms.Button();
            this.editBTN = new System.Windows.Forms.Button();
            this.addBTN = new System.Windows.Forms.Button();
            this.newBTN = new System.Windows.Forms.Button();
            this.removeBTN = new System.Windows.Forms.Button();
            this.SettingsBox2 = new System.Windows.Forms.GroupBox();
            this.fuelMode = new System.Windows.Forms.TabControl();
            this.autoMode = new System.Windows.Forms.TabPage();
            this.fuelList = new System.Windows.Forms.ListBox();
            this.manualMode = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rfpermbInput = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.expansionInput = new System.Windows.Forms.NumericUpDown();
            this.runAllBTN = new System.Windows.Forms.Button();
            this.SettingsBox3 = new System.Windows.Forms.GroupBox();
            this.lengthInput = new System.Windows.Forms.NumericUpDown();
            this.runBTN = new System.Windows.Forms.Button();
            this.resultsList = new BrightIdeasSoftware.FastObjectListView();
            this.posColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.targetColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.expansionColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.bladeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.availableList = new BrightIdeasSoftware.DataListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.usedList = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.output = new System.Windows.Forms.TextBox();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            this.bladesBox.SuspendLayout();
            this.SettingsBox2.SuspendLayout();
            this.fuelMode.SuspendLayout();
            this.autoMode.SuspendLayout();
            this.manualMode.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rfpermbInput)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expansionInput)).BeginInit();
            this.SettingsBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usedList)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer1.IsSplitterFixed = true;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(this.resultsList);
            splitContainer1.Panel1.Controls.Add(this.bladesBox);
            splitContainer1.Panel1.Controls.Add(this.SettingsBox2);
            splitContainer1.Panel1.Controls.Add(this.runAllBTN);
            splitContainer1.Panel1.Controls.Add(this.SettingsBox3);
            splitContainer1.Panel1.Controls.Add(this.runBTN);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(this.output);
            splitContainer1.Size = new System.Drawing.Size(588, 430);
            splitContainer1.SplitterDistance = 285;
            splitContainer1.TabIndex = 17;
            // 
            // bladesBox
            // 
            this.bladesBox.Controls.Add(this.usedList);
            this.bladesBox.Controls.Add(this.availableList);
            this.bladesBox.Controls.Add(this.deleteBTN);
            this.bladesBox.Controls.Add(this.editBTN);
            this.bladesBox.Controls.Add(this.addBTN);
            this.bladesBox.Controls.Add(this.newBTN);
            this.bladesBox.Controls.Add(this.removeBTN);
            this.bladesBox.Location = new System.Drawing.Point(12, 139);
            this.bladesBox.Name = "bladesBox";
            this.bladesBox.Size = new System.Drawing.Size(313, 137);
            this.bladesBox.TabIndex = 15;
            this.bladesBox.TabStop = false;
            this.bladesBox.Text = "Blades";
            // 
            // deleteBTN
            // 
            this.deleteBTN.Enabled = false;
            this.deleteBTN.Location = new System.Drawing.Point(111, 108);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(92, 23);
            this.deleteBTN.TabIndex = 14;
            this.deleteBTN.Text = "Delete";
            this.deleteBTN.UseVisualStyleBackColor = true;
            this.deleteBTN.Click += new System.EventHandler(this.deleteBTN_Click);
            // 
            // editBTN
            // 
            this.editBTN.Enabled = false;
            this.editBTN.Location = new System.Drawing.Point(111, 85);
            this.editBTN.Name = "editBTN";
            this.editBTN.Size = new System.Drawing.Size(92, 23);
            this.editBTN.TabIndex = 13;
            this.editBTN.Text = "Edit";
            this.editBTN.UseVisualStyleBackColor = true;
            this.editBTN.Click += new System.EventHandler(this.editBTN_Click);
            // 
            // addBTN
            // 
            this.addBTN.Enabled = false;
            this.addBTN.Location = new System.Drawing.Point(111, 16);
            this.addBTN.Name = "addBTN";
            this.addBTN.Size = new System.Drawing.Size(92, 23);
            this.addBTN.TabIndex = 10;
            this.addBTN.Text = "Add ->";
            this.addBTN.UseVisualStyleBackColor = true;
            this.addBTN.Click += new System.EventHandler(this.addBTN_Click);
            // 
            // newBTN
            // 
            this.newBTN.Location = new System.Drawing.Point(111, 62);
            this.newBTN.Name = "newBTN";
            this.newBTN.Size = new System.Drawing.Size(92, 23);
            this.newBTN.TabIndex = 12;
            this.newBTN.Text = "New";
            this.newBTN.UseVisualStyleBackColor = true;
            this.newBTN.Click += new System.EventHandler(this.newBTN_Click);
            // 
            // removeBTN
            // 
            this.removeBTN.Enabled = false;
            this.removeBTN.Location = new System.Drawing.Point(111, 39);
            this.removeBTN.Name = "removeBTN";
            this.removeBTN.Size = new System.Drawing.Size(92, 23);
            this.removeBTN.TabIndex = 11;
            this.removeBTN.Text = "<- Remove";
            this.removeBTN.UseVisualStyleBackColor = true;
            this.removeBTN.Click += new System.EventHandler(this.removeBTN_Click);
            // 
            // SettingsBox2
            // 
            this.SettingsBox2.Controls.Add(this.fuelMode);
            this.SettingsBox2.Location = new System.Drawing.Point(12, 13);
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
            // runAllBTN
            // 
            this.runAllBTN.Location = new System.Drawing.Point(221, 103);
            this.runAllBTN.Name = "runAllBTN";
            this.runAllBTN.Size = new System.Drawing.Size(104, 30);
            this.runAllBTN.TabIndex = 7;
            this.runAllBTN.Text = "All lengths up to";
            this.runAllBTN.UseVisualStyleBackColor = true;
            this.runAllBTN.Click += new System.EventHandler(this.RunAll);
            // 
            // SettingsBox3
            // 
            this.SettingsBox3.Controls.Add(this.lengthInput);
            this.SettingsBox3.Location = new System.Drawing.Point(221, 13);
            this.SettingsBox3.Name = "SettingsBox3";
            this.SettingsBox3.Size = new System.Drawing.Size(104, 48);
            this.SettingsBox3.TabIndex = 2;
            this.SettingsBox3.TabStop = false;
            this.SettingsBox3.Text = "Shaft Length";
            // 
            // lengthInput
            // 
            this.lengthInput.Location = new System.Drawing.Point(6, 19);
            this.lengthInput.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
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
            // runBTN
            // 
            this.runBTN.Location = new System.Drawing.Point(221, 67);
            this.runBTN.Name = "runBTN";
            this.runBTN.Size = new System.Drawing.Size(104, 30);
            this.runBTN.TabIndex = 5;
            this.runBTN.Text = "This length only";
            this.runBTN.UseVisualStyleBackColor = true;
            this.runBTN.Click += new System.EventHandler(this.Run);
            // 
            // resultsList
            // 
            this.resultsList.AllColumns.Add(this.posColumn);
            this.resultsList.AllColumns.Add(this.targetColumn);
            this.resultsList.AllColumns.Add(this.expansionColumn);
            this.resultsList.AllColumns.Add(this.bladeColumn);
            this.resultsList.CellEditUseWholeCell = false;
            this.resultsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.posColumn,
            this.targetColumn,
            this.expansionColumn,
            this.bladeColumn});
            this.resultsList.Cursor = System.Windows.Forms.Cursors.Default;
            this.resultsList.FullRowSelect = true;
            this.resultsList.GridLines = true;
            this.resultsList.HideSelection = false;
            this.resultsList.Location = new System.Drawing.Point(331, 13);
            this.resultsList.Name = "resultsList";
            this.resultsList.ShowGroups = false;
            this.resultsList.Size = new System.Drawing.Size(248, 263);
            this.resultsList.TabIndex = 16;
            this.resultsList.UseCompatibleStateImageBehavior = false;
            this.resultsList.View = System.Windows.Forms.View.Details;
            this.resultsList.VirtualMode = true;
            // 
            // posColumn
            // 
            this.posColumn.AspectName = "position";
            this.posColumn.Text = "Position";
            // 
            // targetColumn
            // 
            this.targetColumn.AspectName = "target";
            this.targetColumn.IsEditable = false;
            this.targetColumn.Text = "Target";
            // 
            // expansionColumn
            // 
            this.expansionColumn.AspectName = "expansion";
            this.expansionColumn.IsEditable = false;
            this.expansionColumn.Text = "Expansion";
            // 
            // bladeColumn
            // 
            this.bladeColumn.AspectName = "blade";
            this.bladeColumn.IsEditable = false;
            this.bladeColumn.Text = "Blade";
            // 
            // availableList
            // 
            this.availableList.AllColumns.Add(this.olvColumn2);
            this.availableList.CellEditUseWholeCell = false;
            this.availableList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2});
            this.availableList.DataSource = null;
            this.availableList.FullRowSelect = true;
            this.availableList.GridLines = true;
            this.availableList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.availableList.HideSelection = false;
            this.availableList.Location = new System.Drawing.Point(7, 17);
            this.availableList.Name = "availableList";
            this.availableList.Size = new System.Drawing.Size(98, 114);
            this.availableList.TabIndex = 17;
            this.availableList.UseCompatibleStateImageBehavior = false;
            this.availableList.View = System.Windows.Forms.View.List;
            this.availableList.SelectedIndexChanged += new System.EventHandler(this.availableList_SelectedIndexChanged);
            this.availableList.Leave += new System.EventHandler(this.availableList_Leave);
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "name";
            this.olvColumn2.Text = "Name";
            // 
            // usedList
            // 
            this.usedList.AllColumns.Add(this.olvColumn1);
            this.usedList.CellEditUseWholeCell = false;
            this.usedList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1});
            this.usedList.DataSource = null;
            this.usedList.FullRowSelect = true;
            this.usedList.GridLines = true;
            this.usedList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.usedList.HideSelection = false;
            this.usedList.Location = new System.Drawing.Point(209, 17);
            this.usedList.Name = "usedList";
            this.usedList.Size = new System.Drawing.Size(98, 114);
            this.usedList.TabIndex = 18;
            this.usedList.UseCompatibleStateImageBehavior = false;
            this.usedList.View = System.Windows.Forms.View.List;
            this.usedList.SelectedIndexChanged += new System.EventHandler(this.usedList_SelectedIndexChanged);
            this.usedList.Leave += new System.EventHandler(this.usedList_Leave);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "name";
            this.olvColumn1.Text = "Name";
            // 
            // output
            // 
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Location = new System.Drawing.Point(0, 0);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(588, 141);
            this.output.TabIndex = 6;
            // 
            // TurbineCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 430);
            this.Controls.Add(splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TurbineCalculator";
            this.Text = "Turbine Calculator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TurbineCalculator_FormClosing);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
            splitContainer1.ResumeLayout(false);
            this.bladesBox.ResumeLayout(false);
            this.SettingsBox2.ResumeLayout(false);
            this.fuelMode.ResumeLayout(false);
            this.autoMode.ResumeLayout(false);
            this.manualMode.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rfpermbInput)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expansionInput)).EndInit();
            this.SettingsBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lengthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usedList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Button runAllBTN;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button addBTN;
        private System.Windows.Forms.Button removeBTN;
        private System.Windows.Forms.Button newBTN;
        private System.Windows.Forms.Button editBTN;
        private System.Windows.Forms.Button deleteBTN;
        private System.Windows.Forms.GroupBox bladesBox;
        private BrightIdeasSoftware.FastObjectListView resultsList;
        public BrightIdeasSoftware.OLVColumn targetColumn;
        public BrightIdeasSoftware.OLVColumn expansionColumn;
        public BrightIdeasSoftware.OLVColumn bladeColumn;
        public BrightIdeasSoftware.OLVColumn posColumn;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.DataListView availableList;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.DataListView usedList;
        private System.Windows.Forms.TextBox output;
    }
}

