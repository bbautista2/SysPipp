using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class clsTratamiento:clsBaseEntidad
    {
        clsHistoriaClinica _HistoriaClinica;
        public clsHistoriaClinica HistoriaClinica
        {
            get
            {
                _HistoriaClinica = _HistoriaClinica ?? new clsHistoriaClinica();
                return _HistoriaClinica;
            }
            set => _HistoriaClinica = value;
        }

        public DateTime FechaTratamiento { get; set; }
        public String SFechaTratamiento { get; set; }
        public String Droga { get; set; }
        public String Dosis { get; set; }
        public String Observacion { get; set; }        
    }
}
