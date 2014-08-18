using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace buttons
{
    public class ButtonModel
    {
        public String name;
        public Color color;
        public int clicked;
        public String image;
        public List<Matrix> matrices;

        public ButtonModel(String name, Color color)
        {
            this.name = name;
            this.color = color;
            matrices = new List<Matrix>();
        }

        public ButtonModel(String name, Color color, int clicked)
        {
            this.name = name;
            this.color = color;
            this.clicked = clicked;
            matrices = new List<Matrix>();
        }

        

        internal string MakeMatrixXml()
        {
            var doc = new XmlDocument();
            var root = doc.CreateNode(XmlNodeType.Element, "matrices", "");
            doc.AppendChild(root);
            foreach (Matrix matrix in matrices)
            {
                var matrixnode = doc.CreateNode(XmlNodeType.Element, "matrix", "");
                root.AppendChild(matrixnode);
                if (matrix != null)
                {
                    matrix.MakeMatrixRec(doc, matrixnode);
                }

            }
            return doc.OuterXml;
        }
    }
}
