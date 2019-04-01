namespace TextEditor
{
    partial class Replace
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxCase = new System.Windows.Forms.CheckBox();
            this.buttonReplaceFind = new System.Windows.Forms.Button();
            this.buttonReplace = new System.Windows.Forms.Button();
            this.buttonReplaceAll = new System.Windows.Forms.Button();
            this.buttonReplaceCancel = new System.Windows.Forms.Button();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.textBoxReplace = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find what";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Replace with";
            // 
            // checkBoxCase
            // 
            this.checkBoxCase.AutoSize = true;
            this.checkBoxCase.Location = new System.Drawing.Point(15, 116);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(82, 17);
            this.checkBoxCase.TabIndex = 2;
            this.checkBoxCase.Text = "Match case";
            this.checkBoxCase.UseVisualStyleBackColor = true;
            // 
            // buttonReplaceFind
            // 
            this.buttonReplaceFind.Enabled = false;
            this.buttonReplaceFind.Location = new System.Drawing.Point(319, 20);
            this.buttonReplaceFind.Name = "buttonReplaceFind";
            this.buttonReplaceFind.Size = new System.Drawing.Size(75, 23);
            this.buttonReplaceFind.TabIndex = 3;
            this.buttonReplaceFind.Text = "Find Next";
            this.buttonReplaceFind.UseVisualStyleBackColor = true;
            this.buttonReplaceFind.Click += new System.EventHandler(this.buttonReplaceFind_Click);
            // 
            // buttonReplace
            // 
            this.buttonReplace.Enabled = false;
            this.buttonReplace.Location = new System.Drawing.Point(319, 49);
            this.buttonReplace.Name = "buttonReplace";
            this.buttonReplace.Size = new System.Drawing.Size(75, 23);
            this.buttonReplace.TabIndex = 4;
            this.buttonReplace.Text = "Replace";
            this.buttonReplace.UseVisualStyleBackColor = true;
            this.buttonReplace.Click += new System.EventHandler(this.buttonReplace_Click);
            // 
            // buttonReplaceAll
            // 
            this.buttonReplaceAll.Enabled = false;
            this.buttonReplaceAll.Location = new System.Drawing.Point(319, 78);
            this.buttonReplaceAll.Name = "buttonReplaceAll";
            this.buttonReplaceAll.Size = new System.Drawing.Size(75, 23);
            this.buttonReplaceAll.TabIndex = 5;
            this.buttonReplaceAll.Text = "Replace All";
            this.buttonReplaceAll.UseVisualStyleBackColor = true;
            this.buttonReplaceAll.Click += new System.EventHandler(this.buttonReplaceAll_Click);
            // 
            // buttonReplaceCancel
            // 
            this.buttonReplaceCancel.Location = new System.Drawing.Point(319, 107);
            this.buttonReplaceCancel.Name = "buttonReplaceCancel";
            this.buttonReplaceCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonReplaceCancel.TabIndex = 6;
            this.buttonReplaceCancel.Text = "Cancel";
            this.buttonReplaceCancel.UseVisualStyleBackColor = true;
            this.buttonReplaceCancel.Click += new System.EventHandler(this.buttonReplaceCancel_Click);
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(102, 20);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(196, 20);
            this.textBoxFind.TabIndex = 7;
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxFind_TextChanged);
            // 
            // textBoxReplace
            // 
            this.textBoxReplace.Location = new System.Drawing.Point(102, 53);
            this.textBoxReplace.Name = "textBoxReplace";
            this.textBoxReplace.Size = new System.Drawing.Size(196, 20);
            this.textBoxReplace.TabIndex = 8;
            // 
            // Replace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 147);
            this.Controls.Add(this.textBoxReplace);
            this.Controls.Add(this.textBoxFind);
            this.Controls.Add(this.buttonReplaceCancel);
            this.Controls.Add(this.buttonReplaceAll);
            this.Controls.Add(this.buttonReplace);
            this.Controls.Add(this.buttonReplaceFind);
            this.Controls.Add(this.checkBoxCase);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Replace";
            this.Text = "Replace";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Replace_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxCase;
        private System.Windows.Forms.Button buttonReplaceFind;
        private System.Windows.Forms.Button buttonReplace;
        private System.Windows.Forms.Button buttonReplaceAll;
        private System.Windows.Forms.Button buttonReplaceCancel;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.TextBox textBoxReplace;
    }
}