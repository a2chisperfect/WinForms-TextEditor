using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using RichTextBoxPrintCtrl;


namespace TextEditor
{

    public partial class Form1 : Form
    {
        private Find findForm = null;
        private Replace replaceForm = null;
        public RichTextBoxPrint GetActiveTextBox { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.toolStripButtonPrint.Click += new System.EventHandler(this.btnPrint_Click);
            this.toolStripButtonPriview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            this.toolStripButtonPage.Click += new System.EventHandler(this.btnPageSetup_Click);

            saveFileDialog.Filter = "TXT Files| *.txt| RTF Files| *.rtf";
            openFileDialog.Filter = "TXT Files | *.txt| RTF Files| *.rtf";
            openFileDialog1.Filter = "JPEG Files|*jpg|PNG Files|*png";
            openFileDialog.FilterIndex = 3;
            saveFileDialog.FilterIndex = 3;
            openFileDialog.RestoreDirectory = true;
            openFileDialog1.RestoreDirectory = true;
            this.Icon = Properties.Resources.icon;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(this, new EventArgs());
            foreach (var fontFamily in FontFamily.Families)
            {
                toolStripFontComboBox.Items.Add(fontFamily.Name);
            }
            toolStripFontComboBox.SelectedItem = GetActiveTextBox.Font.Name;
            toolStripComboBoxSize.SelectedItem =(int)GetActiveTextBox.Font.Size;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage test = new TabPage();
            RichTextBoxPrint tmp = new RichTextBoxPrint();
            test.Controls.Add(tmp);
            tmp.Dock = DockStyle.Fill;
            tmp.ContextMenuStrip = contextMenuStrip1;
            tabControl1.TabPages.Add(test);
            test.Text = "new " + tabControl1.TabPages.Count;
            tabControl1.SelectedTab = test;
            GetActiveTextBox = tmp;
            GetActiveTextBox.SelectionChanged += GetActiveTextBox_SelectionChanged;
            GetActiveTextBox.HideSelection = false;
            GetActiveTextBox.KeyPress += GetActiveTextBox_KeyPress;
            GetActiveTextBox.DetectUrls = true;
            GetActiveTextBox.LinkClicked += GetActiveTextBox_LinkClicked;
            GetActiveTextBox.AcceptsTab = true;
        }

        void GetActiveTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        void GetActiveTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                GetActiveTextBox.SelectionFont = GetActiveTextBox.SelectionFont;
            }
        }

       
       void GetActiveTextBox_SelectionChanged(object sender, EventArgs e)
       {
            SetFontStyleToControlButtons();
            toolStripStatusLabelLine.Text = String.Format("Ln: {0}", TextBoxHelper.GetLine(GetActiveTextBox) + 1);
            toolStripStatusLabelCol.Text = String.Format("Col: {0}", TextBoxHelper.GetColumn(GetActiveTextBox) + 1);
        }
        private FontStyle GetFontStyleFromControlButtons()
        {
             
            FontStyle s = new FontStyle();
            if(toolStripButtonBold.Checked)
            {
                s ^= FontStyle.Bold;
            }
            if (toolStripButtonItalic.Checked)
            {
                s ^= FontStyle.Italic;
            }
            if(toolStripButtonstrikeout.Checked)
            {
                 s ^= FontStyle.Strikeout;
            }
            if(toolStripButtonUnderlane.Checked)
            {
                 s ^= FontStyle.Underline;
            }

            return s;
        }
        float tempSize;
        private void SetFontStyleToControlButtons()
        {
            if (GetActiveTextBox.SelectionAlignment == HorizontalAlignment.Center)
            {
                toolStripButtonCenter.Checked = true;
                toolStripButtonRight.Checked = false;
                toolStripButtonLeft.Checked = false;
            }
            else if (GetActiveTextBox.SelectionAlignment == HorizontalAlignment.Left)
            {
                toolStripButtonCenter.Checked = false;
                toolStripButtonRight.Checked = false;
                toolStripButtonLeft.Checked = true;
            }
            else
            {
                toolStripButtonCenter.Checked = false;
                toolStripButtonRight.Checked = true;
                toolStripButtonLeft.Checked = false;
            }

            toolStripButtonBullet.Checked = GetActiveTextBox.SelectionBullet == true ? true : false;

           
            if (GetActiveTextBox.SelectionFont != null)
            {
                toolStripButtonBold.Checked = GetActiveTextBox.SelectionFont.Bold == true ? true : false;
                toolStripButtonItalic.Checked = GetActiveTextBox.SelectionFont.Italic == true ? true : false;
                toolStripButtonUnderlane.Checked = GetActiveTextBox.SelectionFont.Underline == true ? true : false;
                toolStripButtonstrikeout.Checked = GetActiveTextBox.SelectionFont.Strikeout == true ? true : false;
                toolStripFontComboBox.SelectedItem = GetActiveTextBox.SelectionFont.Name;
                toolStripFontComboBox.Text = GetActiveTextBox.SelectionFont.Name;

                if (GetActiveTextBox.SelectionLength < 1)
                {
                    tempSize = GetActiveTextBox.SelectionFont.Size;
                }
                if (GetActiveTextBox.SelectionLength >= 0 && GetActiveTextBox.SelectionFont.Size == tempSize)
                {
                    toolStripComboBoxSize.Text = Math.Round(GetActiveTextBox.SelectionFont.Size).ToString();
                }
                else
                {
                    toolStripComboBoxSize.Text = String.Empty;
                }
            }
            else
            {
                toolStripFontComboBox.Text = String.Empty;
            }
        }

        private void toolStripFontComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            string font = (string)toolStripFontComboBox.SelectedItem;
           
            if(!String.IsNullOrEmpty(font))
            {
                if (GetActiveTextBox.SelectionFont !=null)
                {
                    GetActiveTextBox.SelectionFont = new Font(font, GetActiveTextBox.SelectionFont.Size, GetActiveTextBox.SelectionFont.Style);
                }
                else
                {
                    GetActiveTextBox.SelectionFont = new Font(font, Convert.ToInt32(toolStripComboBoxSize.SelectedItem), GetFontStyleFromControlButtons());
                }
            }
           
            GetActiveTextBox.Focus();

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            GetActiveTextBox = (RichTextBoxPrint)tabControl1.SelectedTab.Controls[0];
            GetActiveTextBox_SelectionChanged(this, new EventArgs());
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    foreach (var page in tabControl1.TabPages)
                    {
                        if ((page as TabPage).Controls[0].Tag != null && (page as TabPage).Controls[0].Tag.ToString() == openFileDialog.FileName)
                        {
                            tabControl1.SelectedTab = (TabPage)page;
                            GetActiveTextBox = (RichTextBoxPrint)tabControl1.SelectedTab.Controls[0];
                            return;
                        }
                    }
                    if (GetActiveTextBox.Tag != null || GetActiveTextBox.Modified == true && !string.IsNullOrEmpty(GetActiveTextBox.Text))
                    {
                        newToolStripMenuItem_Click(this, new EventArgs());
                    }
                    TextBoxHelper.OpenFile(GetActiveTextBox, openFileDialog.FileName);
                    tabControl1.SelectedTab.Text = GetActiveTextBox.Tag.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = tabControl1.SelectedTab.Text;
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    TextBoxHelper.SaveFile(GetActiveTextBox, saveFileDialog.FileName);
                    tabControl1.SelectedTab.Text = GetActiveTextBox.Tag.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty((string)GetActiveTextBox.Tag))
            {
                try
                {
                    TextBoxHelper.SaveFile(GetActiveTextBox, GetActiveTextBox.Tag.ToString());
                    tabControl1.SelectedTab.Text = GetActiveTextBox.Tag.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                saveAsToolStripMenuItem_Click(this, new EventArgs());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(GetActiveTextBox.Modified)
            {
                DialogResult res = MessageBox.Show(this, String.Format("Do you want to save the changes in {0}?",tabControl1.SelectedTab.Text), "TextEditor", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation);
                if(res == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(this, new EventArgs());
                }
                else if(res == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (tabControl1.TabPages.Count > 1)
            {
                int index = tabControl1.SelectedIndex;
                tabControl1.TabPages.RemoveAt(index);
                if (index < tabControl1.TabPages.Count)
                {
                    tabControl1.SelectedIndex = index;
                }
                else
                {
                    tabControl1.SelectedIndex = index - 1;
                }
            }
            else
            {
                GetActiveTextBox.Clear();
                tabControl1.SelectedTab.Text = "new " + tabControl1.TabPages.Count;
                GetActiveTextBox.Tag = null;
                GetActiveTextBox.Modified = false;
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(var tab in tabControl1.TabPages)
            {
                closeToolStripMenuItem_Click(this, new EventArgs());
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (findForm == null && replaceForm == null)
            {
                findForm = new Find();
                findForm.Show();
                findForm.FindClose += form_FindClose;
                findForm.FindClick += form_FindClick;

            }
            else if (findForm != null)
            {
                findForm.Focus();
            }
            else if (replaceForm != null)
            {
                replaceForm.Focus();
            }

        }

        void form_FindClick(object sender, FindEventArgs e)
        {
            int index = TextBoxHelper.Find(GetActiveTextBox, e.template, e.matchCase, e.searchDown);
            if (index < 0)
            {
                GetActiveTextBox.Select(GetActiveTextBox.Text.Length, 0);
                MessageBox.Show((Form)sender, "Can't find " + "\"" + e.template + "\"", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                GetActiveTextBox.Select(index, e.template.Length);
            }
        }

        void form_FindClose(object sender, EventArgs e)
        {
            findForm = null;
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (replaceForm == null && findForm == null)
            {
                replaceForm = new Replace();
                replaceForm.Show();
                replaceForm.ReplaceClose += replaceForm_ReplaceClose;
                replaceForm.FindClick += form_FindClick;
                replaceForm.ReplaceClick += replaceForm_ReplaceClick;
                replaceForm.ReplaceAllClick += replaceForm_ReplaceAllClick;


            }
            else if (replaceForm != null)
            {
                replaceForm.Focus();
            }
            else if (findForm != null)
            {
                findForm.Focus();
            }
        }

        void replaceForm_ReplaceAllClick(object sender, ReplaceEventArgs e)
        {
            TextBoxHelper.ReplaceAll(GetActiveTextBox, e.template, e.newTemplate, e.matchCase);
        }

        void replaceForm_ReplaceClick(object sender, ReplaceEventArgs e)
        {
            TextBoxHelper.Replace(GetActiveTextBox, e.template, e.newTemplate,e.matchCase);
            if (string.IsNullOrEmpty(GetActiveTextBox.SelectedText))
            {
                form_FindClick(sender, new FindEventArgs(e.template, e.matchCase, true));
            }
        }

        void replaceForm_ReplaceClose(object sender, EventArgs e)
        {
            replaceForm = null;
        }

        private void toolStripButtonLeft_Click(object sender, EventArgs e)
        {
            toolStripButtonCenter.Checked = false;
            toolStripButtonRight.Checked = false;
            GetActiveTextBox.SelectionAlignment = HorizontalAlignment.Left;
            toolStripButtonLeft.Checked = !toolStripButtonLeft.Checked;
        }

        private void toolStripButtonCenter_Click(object sender, EventArgs e)
        {
            toolStripButtonRight.Checked = false;
            toolStripButtonLeft.Checked = false;
            GetActiveTextBox.SelectionAlignment = HorizontalAlignment.Center;
            toolStripButtonCenter.Checked = !toolStripButtonCenter.Checked;
        }

        private void toolStripButtonRight_Click(object sender, EventArgs e)
        {
            toolStripButtonCenter.Checked = false;
            toolStripButtonLeft.Checked = false;
            GetActiveTextBox.SelectionAlignment = HorizontalAlignment.Right;
            toolStripButtonRight.Checked = !toolStripButtonRight.Checked;
        }

        private void toolStripButtonBold_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.SelectionFont =
            new Font(
                GetActiveTextBox.SelectionFont,
                GetActiveTextBox.SelectionFont.Style ^ FontStyle.Bold);
            toolStripButtonBold.Checked = !toolStripButtonBold.Checked;
        }

        private void toolStripButtonItalic_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.SelectionFont =
            new Font(
                GetActiveTextBox.SelectionFont,
                GetActiveTextBox.SelectionFont.Style ^ FontStyle.Italic);
            toolStripButtonItalic.Checked = !toolStripButtonItalic.Checked;
        }

        private void toolStripButtonUnderlane_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.SelectionFont =
            new Font(
                GetActiveTextBox.SelectionFont,
                GetActiveTextBox.SelectionFont.Style ^ FontStyle.Underline);
            toolStripButtonUnderlane.Checked = !toolStripButtonUnderlane.Checked;
        }

        private void toolStripButtonstrikeout_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.SelectionFont =
         new Font(
             GetActiveTextBox.SelectionFont,
             GetActiveTextBox.SelectionFont.Style ^ FontStyle.Strikeout);
            toolStripButtonstrikeout.Checked = !toolStripButtonstrikeout.Checked;
        }
        private void toolStripButtonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                GetActiveTextBox.SelectionColor = colorDialog1.Color;
            }
        }

        private int checkPrint;

        private void btnPageSetup_Click(object sender, System.EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
            }

        }

        private void btnPrintPreview_Click(object sender, System.EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                printDocument1 = printDialog1.Document;
                printDocument1.Print();
            }


        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            checkPrint = 0;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Print the content of RichTextBox. Store the last character printed.
            checkPrint = GetActiveTextBox.Print(checkPrint, GetActiveTextBox.TextLength, e);

            // Check for more pages
            if (checkPrint < GetActiveTextBox.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void toolStripButtonBullet_Click(object sender, EventArgs e)
        {
            if (!toolStripButtonBullet.Checked)
            {
                GetActiveTextBox.SelectionBullet = true;
            }
            toolStripButtonBullet.Checked = !toolStripButtonBullet.Checked;


        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip1.Items["deleteToolStripMenuItem"].Enabled = GetActiveTextBox.SelectionLength > 0 ? true : false;
            contextMenuStrip1.Items["cancelToolStripMenuItem"].Enabled = GetActiveTextBox.CanUndo;
            contextMenuStrip1.Items["cutToolStripMenuItem"].Enabled = GetActiveTextBox.SelectionLength > 0 ? true : false;
            contextMenuStrip1.Items["copyToolStripMenuItem"].Enabled = GetActiveTextBox.SelectionLength > 0 ? true : false;
            contextMenuStrip1.Items["pasteToolStripMenuItem"].Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Rtf) == true ? true : false;
            contextMenuStrip1.Items["selectAllToolStripMenuItem"].Enabled = GetActiveTextBox.TextLength > 0 ? true : false;

        }

        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            editToolStripMenuItem.DropDownItems["deleteToolStripMenuItem1"].Enabled = GetActiveTextBox.SelectionLength > 0 ? true : false;
            editToolStripMenuItem.DropDownItems["undoToolStripMenuItem"].Enabled = GetActiveTextBox.CanUndo;
            editToolStripMenuItem.DropDownItems["cutToolStripMenuItem1"].Enabled = GetActiveTextBox.SelectionLength > 0 ? true : false;
            editToolStripMenuItem.DropDownItems["copyToolStripMenuItem1"].Enabled = GetActiveTextBox.SelectionLength > 0 ? true : false;
            editToolStripMenuItem.DropDownItems["pasteToolStripMenuItem1"].Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Rtf) == true ? true : false;
            editToolStripMenuItem.DropDownItems["selectAllToolStripMenuItem1"].Enabled = GetActiveTextBox.TextLength > 0 ? true : false;


        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.SelectedRtf = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.Undo();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetActiveTextBox.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = GetActiveTextBox.SelectionFont;
            
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                GetActiveTextBox.SelectionFont = fontDialog1.Font;
                toolStripComboBoxSize.Text = Convert.ToString((int)fontDialog1.Font.Size);
                toolStripFontComboBox.SelectedItem = fontDialog1.Font.Name;
                GetActiveTextBox_SelectionChanged(this, new EventArgs());
            }
        }

        private void toolStripComboBoxSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetActiveTextBox.SelectionFont = new Font(GetActiveTextBox.SelectionFont.Name, Convert.ToInt32(((ToolStripComboBox)sender).SelectedItem), GetActiveTextBox.SelectionFont.Style);
            GetActiveTextBox.Focus(); 
        }

        private void toolStripComboBoxSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                float size = 0;
                try
                {
                    size = Convert.ToSingle(((ToolStripComboBox)sender).Text);
                    if (size >= 2 && size <= 100)
                    {

                        GetActiveTextBox.SelectionFont = new Font(GetActiveTextBox.SelectionFont.Name, size, GetActiveTextBox.SelectionFont.Style);

                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Value must be between 1 and 100", "TextEditor", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((ToolStripComboBox)sender).Text = Convert.ToString(Convert.ToInt32(GetActiveTextBox.SelectionFont.Size));
                }
                GetActiveTextBox.Focus(); 
            }
            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout form = new FormAbout();
            form.ShowDialog();
        }

        private void toolStripButtonImage_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if(!TextBoxHelper.PasteImage(GetActiveTextBox,openFileDialog1.FileName))
                {
                    MessageBox.Show(this,"The data format that you attempted to paste is not supported by this control.");
                }
            }

        }

        





      
    }
}
