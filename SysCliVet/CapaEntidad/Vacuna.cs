using CapaLibreria.Base;
using System;
using System.Globalization;

namespace CapaEntidad
{
    public class Vacuna : BaseEntidad
    {
        public DateTime Fecha { get; set; }
        public String SFecha { get; set; }
        public DateTime FechaVacunacion { get; set; }

        public String ObtenerFechaString()
        {
            return Fecha.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        FichaClinica _FichaClinica;
        public FichaClinica FichaClinica
        {
            get
            {
                _FichaClinica = _FichaClinica ?? new FichaClinica();
                return _FichaClinica;
            }
            set => _FichaClinica = value;
        }
    }
}
