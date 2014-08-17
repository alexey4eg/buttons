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
    public partial class frmHelp : Form
    {
        public frmHelp()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            label1.Text = "ctrl+T - создание вкладки" + Environment.NewLine + "ctrl+B - создание кнопки" + Environment.NewLine +
                "доступно контекстное меню" + Environment.NewLine +"     у кнопки и вкладки";
        }
    }
}
