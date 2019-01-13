using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    class shapeLine : abstractShapes
    {
        int x;
        int y;
        int length;
        int breadth;

        public override void drawShape(Graphics g)
        {
            Pen p = new Pen(Color.Red, 6); //to create borer
        
            g.DrawLine(p, x, y, length, breadth); //rectanlge is created
        }

        public override void setData(int[] list)
        {
            //throw new NotImplementedException();
            x = list[0]; //value associating and instantiate
            y = list[1];
            this.length = list[2];
            this.breadth = list[3];
        }
    }
}
