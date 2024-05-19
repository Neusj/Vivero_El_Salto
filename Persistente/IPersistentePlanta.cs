using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroElSalto.clases
{
    internal interface IPersistentePlanta
    {
        bool Create();
        bool Read(int id);
        bool getAll();
        bool Update();
        bool Delete(int id);
    }
}
