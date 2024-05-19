using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroElSalto.clases
{
    internal class PersitenteLogin: IPersistenteLogin
    {
        public Login getById(int id)
        {
            using (var context = new El_SaltoEntities())
            {
                var userResult = context.sp_GetLoginById(id).FirstOrDefault();
                if (userResult != null)
                {
                    return new Login(userResult.Id, userResult.Username, userResult.Password);
                }
                return null;
            }
        }
    }
}
