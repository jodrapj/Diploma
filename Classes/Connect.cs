using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRKTK030225.res;

namespace PRKTK030225.Classes
{
    internal class Connect
    {
        public static MainDBEntities c;
        public static MainDBEntities context
        {
            get
            {
                if (c == null)
                    c = new MainDBEntities();
                return c;
            }
        }
    }
}
