using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKTK030225
{
    public interface AddEditRemove<T>
    {
        void Add();
        void Edit();
        void Remove();
    }
}
