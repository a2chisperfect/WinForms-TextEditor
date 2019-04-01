using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{

    public partial class Find : Form
    {
        public event EventHandler FindClose;
        public event EventHandler<FindEventArgs> FindClick;
        public Find()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFind.TextLength > 0)
            {
                buttonFindNext.Enabled = true;
            }
            else
            {
                buttonFindNext.Enabled = false;
            }
        }

        private void buttonFindCancel_Click(object sender, EventArgs e)
        {
            if(FindClose != null)
            {
                FindClose(this,new EventArgs());
            }
            this.Close();
        }
        
        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            if(FindClick != null)
            {
                FindClick(this, new FindEventArgs(textBoxFind.Text,checkBoxCase.Checked,radioButtonDown.Checked));
            }
        }

        private void Find_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (FindClose != null)
            {
                FindClose(this, new EventArgs());
            }
        }
    }
    public class FindEventArgs : EventArgs
    {
        public string template { get;  set; }
        public bool matchCase { get; set; }
        public bool searchDown { get; set; }
        public FindEventArgs(string Template, bool MatchCase, bool SearchDown)
        {
            template = Template;
            matchCase = MatchCase;
            searchDown = SearchDown;
        }
    }
}
