//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViveroElSalto
{
    using System;
    
    public partial class sp_GetPlantaById_Result
    {
        public int Id { get; set; }
        public string NombreComun { get; set; }
        public string NombreCientifico { get; set; }
        public string TipoPlanta { get; set; }
        public string Descripcion { get; set; }
        public int TiempoRiego { get; set; }
        public int CantidadAgua { get; set; }
        public string Epoca { get; set; }
        public Nullable<bool> EsVenenosa { get; set; }
        public Nullable<bool> EsAutoctona { get; set; }
    }
}
