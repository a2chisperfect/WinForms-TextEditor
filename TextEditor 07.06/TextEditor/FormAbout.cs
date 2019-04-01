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
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            lblProductName.Text = String.Format("Product name: {0}", Application.ProductName);
            lblVerison.Text = String.Format("Version {0}", Application.ProductVersion);
            lblCopyright.Text = "Copyright ©  2017";
        }
    }
}
