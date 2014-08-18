using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buttons
{
    public class Settings
    {
        public static String[] ranks = new String[] { "A", "K", "Q", "J", "T", "9", "8", "7", "6", "5", "4", "3", "2" };
        public static int matrixSize = ranks.Length;
        public static MatrixCell[,] maxtrix = new MatrixCell[matrixSize,matrixSize];
        public static Color normalCellBorder = Color.FromArgb(0xC1, 0xC2, 0xC3);
        public static Color selectedCellBorder = Color.FromArgb(200, Color.Black);
        //6BB5FF
        public static Color DefaultMatrixSelectionColor = Color.FromArgb(0xB, 0xB5, 0xFF);
        public static Color MatrixSelectionColor;
        public static int[] cellsizes = new int[] { 30, 40 , 60, 70 };
        public static int[] fontsizes = new int[] { 8, 11, 16, 20 };
        public static int[] subTextSizes = {6, 7, 11, 13};
    }
}
