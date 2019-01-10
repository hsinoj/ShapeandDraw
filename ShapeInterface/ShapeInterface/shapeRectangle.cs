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

      /**  public  shapeRectangle(int x,int y,int length,int breadth)
        {
            this.x = x;
            this.y = y;
            this.length = length;
            this.breadth = breadth;
        }**/
        public override void drawShape(Graphics g)
        {
           // throw new NotImplementedException();
            Pen p = new Pen(Color.Red,2);
            SolidBrush b = new SolidBrush(Color.Red);
            g.FillRectangle(b, x, y, length, breadth);
            g.DrawRectangle(p, x, y, length, breadth);

        }

        public override void setData(int[] list)
        {
            //  throw new NotImplementedException();
            x = list[0];
            y =  list[1];
            this.length = list[2];
            this.breadth = list[3];
        }
    }
}
