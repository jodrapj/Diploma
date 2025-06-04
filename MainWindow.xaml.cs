using System.Windows;
using PRKTK030225.Classes;
using PRKTK030225.Windows;

namespace PRKTK030225
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            new AuthWindow().Show();
        }
    }
}
