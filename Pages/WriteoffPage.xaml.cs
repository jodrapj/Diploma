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
    /// Логика взаимодействия для WriteoffPage.xaml
    /// </summary>
    public partial class WriteoffPage : Page, AddEditRemove
    {
        public WriteoffPage()
        {
            InitializeComponent();
            Update();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditWriteoff());
            Connect.context.SaveChanges();
        }

        public void Edit()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditWriteoff(WOList.SelectedItem as writeoff));
            Connect.context.SaveChanges();
        }

        private void Update()
        {
            WOList.ItemsSource = Connect.context.writeoff.ToList();
        }

        public void Remove()
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить {WOList.SelectedItems.Count} {Ext.NumDeclension(WOList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.writeoff.RemoveRange(WOList.SelectedItems as List<writeoff>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
