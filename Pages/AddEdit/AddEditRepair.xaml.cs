using Diploma.Classes;
using Diploma.res;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Diploma.Pages.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditRepair.xaml
    /// </summary>
    public partial class AddEditRepair : Page
    {
        repair context;

        public AddEditRepair(repair context = null)
        {
            InitializeComponent();
            if (context != null)
            {
                this.DataContext = context;
                this.context = context;
            } else
            {
                this.DataContext = new repair();
            }
            hardwareBox.ItemsSource = Connect.context.hardware.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                context = new repair();
                context = this.DataContext as repair;
                Connect.context.repair.Add(context);
                Connect.context.SaveChanges();
            }
            else
            {
                var entity = Connect.context.repair.Find(context.repair_id);
                Connect.context.Entry(entity).CurrentValues.SetValues(context);
            }
            Connect.context.SaveChanges();
            Data.MFrame.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void DPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DPickerTextBox.Text = DPicker.SelectedDate.Value.ToString("G", new CultureInfo("en-US"));
            DPickerTextBox.Focus();
            WhereBox.Focus();
        }
        private void DPicker_SelectedDateChanged1(object sender, SelectionChangedEventArgs e)
        {
            DPickerTextBox1.Text = DPicker1.SelectedDate.Value.ToString("G", new CultureInfo("en-US"));
            DPickerTextBox1.Focus();
            WhereBox.Focus();
        }
    }
}
