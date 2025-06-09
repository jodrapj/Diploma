using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Diploma.Classes;
using Diploma.res;

namespace Diploma.Pages.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEdithardware.xaml
    /// </summary>
    public partial class AddEditHardware : Page
    {
        hardware context;
        public AddEditHardware(hardware context = null)
        {
            InitializeComponent();
            if (context != null)
            {
                this.DataContext = context;
                this.context = context;
            } else
            {
                this.DataContext = new hardware();
            }
            hardtypeBox.ItemsSource = Connect.context.hardtype.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                context = new hardware();
                context = this.DataContext as hardware;
                Connect.context.hardware.Add(context);
                Connect.context.SaveChanges();
            } else
            {
                var entity = Connect.context.hardware.Find(context.hard_id);
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
