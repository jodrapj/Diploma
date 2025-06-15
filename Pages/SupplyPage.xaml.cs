using Diploma.Classes;
using Diploma.res;
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

namespace Diploma.Pages
{
    /// <summary>
    /// Логика взаимодействия для SupplyPage.xaml
    /// </summary>
    public partial class SupplyPage : Page, AddEditRemove
    {
        public SupplyPage()
        {
            InitializeComponent();
            Update();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditSupply());
            Connect.context.SaveChanges();
        }

        public void Edit()
        {
            if (SupplyList.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Data.MFrame.Navigate(new AddEdit.AddEditSupply(SupplyList.SelectedItem as supply));
            Connect.context.SaveChanges();
        }

        private void Update()
        {
            SupplyList.ItemsSource = Connect.context.supply.ToList();
        }

        public void Remove()
        {
            if (SupplyList.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (supply item in SupplyList.SelectedItems)
            {
                if (Connect.context.movement.Find(item.hard_id) != null || Connect.context.repair.Find(item.hard_id) != null
                    || Connect.context.supplier.Find(item.hard_id) != null)
                {
                    MessageBox.Show($"Один или несколько выбранных объектов содержатся в другой таблице");
                    return;
                }
            }
            if (MessageBox.Show($"Вы уверены что хотите удалить {SupplyList.SelectedItems.Count} {Ext.NumDeclension(SupplyList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.supply.RemoveRange(SupplyList.SelectedItems as List<supply>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        public DataGrid GetDataGrid()
        {
            return SupplyList;
        }
    }
}
