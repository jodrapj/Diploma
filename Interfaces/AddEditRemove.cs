using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diploma
{
    public interface AddEditRemove
    {
        void Add();
        void Edit();
        void Remove();
        DataGrid GetDataGrid();
    }
}
