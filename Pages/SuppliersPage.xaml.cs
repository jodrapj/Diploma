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

namespace PRKTK030225.Pages
{
    /// <summary>
    /// Логика взаимодействия для SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page, AddEditRemove
    {
        public SuppliersPage()
        {
            InitializeComponent();
            SuppliersList.ItemsSource = Connect.context.Suppliers.ToList();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditSuppliers());
        }

        public void Edit()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditSuppliers(SuppliersList.SelectedItem as Suppliers));
        }
        private void Update()
        {
            SuppliersList.ItemsSource = Connect.context.Repair.ToList();
        }

        public void Remove()
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить {SuppliersList.SelectedItems.Count} {Ext.NumDeclension(SuppliersList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.Suppliers.RemoveRange(SuppliersList.SelectedItems as List<Suppliers>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SuppliersList.ItemsSource = Connect.context.Suppliers.ToList();
        }
    }
}
