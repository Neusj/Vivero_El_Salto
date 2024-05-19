using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroElSalto.clases
{
    public class PlantaCollection
    {
        public List<Planta> ReadAll()
        {
            var plantas = CommonBC.El_SaltoEntities.vw_ListAllPlantas;
            return getPlantas(plantas.ToList());
        }

        private List<Planta> getPlantas(List<vw_ListAllPlantas> plantas)
        {
            List<Planta> plantasList = new List<Planta>();
            foreach (vw_ListAllPlantas planta in plantas)
            {
                Planta p = new Planta();

                p.Id = planta.Id;
                p.NombreComun = EncryptionHelper.Decrypt(planta.NombreComun, EncryptionHelper.password_to_decryp);
                p.NombreCientifico = EncryptionHelper.Decrypt(planta.NombreCientifico, EncryptionHelper.password_to_decryp);
                p.TipoPlanta = planta.TipoPlanta;
                p.Descripcion = EncryptionHelper.Decrypt(planta.Descripcion, EncryptionHelper.password_to_decryp);
                p.TiempoRiego = planta.TiempoRiego;
                p.CantidadAgua = planta.CantidadAgua;
                p.Epoca = planta.Epoca;
                p.EsVenenosa = planta.EsVenenosa;
                p.EsAutoctona = planta.EsAutoctona;
   
                plantasList.Add(p);
            }

            return plantasList;
        }
    }
}
