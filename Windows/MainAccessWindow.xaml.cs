using System.Windows;
using PRKTK030225.Classes;

namespace PRKTK030225.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainAccessWindow.xaml
    /// </summary>
    public partial class MainAccessWindow : Window
    {
        public MainAccessWindow(int accessLevel, string login)
        {
            InitializeComponent();
            Data.MFrame = MFrame;
            LoginShowBox.Text = $"Вы вошли как: {login}";
            VersionBox.Text = Data.version;
        }
    }
}
