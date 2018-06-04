﻿using System;
using CapaLibreria.Base;

namespace CapaEntidad
{
    [Serializable]
    public class clsUsuario : clsBaseEntidad
    {
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String NombreCompleto
        {
            get
            {
                return Nombres + " " + Apellidos;
            }
        }
        public String Usuario { get; set; }
        public String Contrasena { get; set; }
        public DateTime UltimoAcceso { get; set; }
        public String Email { get; set; }

    }
}
