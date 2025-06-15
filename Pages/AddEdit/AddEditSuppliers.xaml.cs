using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Diploma.Classes;
using Diploma.res;

namespace Diploma.Pages.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditSuppliers.xaml
    /// </summary>
    public partial class AddEditSuppliers : Page
    {
        supplier context;
        public AddEditSuppliers(supplier context = null)
        {
            InitializeComponent();
            if (context != null)
            {
                this.DataContext = context;
                this.context = context;
            } else
            {
                this.DataContext = context = new supplier();
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                context = new supplier();
                context = this.DataContext as supplier;
                Connect.context.supplier.Add(context);
            }
            else
            {
                var entity = Connect.context.supplier.Find(context.supplier_id);
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
