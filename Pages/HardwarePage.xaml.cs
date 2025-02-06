using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PRKTK030225.Classes;
using PRKTK030225.res;

namespace PRKTK030225.Pages
{
    /// <summary>
    /// Логика взаимодействия для HardwarePage.xaml
    /// </summary>
    public partial class HardwarePage : Page, AddEditRemove<Hardware>
    {
        public List<Hardware> lastState;
        public HardwarePage()
        {
            InitializeComponent();
            HardList.ItemsSource = lastState = Connect.context.Hardware.ToList();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditHardware());
        }

        public void Edit(Hardware item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Hardware[] items)
        {
            throw new NotImplementedException();
        }
    }
}
