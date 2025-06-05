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

        object[] pages = new object[11];

        public MainAccessWindow(int accessLevel, string login)
        {
            InitializeComponent();
            this.accessLevel = accessLevel;
            progressBarWindow = new ProgressBarWindow("Закрываем соединение с БД.", "Подождите");
            Data.MFrame = MFrame;
            LoginShowBox.Text = $"Вы вошли как: {login}";
            VersionBox.Text = Data.version;
            pages[0] = new HardwarePage();
            pages[1] = new HardtypePage();
            pages[2] = new PersonnelPage();
            pages[3] = new DepartmentPage();
            pages[4] = new SuppliersPage();
            pages[5] = new MovementPage();
            pages[6] = new WriteoffPage();
            pages[7] = new SupplyPage();
            pages[8] = new RepairPage1();
            pages[9] = new RepairPage1();
            pages[10] = new RepairPage1();
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
            ButtonHighlight(sender, 0);
        }

        private void Hardtype_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 1);
        }

        private void Personnel_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 2);
        }

        private void Department_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 3);
        }

        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 4);
        }

        private void Movement_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 5);
        }

        private void Writeoff_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 6);
        }

        private void Supply_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 7);
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 8);
        }

        private void Creds_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 9);
        }

        private void Access_Click(object sender, RoutedEventArgs e)
        {
            ButtonHighlight(sender, 10);
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

        private void ButtonHighlight(object sender, int pagenum)
        {
            Data.MFrame.Navigate(pages[currentPage = pagenum]);
            buffer.Background = passiveButton;
            (sender as Button).Background = activeButton;
            buffer = sender as Button;
        }
    }
}
