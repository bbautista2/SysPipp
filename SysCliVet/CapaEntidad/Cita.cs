using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Cita:clsBaseEntidad
    {
        clsMascota _Mascota;
        public clsMascota Mascota
        {
            get
            {
                _Mascota = _Mascota ?? new clsMascota();
                return _Mascota;
            }
            set => _Mascota = value;
        }
        public DateTime Fecha { get; set; }
        public String Hora { get; set; }
        TipoCita _TipoCita;
        public TipoCita TipoCita
        {
            get
            {
                _TipoCita = _TipoCita ?? new TipoCita();
                return _TipoCita;
            }
            set => _TipoCita = value;
        }
        public String Motivo { get; set; }


    }
}
