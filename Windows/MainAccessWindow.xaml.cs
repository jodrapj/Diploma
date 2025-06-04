using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Diploma.Classes;
using Diploma.Pages;
using Diploma.res;

namespace Diploma.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainAccessWindow.xaml
    /// </summary>
    public partial class MainAccessWindow : Window
    {
        ProgressBarWindow progressBarWindow;
        int? accessLevel;
        int currentPage = 0;

        SolidColorBrush passiveButton = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5e6cab"));
        SolidColorBrush activeButton = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4153a3"));

        Button buffer = new Button();

        object[] pages = new object[5];

        public MainAccessWindow(int accessLevel, string login)
        {
            InitializeComponent();
            this.accessLevel = accessLevel;
            progressBarWindow = new ProgressBarWindow("Закрываем соединение с БД.", "Подождите");
            Data.MFrame = MFrame;
            LoginShowBox.Text = $"Вы вошли как: {login}";
            VersionBox.Text = Data.version;
            pages[0] = new HardwarePage();
            pages[1] = new MovementPage();
            pages[2] = new PersonnelPage();
            pages[3] = new RepairPage1();
            pages[4] = new SuppliersPage();
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
            progressBarWindow.Show();
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i] = null;
            }
            new Windows.AuthWindow().Show();
            Connect.context.Database.Connection.Close();
            this.Hide();
            progressBarWindow.Close();
        }

        private void Hardware_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 0]);
            buffer.Background = passiveButton;
            (sender as Button).Background = activeButton;
            buffer = sender as Button;
        }

        private void Movement_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 1]);
            buffer.Background = passiveButton;
            (sender as Button).Background = activeButton;
            buffer = sender as Button;
        }

        private void Personnel_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 2]);
            buffer.Background = passiveButton;
            (sender as Button).Background = activeButton;
            buffer = sender as Button;
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 3]);
            buffer.Background = passiveButton;
            (sender as Button).Background = activeButton;
            buffer = sender as Button;
        }
        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 4]);
            buffer.Background = passiveButton;
            (sender as Button).Background = activeButton;
            buffer = sender as Button;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            (pages[currentPage] as AddEditRemove).Edit();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            (pages[currentPage] as AddEditRemove).Remove();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            (pages[currentPage]as AddEditRemove).Add();
        }
    }
}
