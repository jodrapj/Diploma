using Diploma.Classes;
using Diploma.res;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Diploma.Windows
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        int selectedtable = 0;
        object table;
        DataGrid dataGrid;

        public SearchWindow(object table, DataGrid searchin)
        {
            InitializeComponent();
            this.table = table;
            this.dataGrid = searchin;
        }

        private void PopulateCombobox(object table)
        {
            switch (table) {
                case access _:
                    selectedtable = 1;
                    TableCombobox.ItemsSource = access.TableNames;
                    break;
                case credentials _:
                    selectedtable = 2;
                    TableCombobox.ItemsSource = credentials.TableNames;
                    break;
                case department _:
                    selectedtable = 3;
                    TableCombobox.ItemsSource = department.TableNames;
                    break;
                case hardtype _:
                    selectedtable = 4;
                    TableCombobox.ItemsSource = hardtype.TableNames;
                    break;
                case hardware _:
                    selectedtable = 5;
                    TableCombobox.ItemsSource = hardware.TableNames;
                    break;
                case movement _:
                    selectedtable = 6;
                    TableCombobox.ItemsSource = movement.TableNames;
                    break;
                case personnel _:
                    selectedtable = 7;
                    TableCombobox.ItemsSource = personnel.TableNames;
                    break;
                case repair _:
                    selectedtable = 8;
                    TableCombobox.ItemsSource = repair.TableNames;
                    break;
                case supplier _:
                    selectedtable = 9;
                    TableCombobox.ItemsSource = supplier.TableNames;
                    break;
                case supply _:
                    selectedtable = 10;
                    TableCombobox.ItemsSource = supply.TableNames;
                    break;
                case writeoff _:
                    selectedtable = 11;
                    TableCombobox.ItemsSource = writeoff.TableNames;
                    break;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            switch (selectedtable)
            {
                case 0:
                    this.Close();
                    break;
                case 1:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.access.ToList().Where(x => x.access_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.access.ToList().Where(x => x.access_level.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 2:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.credentials.ToList().Where(x => x.cred_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.credentials.ToList().Where(x => x.cred_user.ToString().Contains(SearchBox.Text));
                            break;
                        case 2:
                            dataGrid.ItemsSource = Connect.context.credentials.ToList().Where(x => x.cred_pass.ToString().Contains(SearchBox.Text));
                            break;
                        case 3:
                            dataGrid.ItemsSource = Connect.context.credentials.ToList().Where(x => x.access_id.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 3:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.department.ToList().Where(x => x.department_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.department.ToList().Where(x => x.department_name.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 4:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.hardtype.ToList().Where(x => x.hardtype_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.hardtype.ToList().Where(x => x.hardtype_name.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 5:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.hardware.ToList().Where(x => x.hard_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.hardware.ToList().Where(x => x.hard_name.ToString().Contains(SearchBox.Text));
                            break;
                        case 2:
                            dataGrid.ItemsSource = Connect.context.hardware.ToList().Where(x => x.hard_model.ToString().Contains(SearchBox.Text));
                            break;
                        case 3:
                            dataGrid.ItemsSource = Connect.context.hardware.ToList().Where(x => x.hard_manufacturer.ToString().Contains(SearchBox.Text));
                            break;
                        case 4:
                            dataGrid.ItemsSource = Connect.context.hardware.ToList().Where(x => x.hardtype_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 5:
                            dataGrid.ItemsSource = Connect.context.hardware.ToList().Where(x => x.personnel_id.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 6:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.movement.ToList().Where(x => x.movement_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.movement.ToList().Where(x => x.movement_date.ToString().Contains(SearchBox.Text));
                            break;
                        case 2:
                            dataGrid.ItemsSource = Connect.context.movement.ToList().Where(x => x.movement_from.ToString().Contains(SearchBox.Text));
                            break;
                        case 3:
                            dataGrid.ItemsSource = Connect.context.movement.ToList().Where(x => x.movement_to.ToString().Contains(SearchBox.Text));
                            break;
                        case 4:
                            dataGrid.ItemsSource = Connect.context.movement.ToList().Where(x => x.personnel_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 5:
                            dataGrid.ItemsSource = Connect.context.movement.ToList().Where(x => x.hard_id.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 7:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.personnel.ToList().Where(x => x.personnel_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.personnel.ToList().Where(x => x.personnel_lastname.ToString().Contains(SearchBox.Text));
                            break;
                        case 2:
                            dataGrid.ItemsSource = Connect.context.personnel.ToList().Where(x => x.personnel_name.ToString().Contains(SearchBox.Text));
                            break;
                        case 3:
                            dataGrid.ItemsSource = Connect.context.personnel.ToList().Where(x => x.personnel_patronymic.ToString().Contains(SearchBox.Text));
                            break;
                        case 4:
                            dataGrid.ItemsSource = Connect.context.personnel.ToList().Where(x => x.personnel_title.ToString().Contains(SearchBox.Text));
                            break;
                        case 5:
                            dataGrid.ItemsSource = Connect.context.personnel.ToList().Where(x => x.personnel_phone.ToString().Contains(SearchBox.Text));
                            break;
                        case 6:
                            dataGrid.ItemsSource = Connect.context.personnel.ToList().Where(x => x.personnel_address.ToString().Contains(SearchBox.Text));
                            break;
                        case 7:
                            dataGrid.ItemsSource = Connect.context.personnel.ToList().Where(x => x.department_id.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 8:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.repair.ToList().Where(x => x.repair_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.repair.ToList().Where(x => x.repair_begindate.ToString().Contains(SearchBox.Text));
                            break;
                        case 2:
                            dataGrid.ItemsSource = Connect.context.repair.ToList().Where(x => x.repair_enddate.ToString().Contains(SearchBox.Text));
                            break;
                        case 3:
                            dataGrid.ItemsSource = Connect.context.repair.ToList().Where(x => x.repair_place.ToString().Contains(SearchBox.Text));
                            break;
                        case 4:
                            dataGrid.ItemsSource = Connect.context.repair.ToList().Where(x => x.hard_id.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 9:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.supplier.ToList().Where(x => x.supplier_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.supplier.ToList().Where(x => x.supplier_orgname.ToString().Contains(SearchBox.Text));
                            break;
                        case 2:
                            dataGrid.ItemsSource = Connect.context.supplier.ToList().Where(x => x.supplier_name.ToString().Contains(SearchBox.Text));
                            break;
                        case 3:
                            dataGrid.ItemsSource = Connect.context.supplier.ToList().Where(x => x.supplier_phone.ToString().Contains(SearchBox.Text));
                            break;
                        case 4:
                            dataGrid.ItemsSource = Connect.context.supplier.ToList().Where(x => x.supplier_address.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 10:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.supply.ToList().Where(x => x.supply_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.supply.ToList().Where(x => x.supply_date.ToString().Contains(SearchBox.Text));
                            break;
                        case 2:
                            dataGrid.ItemsSource = Connect.context.supply.ToList().Where(x => x.supplier_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 3:
                            dataGrid.ItemsSource = Connect.context.supply.ToList().Where(x => x.hard_id.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
                case 11:
                    switch (TableCombobox.SelectedIndex)
                    {
                        case 0:
                            dataGrid.ItemsSource = Connect.context.writeoff.ToList().Where(x => x.writeoff_id.ToString().Contains(SearchBox.Text));
                            break;
                        case 1:
                            dataGrid.ItemsSource = Connect.context.writeoff.ToList().Where(x => x.writeoff_date.ToString().Contains(SearchBox.Text));
                            break;
                        case 2:
                            dataGrid.ItemsSource = Connect.context.writeoff.ToList().Where(x => x.writeoff_reason.ToString().Contains(SearchBox.Text));
                            break;
                        case 3:
                            dataGrid.ItemsSource = Connect.context.writeoff.ToList().Where(x => x.hard_id.ToString().Contains(SearchBox.Text));
                            break;
                    }
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateCombobox(table);
        }
    }
}
