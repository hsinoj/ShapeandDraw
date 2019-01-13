using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeInterface
{
    /// <summary>
    /// 
    /// </summary>
   public class errorCatch : Exception
    {/// <summary>
    /// 
    /// </summary>
        public  errorCatch():base("your input command is wrong"){

        }
    }
}
