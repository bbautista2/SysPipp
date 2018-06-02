using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CapaLibreria.Base
{
    [Serializable]
    public class clsBase
    {
        #region "Atributos"

        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public Int32 Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public Int32 CreadoPor { get; set; }
        public Int32 ActualizadoPor { get; set; }

        [XmlIgnore()]
        public List<ListaError> Errores { get; set; }

        #endregion

        #region "Constructores"

        public clsBase()
        {
            Errores = new List<ListaError>();
        }

        #endregion

        [Serializable]
        public class ListaError
        {
            public Exception Error { get; set; }
            public String MensajeCliente { get; set; }

            public ListaError()
            {
            }
            public ListaError(Exception error, String mensaje)
            {
                Error = error;
                MensajeCliente = mensaje;
            }

        }
    }
}
