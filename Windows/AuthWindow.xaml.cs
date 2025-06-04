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
using Diploma.Classes;

namespace Diploma.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        bool v1 = false;

        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var b = new Windows.ProgressBarWindow("Загрузка...", "Подождите");
            b.Show();
            var a = Connect.context.Credentials.Where(x => x.LOGIN == L.Text && x.PASSWD == P.Password).ToList();
            if (a.Count != 0)
            {
                v1 = true;
                this.Close();
                b.Close();
                new MainAccessWindow(a[0].AccessLevel_ID, a[0].LOGIN).Show();
                return;
            }

            b.Close();
            MessageBox.Show("Введен неправильный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.None);
            P.Password = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!v1)
            {
                e.Cancel = true;
                Environment.Exit(0);
            }
        }
    }
}
