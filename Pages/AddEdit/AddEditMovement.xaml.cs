using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Globalization;
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

namespace Diploma.Pages.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditMovement.xaml
    /// </summary>
    public partial class AddEditMovement : Page
    {
        movement context;
        public AddEditMovement(movement context = null)
        {
            InitializeComponent();
            if (context != null)
            {
                this.DataContext = context;
                this.context = context;
            } else
            {
                this.DataContext = new movement();
            }
            hardwareBox.ItemsSource = Connect.context.hardware.ToList();
            personnelBox.ItemsSource = Connect.context.personnel.ToList();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                context = new movement();
                context = this.DataContext as movement;
                //context.movement_date = 
                Connect.context.movement.Add(context);
                Connect.context.SaveChanges();
            }
            else
            {
                var entity = Connect.context.movement.Find(context.movement_id);
                Connect.context.Entry(entity).CurrentValues.SetValues(context);
            }
            Connect.context.SaveChanges();
            Data.MFrame.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.GoBack();
        }

        private void DPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DPicker.SelectedDate.Value.ToString("G", new CultureInfo("en-US")) == null)
                DPickerTextBox.Text = DateTime.Now.ToString("G", new CultureInfo("en-US"));
            else
                DPickerTextBox.Text = DPicker.SelectedDate.Value.ToString("G", new CultureInfo("en-US"));
            DPickerTextBox.Focus();
            FromBox.Focus();
        }
    }
}
