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
    /// Логика взаимодействия для PersonnelPage.xaml
    /// </summary>
    public partial class PersonnelPage : Page, AddEditRemove
    {
        public PersonnelPage()
        {
            InitializeComponent();
            PersonnelList.ItemsSource = Connect.context.Personnel.ToList();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditPersonnel());
        }

        public void Edit()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditPersonnel(PersonnelList.SelectedItem as Personnel));
        }
        private void Update()
        {
            PersonnelList.ItemsSource = Connect.context.Personnel.ToList();
        }

        public void Remove()
        {
            if (MessageBox.Show($"Вы уверены что хотите удалить {PersonnelList.SelectedItems.Count} {Ext.NumDeclension(PersonnelList.SelectedItems.Count, "запись", "записей", "записи")}?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Connect.context.Personnel.RemoveRange(PersonnelList.SelectedItems as List<Personnel>);
            Connect.context.SaveChanges();
            Update();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PersonnelList.ItemsSource = Connect.context.Personnel.ToList();
        }
    }
}
