using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    class shapePolygon : abstractShapes
    {
        int po1,
            po2,
                  po3,
                  po4,
                  po5,
                  po6,
                  po7,
                  po8,
                  po9,po10;

        public override void drawShape(Graphics g)
        {
            // Create pen.
            Pen pp = new Pen(Color.Red);
            SolidBrush b = new SolidBrush(Color.Gray);

            // Create points that define polygon.


          
            Point[] pt = new Point[8];
            pt[0] = new Point(po1, po2);
            pt[1] = new Point(po3, po4);
            pt[2] = new Point(po5, po6);
            pt[3] = new Point(po7, po8);
            pt[4] = new Point(po9, po10);
           

            g.FillPolygon(b, pt);
            g.DrawPolygon(pp, pt);
        }

        public override void setData(int[] list)
        {
            // throw new NotImplementedException();

            po1 = list[0];
            po2 = list[1];
            po3 = list[2];
            po4 = list[3];
            po5 = list[4];
            po6 = list[5];
            po7 = list[6];
            po8 = list[7];
            po9 = list[8];
            po10 = list[9];
           
            

        }
    }
}
