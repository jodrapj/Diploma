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
    /// Логика взаимодействия для RepairPage.xaml
    /// </summary>
    public partial class RepairPage : Page, AddEditRemove
    {
        public RepairPage()
        {
            InitializeComponent();
            RepairList.ItemsSource = Connect.context.Repair.ToList();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditRepair());
        }

        public void Edit()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditRepair(RepairList.SelectedItem as Repair));
        }

        private void Update()
        {
            RepairList.ItemsSource = Connect.context.Repair.ToList();
        }

        public void Remove()
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить {RepairList.SelectedItems.Count} {Ext.NumDeclension(RepairList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.Repair.RemoveRange(RepairList.SelectedItems as List<Repair>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RepairList.ItemsSource = Connect.context.Repair.ToList();
        }
    }
}
