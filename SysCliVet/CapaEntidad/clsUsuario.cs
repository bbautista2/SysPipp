using System;
using CapaLibreria.Base;

namespace CapaEntidad
{
    [Serializable]
    public class clsUsuario : clsBaseEntidad
    {
        public String PrimerNombre { get; set; }
        public String SegundoNombre { get; set; }
        public String NombreCompleto
        {
            get
            {
                return PrimerNombre + " " + SegundoNombre;
            }
        }
        public String Email { get; set; }

    }
}
