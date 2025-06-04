using System.Windows;
using Diploma.Classes;
using Diploma.Windows;

namespace Diploma
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
