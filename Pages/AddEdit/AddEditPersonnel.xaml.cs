using System.Windows;
using System.Windows.Controls;
using Diploma.Classes;
using Diploma.res;

namespace Diploma.Pages.AddEdit
{
    /// <summary>
    /// Логика взаимодействия для AddEditPersonnel.xaml
    /// </summary>
    public partial class AddEditPersonnel : Page
    {
        Personnel context;
        public AddEditPersonnel(Personnel context = null)
        {
            InitializeComponent();
            if (context != null)
            {
                this.DataContext = context;
                this.context = context;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                context = new Personnel();
                context = this.DataContext as Personnel;
                Connect.context.Personnel.Add(context);
            }
            else
            {
                var entity = Connect.context.Personnel.Find(context.Personnel_ID);
                Connect.context.Entry(entity).CurrentValues.SetValues(context);
            }
            Connect.context.SaveChanges();
            Data.MFrame.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.GoBack();
        }
    }
}
