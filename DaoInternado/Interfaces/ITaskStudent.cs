using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Interfaces
{
    internal interface ITaskStudent : IBase<TaskStudent>
    {
        TaskStudent Get(int id);
    }
}
