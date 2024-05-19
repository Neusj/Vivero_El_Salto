using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroElSalto.clases
{
    public class Planta :IPersistentePlanta
    {
        public int Id { get; set; }
        public string NombreComun { get; set; }
        public string NombreCientifico { get; set; }
        public string TipoPlanta { get; set; }
        public string Descripcion { get; set; }
        public int TiempoRiego { get; set; }
        public int CantidadAgua { get; set; }
        public string Epoca { get; set; }
        public bool EsVenenosa { get; set; }
        public bool EsAutoctona { get; set; }

        public Planta(
            int id,
            string nombreComun, 
            string nombreCientifico, 
            string tipoPlanta, 
            string descripcion,
            int tiempoRiego,
            int cantidadAgua, 
            string epoca,
            bool esVenenosa,
            bool esAutoctona
        )
        {
            Id = id;
            NombreComun = nombreComun;
            NombreCientifico = nombreCientifico;
            TipoPlanta = tipoPlanta;
            Descripcion = descripcion;
            TiempoRiego = tiempoRiego;
            CantidadAgua = cantidadAgua;
            Epoca = epoca;
            EsVenenosa = esVenenosa;
            EsAutoctona = esAutoctona;
        }

        public Planta() { }

        public bool Create()
        {
            try
            {
                CommonBC.El_SaltoEntities.sp_CreatePlanta(
                    this.NombreComun, 
                    this.NombreCientifico,
                    this.TipoPlanta, 
                    this.Descripcion,
                    this.TiempoRiego ,
                    this.CantidadAgua,
                    this.Epoca,
                    this.EsVenenosa,
                    this.EsAutoctona
                );

                CommonBC.El_SaltoEntities.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        bool IPersistentePlanta.Read(int id)
        {
            throw new NotImplementedException();
        }

        bool IPersistentePlanta.getAll()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            try
            {
                CommonBC.El_SaltoEntities.sp_UpdatePlanta(
                    this.Id,
                    this.NombreComun,
                    this.NombreCientifico,
                    this.TipoPlanta,
                    this.Descripcion,
                    this.TiempoRiego,
                    this.CantidadAgua,
                    this.Epoca,
                    this.EsVenenosa,
                    this.EsAutoctona
                );

                CommonBC.El_SaltoEntities.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                CommonBC.El_SaltoEntities.sp_DeletePlantaById(id);
                CommonBC.El_SaltoEntities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
