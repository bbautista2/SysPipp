using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class clsAnalisis : clsBaseEntidad
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
        public String Resultado { get; set; }

    }
}
