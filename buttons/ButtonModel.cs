using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buttons
{
    class ButtonModel
    {
        public String name;
        public Color color;
        public int clicked;
        public String image;

        public ButtonModel(String name, Color color)
        {
            this.name = name;
            this.color = color;
        }

        public ButtonModel(String name, Color color, int clicked)
        {
            this.name = name;
            this.color = color;
            this.clicked = clicked;
        }
    }
}
