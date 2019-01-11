using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    /// <summary>
    /// interface is created
    /// this is a parent method
    /// every properties of its is inherited by child clsses
    /// </summary>
    interface Shapes
    {
        
        void setData(int[] list); //setting data
        void drawShape(Graphics g); //drawing method

    }
}
