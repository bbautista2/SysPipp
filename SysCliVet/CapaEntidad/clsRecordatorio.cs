using CapaLibreria.Base;
using System;

namespace CapaEntidad
{
    public class clsRecordatorio:clsBase
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

        public DateTime Fecha { get; set; }
        public String Hora { get; set; }


    }
}
