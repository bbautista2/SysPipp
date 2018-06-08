using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class clsPropietario : clsBaseEntidad
    {
        public String Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Email { get; set; }

        public String NombreCompleto
        {
            get
            {
                return Nombre + " " + Apellidos;
            }
        }
    }
}
