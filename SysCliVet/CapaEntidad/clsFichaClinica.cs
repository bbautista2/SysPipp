using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class clsFichaClinica : clsBase
    {
        clsPaciente _Paciente;
        public clsPaciente Paciente
        {
            get
            {
                _Paciente = _Paciente ?? new clsPaciente();
                return _Paciente;
            }
            set => _Paciente = value;
        }

        public String MedioAmbiente { get; set; }
        public String TipoDieta { get; set; }
        public String Motivo { get; set; }
        public String Observaciones { get; set; }

    }
}
