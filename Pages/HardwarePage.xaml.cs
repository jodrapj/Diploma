using System.Linq;
using System.Windows;
using PRKTK030225.Classes;

namespace PRKTK030225.Pages
{
    /// <summary>
    /// Логика взаимодействия для HardwarePage.xaml
    /// </summary>
    public partial class HardwarePage : Window
    {
        public HardwarePage()
        {
            InitializeComponent();
            HardList.ItemsSource = Connect.context.Hardware.ToList();
        }
    }
}
