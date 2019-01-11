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

       

        public override void drawShape(Graphics g)
        {
            // throw new NotImplementedException();
            Pen p = new Pen(Color.Black, 2);
            SolidBrush b = new SolidBrush(Color.Black);
            g.DrawEllipse(p, ax, ay, radius1, radius2);

        }

        public override void setData(int[] lists)
        {
            //throw new NotImplementedException();
            ax = lists[0];
            ay = lists[1];
            this.radius1 = lists[2];
            this.radius2 = lists[3];
        }
    }
}
