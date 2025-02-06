using System;
using System.Threading;
using System.Windows;
using PRKTK030225.Classes;

namespace PRKTK030225.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainAccessWindow.xaml
    /// </summary>
    public partial class MainAccessWindow : Window
    {
        ProgressBarWindow progressBarWindow;
        int? accessLevel;

        public MainAccessWindow(int accessLevel, string login)
        {
            InitializeComponent();
            this.accessLevel = accessLevel;
            progressBarWindow = new ProgressBarWindow("Закрываем соединение с БД.", "Подождите");
            Data.MFrame = MFrame;
            LoginShowBox.Text = $"Вы вошли как: {login}";
            VersionBox.Text = Data.version;
            Data.MFrame.Navigate(new Pages.MainPage());
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            progressBarWindow.Show();
            e.Cancel = true;
            Connect.context.Database.Connection.Close();
            Environment.Exit(0);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            accessLevel = null;
            new Windows.AuthWindow().Show();
            Connect.context.Database.Connection.Close();
            this.Hide();
        }
    }
}
