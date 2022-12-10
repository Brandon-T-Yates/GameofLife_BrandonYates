namespace GameofLife_BrandonYates
{
    partial class GridTimeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridTimeForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.timerChange = new System.Windows.Forms.NumericUpDown();
            this.widthChange = new System.Windows.Forms.NumericUpDown();
            this.heightChange = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.timerChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleDescription = "Cancels the changes made without saving";
            this.cancelButton.AccessibleName = "Cancel";
            this.cancelButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(230, 174);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.AccessibleDescription = "Accepts the changes that have been made";
            this.okButton.AccessibleName = "OK";
            this.okButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(149, 174);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // timerChange
            // 
            this.timerChange.AccessibleDescription = "Used to change the speed at which generations populate by milliseconds";
            this.timerChange.AccessibleName = "Time Changer";
            this.timerChange.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.timerChange.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.timerChange.Location = new System.Drawing.Point(211, 28);
            this.timerChange.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.timerChange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timerChange.Name = "timerChange";
            this.timerChange.Size = new System.Drawing.Size(59, 20);
            this.timerChange.TabIndex = 2;
            this.timerChange.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // widthChange
            // 
            this.widthChange.AccessibleDescription = "Used to change the cell with on the grid";
            this.widthChange.AccessibleName = "Cell Width Changer";
            this.widthChange.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.widthChange.Location = new System.Drawing.Point(211, 52);
            this.widthChange.Name = "widthChange";
            this.widthChange.Size = new System.Drawing.Size(59, 20);
            this.widthChange.TabIndex = 3;
            // 
            // heightChange
            // 
            this.heightChange.AccessibleDescription = "Used to change the cell with on the grid";
            this.heightChange.AccessibleName = "Cell Height Changer";
            this.heightChange.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.heightChange.Location = new System.Drawing.Point(211, 76);
            this.heightChange.Name = "heightChange";
            this.heightChange.Size = new System.Drawing.Size(59, 20);
            this.heightChange.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Timer Generation in Milliseconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Width of Universe in Cells";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Height of Universe in Cells";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(313, 137);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 8;
            // 
            // GridTimeForm
            // 
            this.AcceptButton = this.okButton;
            this.AccessibleDescription = "Window is used to make changes to the grid and cell timer";
            this.AccessibleName = "Change Window";
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(311, 205);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.heightChange);
            this.Controls.Add(this.widthChange);
            this.Controls.Add(this.timerChange);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GridTimeForm";
            this.Text = "Grid & Time";
            ((System.ComponentModel.ISupportInitialize)(this.timerChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.NumericUpDown timerChange;
        private System.Windows.Forms.NumericUpDown widthChange;
        private System.Windows.Forms.NumericUpDown heightChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}