using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diploma.Classes.CustomElements
{
    public class CustomDatePicker : DatePicker
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Template.FindName("PART_TextBox", this) is TextBox textBox)
            {
                textBox.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
