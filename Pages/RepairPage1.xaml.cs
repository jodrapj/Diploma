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
using System.Windows.Shapes;

namespace Diploma.Pages
{
    /// <summary>
    /// Логика взаимодействия для RepairPage1.xaml
    /// </summary>
    public partial class RepairPage1 : Window, AddEditRemove
    {
        public RepairPage1()
        {
            InitializeComponent();
            RepairList.ItemsSource = Connect.context.repair.ToList();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditRepair());
        }

        public void Edit()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditRepair(RepairList.SelectedItem as repair));
        }

        private void Update()
        {
            RepairList.ItemsSource = Connect.context.repair.ToList();
        }

        public void Remove()
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить {RepairList.SelectedItems.Count} {Ext.NumDeclension(RepairList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.repair.RemoveRange(RepairList.SelectedItems as List<repair>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RepairList.ItemsSource = Connect.context.repair.ToList();
        }
    }
}
