using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    class drawFactory
    {
        
     
        public abstractShapes getShape(String drawType)
        {
           drawType = drawType.Trim();

            if (drawType.Equals("CIRCLE", StringComparison.OrdinalIgnoreCase))
            {
                return new shapeCircle();

            }
            else if (drawType.Equals("RECTANGLE", StringComparison.OrdinalIgnoreCase))
            {
                return new shapeRectangle();

            }
            else if (drawType.Equals("TRIANGLE", StringComparison.OrdinalIgnoreCase))
            {
                return new shapeTriangle();
            }
            else if (drawType.Equals("POLYGON", StringComparison.OrdinalIgnoreCase))
            {
                return new shapePolygon();
            }
            else
            {
               
                    //if we get here then what has been passed in is unknown so throw an appropriate exception
                    System.ArgumentException argEx = new System.ArgumentException("Factory error: " + drawType + " does not exist");
                    throw argEx;
                
                
            }



        }
    }
}
