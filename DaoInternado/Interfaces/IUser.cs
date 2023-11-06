using DaoInternado.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaoInternado.Interfaces
{
    internal interface IUser : IBase<User>
    {
        User Get(int id);

    }
}
