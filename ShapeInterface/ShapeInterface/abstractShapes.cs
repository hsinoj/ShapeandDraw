using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
 
   public abstract class abstractShapes 
    {
       
        public abstract void drawShape(Graphics g);
        public abstract void setData(int[] list);
    }
}
