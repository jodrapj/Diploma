using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Diploma.Classes;
using Diploma.res;

namespace Diploma.Pages
{
    /// <summary>
    /// Логика взаимодействия для HardwarePage.xaml
    /// </summary>
    public partial class HardwarePage : Page, AddEditRemove
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
            Connect.context.SaveChanges();
        }

        private void Update()
        {
            HardList.ItemsSource = Connect.context.Hardware.ToList();
        }

        public void Remove()
        {
            foreach (Hardware item in HardList.SelectedItems)
            {
                if (Connect.context.Movement.Find(item.HARD_ID) != null || Connect.context.Repair.Find(item.HARD_ID) != null
                    || Connect.context.Suppliers.Find(item.HARD_ID) != null)
                {
                    MessageBox.Show($"Один или несколько выбранных объектов содержатся в другой таблице");
                    return;
                }
            }
            if (MessageBox.Show($"Вы уверены что хотите удалить {HardList.SelectedItems.Count} {Ext.NumDeclension(HardList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
