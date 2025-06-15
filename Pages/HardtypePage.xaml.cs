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
    /// Логика взаимодействия для HardtypePage.xaml
    /// </summary>
    public partial class HardtypePage : Page, AddEditRemove
    {
        public HardtypePage()
        {
            InitializeComponent();
            Update();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditHardtype());
            Connect.context.SaveChanges();
        }

        public void Edit()
        {
            if (TypeList.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Data.MFrame.Navigate(new AddEdit.AddEditHardtype(TypeList.SelectedItem as hardtype));
            Connect.context.SaveChanges();
        }

        private void Update()
        {
            TypeList.ItemsSource = Connect.context.hardtype.ToList();
        }

        public void Remove()
        {
            if (TypeList.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (hardtype item in TypeList.SelectedItems)
            {
                if (Connect.context.movement.Find(item.hardtype_id) != null || Connect.context.repair.Find(item.hardtype_id) != null
                    || Connect.context.supplier.Find(item.hardtype_id) != null)
                {
                    MessageBox.Show($"Один или несколько выбранных объектов содержатся в другой таблице");
                    return;
                }
            }
            if (MessageBox.Show($"Вы уверены что хотите удалить {TypeList.SelectedItems.Count} {Ext.NumDeclension(TypeList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.hardtype.RemoveRange(TypeList.SelectedItems as List<hardtype>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        public DataGrid GetDataGrid()
        {
            return TypeList;
        }
    }
}
