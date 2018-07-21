using CapaLibreria.Base;
using System;
using System.Globalization;

namespace CapaEntidad
{
    public class clsVacuna : clsBaseEntidad
    {
        public DateTime Fecha { get; set; }
        public String SFecha { get; set; }
        public DateTime FechaVacunacion { get; set; }

        public String ObtenerFechaString()
        {
            return Fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
