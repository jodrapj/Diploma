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
    /// Логика взаимодействия для MovementPage.xaml
    /// </summary>
    public partial class MovementPage : Page, AddEditRemove<Movement>
    {
        public MovementPage()
        {
            InitializeComponent();
            MoveList.ItemsSource = Connect.context.Movement.ToList();
        }

        public void Add()
        {
            Data.MFrame.Navigate(new AddEdit.AddEditMovement());
        }

        public void Edit(Movement item)
        {
            throw new NotImplementedException();
        }

        public void Remove(Movement[] items)
        {
            throw new NotImplementedException();
        }
    }
}
