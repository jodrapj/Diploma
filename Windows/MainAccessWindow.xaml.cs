using System;
using System.Windows;
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

        HardwarePage hPage;
        MovementPage mPage;
        PersonnelPage pPage;
        RepairPage rPage;
        SuppliersPage sPage;

        public MainAccessWindow(int accessLevel, string login)
        {
            InitializeComponent();
            this.accessLevel = accessLevel;
            progressBarWindow = new ProgressBarWindow("Закрываем соединение с БД.", "Подождите");
            Data.MFrame = MFrame;
            LoginShowBox.Text = $"Вы вошли как: {login}";
            VersionBox.Text = Data.version;
            hPage = new HardwarePage();
            mPage = new MovementPage();
            pPage = new PersonnelPage();
            rPage = new RepairPage();
            sPage = new SuppliersPage();
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
            new Windows.AuthWindow().Show();
            Connect.context.Database.Connection.Close();
            hPage = null;
            mPage = null;
            pPage = null;
            rPage = null;
            sPage = null;
            this.Hide();
            progressBarWindow.Close();
        }

        private void Hardware_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(hPage);
            currentPage = 1;
        }

        private void Movement_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(mPage);
            currentPage = 2;
        }

        private void Personnel_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(pPage);
            currentPage = 3;
        }

        private void Suppliers_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(sPage);
            currentPage = 4;
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            Data.MFrame.Navigate(rPage);
            currentPage = 5;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            switch (currentPage)
            {
                case 1:
                    hPage.Edit();
                    break;
                case 2:
                    mPage.Edit();
                    break;
                case 3:
                    pPage.Edit();
                    break;
                case 4:
                    sPage.Edit();
                    break;
                case 5:
                    rPage.Edit();
                    break;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            switch (currentPage)
            {
                case 1:
                    hPage.Remove();
                    break;
                case 2:
                    mPage.Remove();
                    break;
                case 3:
                    pPage.Remove();
                    break;
                case 4:
                    sPage.Remove();
                    break;
                case 5:
                    rPage.Remove();
                    break;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            switch(currentPage)
            {
                case 1:
                    hPage.Add();
                    break;
                case 2:
                    mPage.Add();
                    break;
                case 3:
                    pPage.Add();
                    break;
                case 4:
                    sPage.Add();
                    break;
                case 5:
                    rPage.Add();
                    break;
            }
        }
    }
}
