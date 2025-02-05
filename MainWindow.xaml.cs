using System.Windows;
using PRKTK030225.Classes;

namespace PRKTK030225
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Nav.MFrame = MFrame;
        }
    }
}
