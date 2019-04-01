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
    public partial class Replace : Form
    {
        public event EventHandler ReplaceClose;
        public event EventHandler<FindEventArgs> FindClick;
        public event EventHandler<ReplaceEventArgs> ReplaceClick;
        public event EventHandler<ReplaceEventArgs> ReplaceAllClick;
        public Replace()
        {
            InitializeComponent();
        }

        private void buttonReplaceCancel_Click(object sender, EventArgs e)
        {
            if (ReplaceClose != null)
            {
                ReplaceClose(this, new EventArgs());
            }
            this.Close();
        }

        private void Replace_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ReplaceClose != null)
            {
                ReplaceClose(this, new EventArgs());
            }
        }

        private void buttonReplaceFind_Click(object sender, EventArgs e)
        {
            if(FindClick !=null)
            {
                FindClick(this, new FindEventArgs(textBoxFind.Text,checkBoxCase.Checked,true));
            }
        }

        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            if(textBoxFind.TextLength >0)
            {
                buttonReplace.Enabled = true;
                buttonReplaceAll.Enabled = true;
                buttonReplaceFind.Enabled = true;
            }
            else
            {
                buttonReplace.Enabled = false;
                buttonReplaceAll.Enabled = false;
                buttonReplaceFind.Enabled = false;
            }
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            if(ReplaceClick !=null)
            {
                ReplaceClick(this, new ReplaceEventArgs(textBoxFind.Text, textBoxReplace.Text, checkBoxCase.Checked));
            }
        }

        private void buttonReplaceAll_Click(object sender, EventArgs e)
        {
            if (ReplaceAllClick != null)
            {
                ReplaceAllClick(this, new ReplaceEventArgs(textBoxFind.Text, textBoxReplace.Text, checkBoxCase.Checked));
            }
        }
    }
    public class ReplaceEventArgs : EventArgs
    {
        public string template { get; set; }
        public string newTemplate { get; set; }
        public bool matchCase { get; set; }
        public ReplaceEventArgs(string Template,string NewTemplate ,bool MatchCase)
        {
            template = Template;
            matchCase = MatchCase;
            newTemplate = NewTemplate;
        }
    }
}
