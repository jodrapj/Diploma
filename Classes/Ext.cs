using Diploma.res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

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
        public static List<object> TypeList = new List<object>()
        {
            new hardware(),
            new hardtype(),
            new personnel(),
            new department(),
            new supplier(),
            new movement(),
            new writeoff(),
            new supply(),
            new repair(),
            new access(),
            new credentials(),
            null
        };
        public static SolidColorBrush passiveButton = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5e6cab"));
        public static SolidColorBrush activeButton = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4153a3"));
    }
}
