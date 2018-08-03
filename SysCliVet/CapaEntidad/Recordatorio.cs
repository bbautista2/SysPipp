using CapaLibreria.Base;
using System;

namespace CapaEntidad
{
    public class Recordatorio:BaseEntidad
    {
        Usuario _Usuario;
        public Usuario Usuario
        {
            get
            {
                _Usuario = _Usuario ?? new Usuario();
                return _Usuario;
            }
            set => _Usuario = value;
        }
        Mascota _Mascota;
        public Mascota Mascota
        {
            get
            {
                _Mascota = _Mascota ?? new Mascota();
                return _Mascota;
            }
            set => _Mascota = value;
        }
        public DateTime Fecha { get; set; }
        public String Hora { get; set; }


    }
}
