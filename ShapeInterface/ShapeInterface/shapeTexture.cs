using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    class shapeTexture : abstractShapes
    {
        int x;
        int y;
        int length;
        int breadth;

        public override void drawShape(Graphics g)
        {
          
                Bitmap bitmap = new Bitmap("E:/study/ShapeandDraw/ShapeInterface/ShapeInterface/Resources/lace.png");
                TextureBrush tBrush = new TextureBrush(bitmap);
                Pen texturedPen = new Pen(tBrush);
                Rectangle r = new Rectangle(x, y, length, breadth);
                g.DrawEllipse(texturedPen, r);
           
           

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
