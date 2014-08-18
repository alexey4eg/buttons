using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace buttons
{
    public partial class MatrixCellControl : Label
    {
        public Color BorderColor = Color.Black;
        public int X, Y;
        public String text;
        public int SubFontSize = 10;

        public MatrixCellControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = RoundedRectangle.Create(0, 0, Width - 1, Height - 1);
            e.Graphics.DrawPath(new Pen(BorderColor), path);

            if (text != null){
                var font = new Font(Font.FontFamily, SubFontSize);
                SizeF size = e.Graphics.MeasureString(text, font);
                e.Graphics.DrawString(text, font, Brushes.Black, Width - size.Width - 2, Height - size.Height - 1);
            }
        }

    }
}
