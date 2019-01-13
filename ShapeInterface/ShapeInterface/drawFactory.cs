using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    class drawFactory
    {
        
      /// <summary>
      /// design pattern is created
      /// dynamically the data is passed
      /// return new isntance if the specific type of shape is selected
      /// to remove space trime is done
      /// getshape method is instantiate where type of shape is passed as paramtere
      /// </summary>
      /// <param name="drawType"></param>
      /// <returns></returns>
        public abstractShapes getShape(String drawType)
        {

            drawType = drawType.ToUpper().Trim();

            if (drawType.Equals("CIRCLE", StringComparison.OrdinalIgnoreCase)) 
            {
                return new shapeCircle(); //creating instance of circle

            }
            else if (drawType.Equals("RECTANGLE", StringComparison.OrdinalIgnoreCase))
            {
                return new shapeRectangle(); //creating instance of rectangle

            }
            else if (drawType.Equals("TRIANGLE", StringComparison.OrdinalIgnoreCase))
            {
                return new shapeTriangle(); //creating instance of rectangle
            }
            else if (drawType.Equals("POLYGON", StringComparison.OrdinalIgnoreCase))
            {
                return new shapePolygon(); //creating instance of polygon
            }
            else if(drawType.Equals("TEXTURE", StringComparison.OrdinalIgnoreCase))
            {
                return new shapeTexture();//creating instane of texture
            }
            else
            {
                    //if we get here then what has been passed in is unknown so throw an appropriate exception
                    System.ArgumentException argEx = new System.ArgumentException("Factory error:  shapes are not exist ");
                    throw argEx;
            }
        }

    }
}
