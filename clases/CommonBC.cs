using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroElSalto.clases
{
    internal class CommonBC
    {
        private static El_SaltoEntities _El_SaltoEntities;
        public static El_SaltoEntities El_SaltoEntities
        {
            get
            {
                if (_El_SaltoEntities == null)
                {
                    _El_SaltoEntities = new El_SaltoEntities();
                }
                return _El_SaltoEntities;
            }
        }

        public CommonBC() { }
    }
}

