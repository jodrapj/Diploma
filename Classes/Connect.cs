using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diploma.res;

namespace Diploma.Classes
{
    internal class Connect
    {
        public static Entities c;
        public static Entities context
        {
            get
            {
                if (c == null)
                    c = new Entities();
                return c;
            }
        }
    }
}
