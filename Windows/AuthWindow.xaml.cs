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
using PRKTK030225.Classes;

namespace PRKTK030225.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
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
            var a = Connect.context.Credentials.Where(x => x.LOGIN == L.Text && x.PASSWD == P.Password).ToList();
            if (a.Count != 0)
            {
                this.Close();
                new MainAccessWindow(a[0].AccessLevel_ID, a[0].LOGIN).Show();
                return;
            }

            MessageBox.Show("Введен неправильный логин или пароль.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.None);
            P.Password = "";
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
