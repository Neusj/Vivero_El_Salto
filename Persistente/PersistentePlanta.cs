using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using ViveroElSalto.clases;

namespace ViveroElSalto.Persistente
{
    internal class PersistentePlanta
    {
        //public Login getById(int id)
        //{
        //    using (var context = new El_SaltoEntities())
        //    {
        //        var userResult = context.sp_GetLoginById(id).FirstOrDefault();
        //        if (userResult != null)
        //        {
        //            return new Login(userResult.Id, userResult.Username, userResult.Password);
        //        }
        //        return null;
        //    }
        //}

        //public bool create(Planta planta)
        //{
        //    using (var context = new El_SaltoEntities())
        //    {
        //        try
        //        {
        //            context.sp_CreatePlanta(
        //                this.NombreEquipo,
        //                this.CantidadJugadores,
        //                Security.AES_Helper.Encrypt(this.NombreDT, AES_Helper.ENCRYP_KEY),
        //                Security.AES_Helper.Encrypt(this.TipoEquipo, AES_Helper.ENCRYP_KEY),
        //                Security.AES_Helper.Encrypt(this.CapitanEquipo, AES_Helper.ENCRYP_KEY),
        //                this.TieneSub21
        //            );

        //            CommonBC.ModeloEquipo.SaveChanges();

        //            return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("nO SE GUARDOOOOOO", ex);
        //            return false;
        //        }
        //    }


        //}

        

        //bool IPersistentePlanta.Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IPersistentePlanta.getAll()
        //{
        //    throw new NotImplementedException();
        //}

        //bool IPersistentePlanta.Read(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //bool IPersistentePlanta.Update()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
