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
    /// Логика взаимодействия для HardwarePage.xaml
    /// </summary>
    public partial class HardwarePage : Page, AddEditRemove<Hardware>
    {
        public HardwarePage()
        {
            InitializeComponent();
            Update();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditHardware());
            Connect.context.SaveChanges();
        }

        public void Edit()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditHardware(HardList.SelectedItem as Hardware));
        }

        private void Update()
        {
            HardList.ItemsSource = Connect.context.Hardware.ToList();
        }

        public void Remove()
        {
            foreach (var item in HardList.SelectedItems)
            {
                if (Connect.context.Movement.Find(item) != null || Connect.context.Repair.Find(item) != null
                    || Connect.context.Suppliers.Find(item) != null)
                {
                    MessageBox.Show($"Один или несколько выбранных объектов содержатся в другой таблице");
                    return;
                }
            }
            if (MessageBox.Show($"Вы уверены что хотите удалить {HardList.SelectedItems.Count} записей?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.Hardware.RemoveRange(HardList.SelectedItems as List<Hardware>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
