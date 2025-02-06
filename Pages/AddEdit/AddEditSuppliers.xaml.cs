using System;
using System.Collections.Generic;
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
using PRKTK030225.Classes;
using PRKTK030225.res;

namespace PRKTK030225.Pages.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditSuppliers.xaml
    /// </summary>
    public partial class AddEditSuppliers : Page
    {
        public AddEditSuppliers()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Suppliers a = new Suppliers();
            a = this.DataContext as Suppliers;
            Connect.context.Suppliers.Add(a);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.GoBack();
        }
    }
}
