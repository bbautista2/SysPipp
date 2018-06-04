using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class clsCita:clsBaseEntidad
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
        public DateTime Fecha { get; set; }
        public String Hora { get; set; }
        clsTipoCita _TipoCita;
        public clsTipoCita TipoCita
        {
            get
            {
                _TipoCita = _TipoCita ?? new clsTipoCita();
                return _TipoCita;
            }
            set => _TipoCita = value;
        }
        public String Motivo { get; set; }


    }
}
