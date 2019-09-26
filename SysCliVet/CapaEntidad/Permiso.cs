using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class Permiso:BaseEntidad
    {
        List<Navegacion> lstNavegacion;
        public List<Navegacion> LstNavegaciones
        {
            get
            {
                lstNavegacion = LstNavegaciones ?? new List<Navegacion>();
                return lstNavegacion;
            }
            set => lstNavegacion = value;
        }

    }
}
