using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViveroElSalto.Validations
{
    public class Validations
    {

        public static string ValidateFields(
            string nombreComun,
            string nombreCientifico,
            string tipoPlanta,
            string descripcion,
            string tiempoRiegoStr,
            string cantidadAguaStr,
            string epoca
        )
        {
            if (string.IsNullOrWhiteSpace(nombreComun) || nombreComun.Length < 3 || nombreComun.Length > 100)
            {
                return "El nombre común es obligatorio y debe tener entre 3 y 100 caracteres.";
            }

            if (string.IsNullOrWhiteSpace(nombreCientifico) || nombreCientifico.Length < 10 || nombreCientifico.Length > 150)
            {
                return "El nombre científico es obligatorio y debe tener entre 10 y 150 caracteres.";
            }

            if (string.IsNullOrWhiteSpace(tipoPlanta) ||
                !(new[] { "Herbácea", "Matorral", "Arbusto", "Árbol" }).Contains(tipoPlanta))
            {
                return "El tipo de planta es obligatorio y debe ser uno de los siguientes: Herbácea, Matorral, Arbusto, Árbol.";
            }

            if (!int.TryParse(tiempoRiegoStr, out _))
            {
                return "El tiempo de riego es obligatorio y debe ser un número entero.";
            }

            if (!int.TryParse(cantidadAguaStr, out _))
            {
                return "La cantidad de agua es obligatoria y debe ser un número entero.";
            }

            if (string.IsNullOrWhiteSpace(epoca) ||
                !(new[] { "Verano", "Invierno", "Otoño", "Primavera" }).Contains(epoca))
            {
                return "La época es obligatoria y debe ser uno de los siguientes: Verano, Invierno, Otoño, Primavera.";
            }

            return null;
        }

    }
}
