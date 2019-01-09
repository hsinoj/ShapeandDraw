using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    interface Shapes
    {
        void setData(int[] list);
        void drawShape(Graphics g);

    }
}
