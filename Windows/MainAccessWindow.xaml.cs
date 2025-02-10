using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using PRKTK030225.Classes;
using PRKTK030225.Pages;
using PRKTK030225.res;

namespace PRKTK030225.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainAccessWindow.xaml
    /// </summary>
    public partial class MainAccessWindow : Window
    {
        ProgressBarWindow progressBarWindow;
        int? accessLevel;
        int currentPage = 0;

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
            pages[3] = new RepairPage();
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
        }

        private void Movement_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 1]);
        }

        private void Personnel_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 2]);
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 3]);
        }
        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pages[currentPage = 4]);
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
