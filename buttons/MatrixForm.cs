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
    public partial class MatrixForm : Form
    {
        private int cell_size = 28;
        private int margin = 3;
        private String[] ranks = new String[] { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };
        public MatrixForm()
        {
            InitializeComponent();
            for(int i=0; i<ranks.Length; i++)
                for (int j = 0; j < ranks.Length; j++)
                {
                    Label tb = new Label();
                    tb.Text = ranks[i] + ranks[j];
                    if (i < j)
                    {
                        tb.Text = tb.Text + "s";
                        tb.BackColor = Color.FromArgb(0xFF, 0xE7, 0xB5);
                    }
                    else if (i > j)
                    {
                        tb.Text = tb.Text + "o";
                        tb.BackColor = Color.FromArgb(0xE7, 0xEF, 0xF7);
                    }
                    else
                    {
                        tb.BackColor = Color.FromArgb(0xCE, 0xDE, 0xC6);                        
                    }
                    tb.Width = cell_size;
                    tb.Height = cell_size;
                    tb.Top = i * cell_size + i * margin;
                    tb.Left = j * cell_size + j * margin;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    
                    //tb.
                    this.Controls.Add(tb);
                }
        }
    }
}
