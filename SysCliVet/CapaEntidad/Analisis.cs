using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Analisis : BaseEntidad
    {
        HistoriaClinica _HistoriaClinica;
        public HistoriaClinica HistoriaClinica
        {
            get
            {
                _HistoriaClinica = _HistoriaClinica ?? new HistoriaClinica();
                return _HistoriaClinica;
            }
            set => _HistoriaClinica = value;
        }
        public String Resultado { get; set; }
        public Int16 TipoId { get; set; }

    }
}
