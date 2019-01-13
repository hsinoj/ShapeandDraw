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
        /// <summary>
        /// bitmap for image reading
        /// textbrush for brush
        /// rectangle drawing
        /// </summary>
        /// <param name="g"></param>
        public override void drawShape(Graphics g)
        {
            
            Bitmap image1 = (Bitmap)Image.FromFile(@"E:\study\ShapeandDraw\ShapeInterface\ShapeInterface\Resources\lace.bmp", true);
            TextureBrush tBrush = new TextureBrush(image1);
            Pen texturedPen = new Pen(Color.Red);
            Rectangle r = new Rectangle(x, y, length, breadth);
            g.FillEllipse(tBrush, x, y, length, breadth);
            g.DrawEllipse(texturedPen,r);
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
