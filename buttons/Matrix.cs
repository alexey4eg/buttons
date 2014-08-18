using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace buttons
{
    public class Matrix
    {
        public MatrixCell[,] matrix;
        public Color color;
        public int cellsize;
        public int x, y;

        public Matrix()
        {
            matrix = new MatrixCell[Settings.matrixSize, Settings.matrixSize];
            color = Settings.DefaultMatrixSelectionColor;
            cellsize = Settings.cellsizes[3];
        }

        internal void MakeMatrixRec(XmlDocument doc, XmlNode root)
        {
            var attr = doc.CreateAttribute("color");
            attr.Value = color.ToArgb().ToString();
            root.Attributes.Append(attr);
            attr = doc.CreateAttribute("size");
            attr.Value = cellsize.ToString();
            root.Attributes.Append(attr);
            attr = doc.CreateAttribute("x");
            attr.Value = x.ToString();
            root.Attributes.Append(attr);
            attr = doc.CreateAttribute("y");
            attr.Value = y.ToString();
            root.Attributes.Append(attr);
            for (int i = 0; i < Settings.matrixSize; i++)
                for (int j = 0; j < Settings.matrixSize; j++)
                {
                    if (matrix[i, j] != null)
                    {
                        var cellnode = doc.CreateNode(XmlNodeType.Element, "cell", "");
                        attr = doc.CreateAttribute("X");
                        attr.Value = i.ToString();
                        cellnode.Attributes.Append(attr);
                        attr = doc.CreateAttribute("Y");
                        attr.Value = j.ToString();
                        cellnode.Attributes.Append(attr);
                        attr = doc.CreateAttribute("color");
                        attr.Value = ((Color)matrix[i, j].color).ToArgb().ToString();
                        cellnode.Attributes.Append(attr);
                        attr = doc.CreateAttribute("text");
                        attr.Value = matrix[i, j].text;
                        cellnode.Attributes.Append(attr);

                        var matrixnode = doc.CreateNode(XmlNodeType.Element, "matrix", "");
                        if (matrix[i, j].matrix != null)
                        {
                            matrix[i,j].matrix.MakeMatrixRec(doc, matrixnode);
                            cellnode.AppendChild(matrixnode);
                        }
                        root.AppendChild(cellnode);
                    }
                }
        }

        public static Matrix parseMatrixRecursive(XmlNode root)
        {
            try
            {
                var ret = new Matrix();

                if (root.Attributes["color"] != null)
                {
                    ret.color = Color.FromArgb(int.Parse(root.Attributes["color"].Value));
                }
                if (root.Attributes["size"] != null)
                {
                    ret.cellsize = int.Parse(root.Attributes["size"].Value);
                }

                if (root.Attributes["x"] != null)
                {
                    ret.x = int.Parse(root.Attributes["x"].Value);
                }
                if (root.Attributes["y"] != null)
                {
                    ret.y = int.Parse(root.Attributes["y"].Value);
                }

                foreach (XmlNode node in root.ChildNodes)
                {
                    int x = Int32.Parse(node.Attributes["X"].Value);
                    int y = Int32.Parse(node.Attributes["Y"].Value);
                    MatrixCell cell = new MatrixCell();
                    if (node.Attributes["color"] != null)
                    {
                        int color = int.Parse(node.Attributes["color"].Value);
                        cell.color = Color.FromArgb(color);
                    }
                    if (node.Attributes["text"] != null)
                    {
                        cell.text = node.Attributes["text"].Value;
                    }
                    var childMatrix = node.SelectSingleNode("matrix");
                    if (childMatrix != null)
                        cell.matrix = parseMatrixRecursive(childMatrix);

                    ret.matrix[x, y] = cell;
                }
                return ret;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
