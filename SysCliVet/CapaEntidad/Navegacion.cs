using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Navegacion:BaseEntidad
    {
        public Int32 PadreId { get; set; }
        public String Url { get; set; }
        public Boolean Mostrar { get; set; }
        public Boolean Accesso { get; set; }
    }
}
