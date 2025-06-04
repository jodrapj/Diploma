using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.Classes
{
    public static class Ext
    {
        public static string NumDeclension(int number, string nominative, string plural, string genitive = null)
        {
            if (string.IsNullOrEmpty(genitive))
            {
                return number == 1 ? nominative : plural;
            }

            var titles = new[] { nominative, genitive, plural };
            var cases = new[] { 2, 0, 1, 1, 1, 2 };
            return titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
        }
    }
}
