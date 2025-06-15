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
    /// Логика взаимодействия для MovementPage.xaml
    /// </summary>
    public partial class MovementPage : Page, AddEditRemove
    {
        public MovementPage()
        {
            InitializeComponent();
            MoveList.ItemsSource = Connect.context.movement.ToList();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditMovement());
        }

        public void Edit()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditMovement(MoveList.SelectedItem as movement));
        }
        private void Update()
        {
            MoveList.ItemsSource = Connect.context.movement.ToList();
        }

        public void Remove()
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить {MoveList.SelectedItems.Count} {Ext.NumDeclension(MoveList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.movement.Remove(MoveList.SelectedItem as movement);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MoveList.ItemsSource = Connect.context.movement.ToList();
        }
    }
}
