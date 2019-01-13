using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    [TestFixture]
    class testShape
    {
        shapeRectangle r = new shapeRectangle();
        [TestCase]
       
        public void CheckClass()

        {
            int[] a = { 1, 2, 3, 4 };
            Assert.AreEqual(5, r.check(a));
        }
        
        shapeTriangle st = new shapeTriangle();
        [TestCase]
        public void CheckClas()

        {
            int[] b = { 1, 2, 3, 4, 5, 6 };
            Assert.AreEqual(6, st.check(b));
        }

        shapeCircle sc = new shapeCircle();
        [TestCase]
        public void Checkcla()
        {
            int[] c = {1,2,3,4};
            Assert.AreEqual(4, sc.check(c));
        }

    }
}
