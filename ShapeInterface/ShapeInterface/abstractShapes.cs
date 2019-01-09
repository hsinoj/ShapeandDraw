using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
 
    abstract class abstractShapes : Shapes
    {
       
        public abstract void drawShape(Graphics g);
        public abstract void setData(int[] list);
    }
}
