using CapaLibreria.Base;
using System;

namespace CapaEntidad
{
    public class Recordatorio:clsBaseEntidad
    {
        clsUsuario _Usuario;
        public clsUsuario Usuario
        {
            get
            {
                _Usuario = _Usuario ?? new clsUsuario();
                return _Usuario;
            }
            set => _Usuario = value;
        }
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


    }
}
