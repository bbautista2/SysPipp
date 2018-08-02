using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class clsMascota : clsBaseEntidad
    {
        clsPropietario _Propietario;
        public clsPropietario Propietario
        {
            get
            {
                _Propietario = _Propietario ?? new clsPropietario();
                return _Propietario;
            }
            set => _Propietario = value;
        }

       
        public String Raza { get; set; }
        public String Color { get; set; }
        public String Especie { get; set; }
        public Int16 Sexo { get; set; }
        public Boolean Intac { get; set; }
        public Boolean Cast { get; set; }
        public String Peso { get; set; }
        public String MarcaDistintiva { get; set; }
        public String Foto { get; set; }

        public String obtenerNombrePropietario() {
            return Nombre + "-" + Propietario.Nombre + ", " + Propietario.Apellidos; 
        }


    }
}
