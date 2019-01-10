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

        public override void drawShape(Graphics g)
        {
            //throw new NotImplementedException();
            Pen pp = new Pen(Color.Gray);
            SolidBrush b = new SolidBrush(Color.Gray);
            Point[] p = new Point[3];
            p[0] = new Point(p1, p2);
            p[1] = new Point(p3, p4);
            p[2] = new Point(p5, p6);
            g.FillPolygon(b,p);
            g.DrawPolygon(pp, p);

        }

        public override void setData(int[] list)
        {
            //throw new NotImplementedException();
             p1 = list[0];
             p2 = list[1];
             p3 = list[2];
             p4 = list[3];
             p5 = list[4];
             p6 = list[5];
        }
    }
}
