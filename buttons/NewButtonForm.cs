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
    public partial class NewButtonForm : Form
    {
        public Boolean isNew;
        public String name;
        public Color color;

        public NewButtonForm()
        {
            InitializeComponent();
        }

        private void NewButtonForm_Load(object sender, EventArgs e)
        {
            
            if (isNew)
            {
                Text = "Создание кнопки";
                txtName.Text = "Новая кнопка";
                txtName.BackColor = Color.White;
            }
            else
            {
                Text = "Редактирование кнопки";
                txtName.Text = name;
                txtName.BackColor = color;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            name = txtName.Text;
        }

        private void txtName_BackColorChanged(object sender, EventArgs e)
        {
            color = txtName.BackColor;
            txtName.ForeColor = frmMain.getForeColor(color);
        }

        private void btnPickColor_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = color;
            var res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtName.BackColor = colorDialog1.Color;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
