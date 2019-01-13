using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    class shapeRectangle : abstractShapes
    {

        int x;
        int y;
        int length;
        int breadth;
  


        /// <summary>
        /// graphics is created
        /// pen instance is used to draw border for shape
        /// </summary>
        /// <param name="g">with the help of graphic object rectangle is drawn</param>
        public override void drawShape(Graphics g)
        {
           // throw new NotImplementedException();
            Pen p = new Pen(Color.Red,2); //to create borer

            g.DrawRectangle(p, x, y, length, breadth); //rectanlge is created

        }
        /// <summary>
        /// setting data into parameter
        /// parameter are enlisted in array format
        /// this is used for same variable
        /// </summary>
        /// <param name="list">variable is instantiate so every value can pass thorugh it</param>
        public override void setData(int[] list)
        {
            if (check(list) == 4)
            {
                x = list[0]; //value associating and instantiate
                y = list[1];
                this.length = list[2];
                this.breadth = list[3];
            
            }
            //  throw new NotImplementedException();
            
        }

        public int check(int[] b)
        {
            return b.Length;
        }
        
    }
}
