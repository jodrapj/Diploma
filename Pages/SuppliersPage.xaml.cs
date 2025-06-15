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
using Diploma.Classes;
using Diploma.res;

namespace Diploma.Pages
{
    /// <summary>
    /// Логика взаимодействия для SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page, AddEditRemove
    {
        public SuppliersPage()
        {
            InitializeComponent();
            SuppliersList.ItemsSource = Connect.context.supplier.ToList();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditSuppliers());
        }

        public void Edit()
        {
            if (SuppliersList.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Data.MFrame.Navigate(new AddEdit.AddEditSuppliers(SuppliersList.SelectedItem as supplier));
        }
        private void Update()
        {
            SuppliersList.ItemsSource = Connect.context.supplier.ToList();
        }

        public void Remove()
        {
            if (SuppliersList.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MessageBox.Show($"Вы уверены что хотите удалить {SuppliersList.SelectedItems.Count} {Ext.NumDeclension(SuppliersList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.supplier.RemoveRange(SuppliersList.SelectedItems as List<supplier>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SuppliersList.ItemsSource = Connect.context.supplier.ToList();
        }

        public DataGrid GetDataGrid()
        {
            return SuppliersList;
        }
    }
}
