using CapaLibreria.Base;
using System;

namespace CapaEntidad
{
    public class clsDesparasitacion : clsBaseEntidad
    {
        clsFichaClinica _FichaClinica;
        public clsFichaClinica FichaClinica
        {
            get
            {
                _FichaClinica = _FichaClinica ?? new clsFichaClinica();
                return _FichaClinica;
            }
            set => _FichaClinica = value;
        }

        public DateTime Fecha { get; set; }
        public DateTime FechaDesparasitacion { get; set; }
    }
}
