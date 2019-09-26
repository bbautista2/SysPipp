using CapaLibreria.Base;
using System;
using System.Collections.Generic;

namespace CapaEntidad
{
    [Serializable]
    public class Permiso:BaseEntidad
    {
       public List<Navegacion> LstNavegaciones { get; set; }

    }
}
