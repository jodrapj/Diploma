using Diploma.Classes;
using Diploma.res;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Page, AddEditRemove
    {
        public DepartmentPage()
        {
            InitializeComponent();
            Update();
        }

        public void Add()
        {
            if (DepartList.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для редактирования", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Data.MFrame.Navigate(new AddEdit.AddEditDepartment());
            Connect.context.SaveChanges();
        }

        public void Edit()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditDepartment(DepartList.SelectedItem as department));
            Connect.context.SaveChanges();
        }

        private void Update()
        {
            DepartList.ItemsSource = Connect.context.department.ToList();
        }

        public void Remove()
        {
            if (DepartList.SelectedItem == null)
            {
                MessageBox.Show("Выберите элемент для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            foreach (department item in DepartList.SelectedItems)
            {
                if (Connect.context.personnel.Find(item.department_id) != null)
                {
                    MessageBox.Show($"Один или несколько выбранных объектов содержатся в другой таблице");
                    return;
                }
            }
            if (MessageBox.Show($"Вы уверены что хотите удалить {DepartList.SelectedItems.Count} {Ext.NumDeclension(DepartList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.department.Remove(DepartList.SelectedItem as department);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        public DataGrid GetDataGrid()
        {
            return DepartList;
        }
    }
}
