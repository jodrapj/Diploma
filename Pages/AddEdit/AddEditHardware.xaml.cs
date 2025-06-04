using System.Windows;
using System.Windows.Controls;
using Diploma.Classes;
using Diploma.res;

namespace Diploma.Pages.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditHardware.xaml
    /// </summary>
    public partial class AddEditHardware : Page
    {
        Hardware context;
        public AddEditHardware(Hardware context = null)
        {
            InitializeComponent();
            if (context != null)
            {
                this.DataContext = context;
                this.context = context;
            } else
            {
                this.DataContext = new Hardware();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                context = new Hardware();
                context = this.DataContext as Hardware;
                Connect.context.Hardware.Add(context);
                Connect.context.SaveChanges();
            } else
            {
                var entity = Connect.context.Hardware.Find(context.HARD_ID);
                Connect.context.Entry(entity).CurrentValues.SetValues(context);
            }
            Connect.context.SaveChanges();
            Data.MFrame.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.GoBack();
        }
    }
}
