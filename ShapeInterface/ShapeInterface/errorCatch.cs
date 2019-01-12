using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
   public class errorCatch : Exception
    {
        public  errorCatch():base("your input command is wrong"){

        }
    }
}
