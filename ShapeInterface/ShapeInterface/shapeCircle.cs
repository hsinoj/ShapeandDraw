using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    class shapeCircle : abstractShapes
    {

        int ax;
        int ay;
        int radius1;
        int radius2;


        /// <summary>
        /// graphics is created
        /// pen instance is used to draw border for shape
        /// </summary>
        /// <param name="g">with the help of graphic object rectangle is drawn</param>
        public override void drawShape(Graphics g)
        {
            // throw new NotImplementedException();
            Pen p = new Pen(Color.Black, 2);//circle border is drawn

            g.DrawEllipse(p, ax, ay, radius1, radius2);//circle is drawn

        }
        /// <summary>
        /// setting data into parameter
        /// parameter are enlisted in array format
        /// this is used for same variable
        /// </summary>
        /// <param name="list">variable is instantiate so every value can pass thorugh it</param>
        public override void setData(int[] lists)
        {
            //throw new NotImplementedException();
            throw new NotImplementedException();
            if (check(lists) == 4)
            {
                ax = lists[0];
                ay = lists[1];
                this.radius1 = lists[2];
                this.radius2 = lists[3];
            }

        }
        public int check(int[] a)
        {
            return a.Length;
        }

    }
}   

