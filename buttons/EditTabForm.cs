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
    public partial class EditTabForm : Form
    {
        public Boolean isNew;
        public Color color;

        public EditTabForm()
        {
            InitializeComponent();
        }

        private void NewButtonForm_Load(object sender, EventArgs e)
        {
            if (isNew)
            {
                Text = "Создание вкладки";
                panel.BackColor = Color.White;
            }
            else
            {
                Text = "Редактирование вкладки";
                panel.BackColor = color;
            }
        }

 
        private void btnPickColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = color;
            var res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                panel.BackColor = colorDialog1.Color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void panel_BackColorChanged(object sender, EventArgs e)
        {
            color = panel.BackColor;
        }
    }
}
