using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{/// <summary>
/// abstract shape
/// </summary>
 
   public abstract class abstractShapes 
    {
       /// <summary>
       /// draw  shape
       /// </summary>
       /// <param name="g"></param>
        public abstract void drawShape(Graphics g);
        /// <summary>
        /// setting data
        /// </summary>
        /// <param name="list"></param>
        public abstract void setData(int[] list);
    }
}
