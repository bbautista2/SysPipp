using CapaLibreria.Base;
using System;

namespace CapaEntidad
{
    public class Desparasitacion : BaseEntidad
    {
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

        public DateTime Fecha { get; set; }
        public String SFecha { get; set; }
        public DateTime FechaDesparasitacion { get; set; }
    }
}
