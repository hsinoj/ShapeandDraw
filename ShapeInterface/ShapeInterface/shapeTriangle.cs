using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    class shapeTriangle : abstractShapes
    {
       
        int p1;
        int p2;
        int p3;
        int p4;
        int p5;
        int p6;
        /// <summary>
        /// graphics is created
        /// pen instance is used to draw border for shape
        /// </summary>
        /// <param name="g">with the help of graphic object rectangle is drawn</param>
        public override void drawShape(Graphics g)
        {
            //throw new NotImplementedException();
            Pen pp = new Pen(Color.Gray);//triable is create
           
            Point[] p = new Point[3];
            p[0] = new Point(p1, p2);
            p[1] = new Point(p3, p4);
            p[2] = new Point(p5, p6);
          
            g.DrawPolygon(pp,p);//triangle is drawn

        }

        /// <summary>
        /// setting data into parameter
        /// parameter are enlisted in array format
        /// this is used for same variable
        /// </summary>
        /// <param name="list">variable is instantiate so every value can pass thorugh it</param>
        public override void setData(int[] list)
        {
            //throw new NotImplementedException();
            if (check(list) == 6)
            {
                p1 = list[0];
                p2 = list[1];
                p3 = list[2];
                p4 = list[3];
                p5 = list[4];
                p6 = list[5];
            }  
        }
        public int check(int[] a)
        {
            return a.Length;
        }
    }
}
