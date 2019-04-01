namespace TextEditor
{
    partial class Find
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
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonFindNext = new System.Windows.Forms.Button();
            this.buttonFindCancel = new System.Windows.Forms.Button();
            this.checkBoxCase = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonDown = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(77, 34);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(207, 20);
            this.textBoxFind.TabIndex = 0;
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonFindNext
            // 
            this.buttonFindNext.Enabled = false;
            this.buttonFindNext.Location = new System.Drawing.Point(315, 34);
            this.buttonFindNext.Name = "buttonFindNext";
            this.buttonFindNext.Size = new System.Drawing.Size(75, 23);
            this.buttonFindNext.TabIndex = 1;
            this.buttonFindNext.Text = "Find next";
            this.buttonFindNext.UseVisualStyleBackColor = true;
            this.buttonFindNext.Click += new System.EventHandler(this.buttonFindNext_Click);
            // 
            // buttonFindCancel
            // 
            this.buttonFindCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonFindCancel.Location = new System.Drawing.Point(315, 78);
            this.buttonFindCancel.Name = "buttonFindCancel";
            this.buttonFindCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonFindCancel.TabIndex = 2;
            this.buttonFindCancel.Text = "Cancel";
            this.buttonFindCancel.UseVisualStyleBackColor = true;
            this.buttonFindCancel.Click += new System.EventHandler(this.buttonFindCancel_Click);
            // 
            // checkBoxCase
            // 
            this.checkBoxCase.AutoSize = true;
            this.checkBoxCase.Location = new System.Drawing.Point(12, 109);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(82, 17);
            this.checkBoxCase.TabIndex = 3;
            this.checkBoxCase.Text = "Match case";
            this.checkBoxCase.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Find what";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonDown);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(175, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 66);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // radioButtonDown
            // 
            this.radioButtonDown.AutoSize = true;
            this.radioButtonDown.Checked = true;
            this.radioButtonDown.Location = new System.Drawing.Point(51, 28);
            this.radioButtonDown.Name = "radioButtonDown";
            this.radioButtonDown.Size = new System.Drawing.Size(53, 17);
            this.radioButtonDown.TabIndex = 1;
            this.radioButtonDown.TabStop = true;
            this.radioButtonDown.Text = "Down";
            this.radioButtonDown.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 28);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(39, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Up";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // Find
            // 
            this.AcceptButton = this.buttonFindNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonFindCancel;
            this.ClientSize = new System.Drawing.Size(410, 147);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxCase);
            this.Controls.Add(this.buttonFindCancel);
            this.Controls.Add(this.buttonFindNext);
            this.Controls.Add(this.textBoxFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Find_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.Button buttonFindNext;
        private System.Windows.Forms.Button buttonFindCancel;
        private System.Windows.Forms.CheckBox checkBoxCase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonDown;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}