namespace Turbine_Calculator {
    partial class Overlay {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.text = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.abortBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text.Location = new System.Drawing.Point(0, 73);
            this.text.Name = "text";
            this.text.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.text.Size = new System.Drawing.Size(232, 26);
            this.text.TabIndex = 0;
            this.text.Text = "Running, please wait...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Turbine_Calculator.Properties.Resources.gear2;
            this.pictureBox1.Location = new System.Drawing.Point(84, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // abortBTN
            // 
            this.abortBTN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.abortBTN.Location = new System.Drawing.Point(30, 104);
            this.abortBTN.Name = "abortBTN";
            this.abortBTN.Size = new System.Drawing.Size(173, 23);
            this.abortBTN.TabIndex = 2;
            this.abortBTN.Text = "Abort! I Can\'t wait any longer!";
            this.abortBTN.UseVisualStyleBackColor = true;
            this.abortBTN.Click += new System.EventHandler(this.Abort);
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.abortBTN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.text);
            this.Name = "Overlay";
            this.Size = new System.Drawing.Size(238, 134);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label text;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button abortBTN;
    }
}
