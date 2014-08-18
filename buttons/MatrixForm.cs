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
        private int margin = 3;
        
        private MatrixCellControl[,] labels;
        private ButtonModel button;
        private Matrix matrix;


        public MatrixForm(Matrix matrix, ButtonModel button)
        {
            this.matrix = matrix;
            this.button = button;
            InitializeComponent();
            labels = new MatrixCellControl[Settings.matrixSize, Settings.matrixSize];

            int fontSize = Settings.fontsizes[Array.IndexOf(Settings.cellsizes, matrix.cellsize)];
            int subFontSize = Settings.subTextSizes[Array.IndexOf(Settings.cellsizes, matrix.cellsize)];

            for(int i=0; i<Settings.ranks.Length; i++)
                for (int j = 0; j < Settings.ranks.Length; j++)
                {
                    MatrixCellControl tb = new MatrixCellControl();
                    tb.Text = Settings.ranks[i] + Settings.ranks[j];
                    tb.X = i;
                    tb.Y = j;
                    if (matrix.matrix[i, j] == null || matrix.matrix[i,j].color == null)
                    {
                        if (i < j)
                        {
                            tb.Text = tb.Text + "s";
                        }
                        else if (i > j)
                        {
                            tb.Text = tb.Text + "o";
                        }

                        setDefaultCellColor(tb);
                    }
                    else{
                        tb.BackColor = (Color)matrix.matrix[i, j].color;
                        tb.BorderColor = Settings.selectedCellBorder;
                    }
                    tb.Width = matrix.cellsize;
                    tb.Height = matrix.cellsize;
                    tb.Top = i * matrix.cellsize + i * margin;
                    tb.Left = j * matrix.cellsize + j * margin;
                    if (matrix.matrix[i, j] != null)
                        tb.text = matrix.matrix[i, j].text;
                    tb.SubFontSize = subFontSize;
                    tb.TextAlign = ContentAlignment.MiddleCenter;
                    tb.ContextMenuStrip = contextMenuStrip1;
                    tb.Font = new Font(tb.Font.FontFamily, fontSize);
                    this.matrixPanel.Controls.Add(tb);
                    tb.Click += tb_Click;
                    labels[i, j] = tb;
                    
                }

            colorBox.BackColor = matrix.color;
            Doresize();
            setSizeCombo();
            this.Left =  matrix.x;
            this.Top = matrix.y;
        }

        private void setSizeCombo()
        {
            comboBox1.SelectedIndex = Array.IndexOf(Settings.cellsizes, matrix.cellsize);
        }

        void tb_Click(object sender, EventArgs e)
        {
            var cell = sender as MatrixCellControl;
            if (cell != null)
            {
                cell.BackColor = Settings.MatrixSelectionColor;
                cell.BorderColor = Settings.selectedCellBorder;
                var mcell = matrix.matrix[cell.X, cell.Y];
                if (mcell == null)
                {
                    mcell = matrix.matrix[cell.X, cell.Y] = new MatrixCell();
                    mcell.color = matrix.color;
                }
                else
                {
                    matrix.matrix[cell.X, cell.Y] = null;
                    setDefaultCellColor(cell);
                }
                
            }
        }

        private void setDefaultCellColor(MatrixCellControl cell)
        {
            if (cell.X < cell.Y)
            {
                cell.BackColor = Color.FromArgb(0xFF, 0xE7, 0xB5);
            }
            else if (cell.X > cell.Y)
            {
                cell.BackColor = Color.FromArgb(0xE7, 0xEF, 0xF7);
            }
            else
            {
                cell.BackColor = Color.FromArgb(0xCE, 0xDE, 0xC6);
            }
        }

        private void colorBox_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = colorBox.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                matrix.color = colorBox.BackColor = Settings.MatrixSelectionColor = colorDialog1.Color;
            }
        }

        private void привязатьМатрицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cell = contextMenuStrip1.SourceControl  as MatrixCellControl;
            Matrix newmatrix;
            if (matrix.matrix[cell.X, cell.Y] == null || matrix.matrix[cell.X, cell.Y].matrix == null)
                newmatrix = new Matrix();
            else
                newmatrix = matrix.matrix[cell.X, cell.Y].matrix;
            var innerform = new MatrixForm(newmatrix, button);
            if (innerform.ShowDialog() == DialogResult.OK)
            {
                if (matrix.matrix[cell.X, cell.Y] == null)
                    matrix.matrix[cell.X, cell.Y] = new MatrixCell();
                matrix.matrix[cell.X, cell.Y].matrix = newmatrix;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            //Screen.FromControl(this).
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            matrix.cellsize = Settings.cellsizes[comboBox1.SelectedIndex];

            Doresize();

            int fontSize = Settings.fontsizes[Array.IndexOf(Settings.cellsizes, matrix.cellsize)];
            int subfontSize = Settings.subTextSizes[Array.IndexOf(Settings.cellsizes, matrix.cellsize)];

            for(int i=0; i<Settings.ranks.Length; i++)
                for (int j = 0; j < Settings.ranks.Length; j++)
                {
                    labels[i, j].Width = labels[i, j].Height = matrix.cellsize;
                    labels[i,j].Top = i * matrix.cellsize + i * margin;
                    labels[i,j].Left = j * matrix.cellsize + j * margin;
                    labels[i, j].Font = new Font(labels[i,j].Font.FontFamily, fontSize);
                    labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    labels[i, j].SubFontSize = subfontSize;
                    
                }
        }

        private void Doresize()
        {
            this.matrixPanel.Width = matrix.cellsize * Settings.matrixSize + (Settings.matrixSize - 1) * margin;
            this.matrixPanel.Height = matrix.cellsize * Settings.matrixSize + (Settings.matrixSize - 1) * margin;
            Width = this.matrixPanel.Width + 50 + label1.Width;
            Height = this.matrixPanel.Height + 50 + okButton.Height;
            
        }

        private void menuItemSetText_Click(object sender, EventArgs e)
        {
            var cell = contextMenuStrip1.SourceControl as MatrixCellControl;

            var textForm = new SetTextForm();
            if (matrix.matrix[cell.X, cell.Y] != null)
                textForm.setText(matrix.matrix[cell.X, cell.Y].text);

            if (textForm.ShowDialog() == DialogResult.OK)
            {
                if (matrix.matrix[cell.X, cell.Y] == null)
                    matrix.matrix[cell.X, cell.Y] = new MatrixCell();
                
                matrix.matrix[cell.X, cell.Y].text = labels[cell.X, cell.Y].text = textForm.retText;
                labels[cell.X, cell.Y].Refresh();
            }

        }

        private void MatrixForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MatrixForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            matrix.x = Location.X;
            matrix.y = Location.Y;
        }

        public void removeOkCancelButtons()
        {
            okButton.Visible = cancelButton.Visible = false;
            btnUnbind.Visible = true;
        }

        private void btnUnbind_Click(object sender, EventArgs e)
        {
            button.matrices.Remove(matrix);
            Close();
        }
    }
}
