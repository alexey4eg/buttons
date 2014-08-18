using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buttons
{
    public partial class SetTextForm : Form
    {
        public String retText;
        
        public SetTextForm()
        {
            InitializeComponent();
        }

        public void setText(String text)
        {
            textBox1.Text = text;

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            retText = textBox1.Text;
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
