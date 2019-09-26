using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PermisoNavegacion:BaseEntidad
    {
       public Int32 PermisoId { get; set; }
       public Int32 NavegacionId { get; set; }
    }
}
