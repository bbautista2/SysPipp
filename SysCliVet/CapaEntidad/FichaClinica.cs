using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class FichaClinica : BaseEntidad
    {
        Propietario _Propietario;
        public Propietario Propietario
        {
            get
            {
                _Propietario = _Propietario ?? new Propietario();
                return _Propietario;
            }
            set => _Propietario = value;
        }

        Mascota _Mascota;
        public Mascota Mascota
        {
            get
            {
                _Mascota = _Mascota ?? new Mascota();
                return _Mascota;
            }
            set => _Mascota = value;
        }

        public tListaVacunas ListaVacunas { get; set; }
        public tListaDesparasitacion ListaDesparasitaciones { get; set; }

        List<Vacuna> lstVacunas;
        public List<Vacuna> LstVacunas
        {
            get
            {
                lstVacunas = lstVacunas ?? new List<Vacuna>();
                return lstVacunas;
            }
            set => lstVacunas = value;
        }

        List<Desparasitacion> lstDesparasitaciones;
        public List<Desparasitacion> LstDesparasitaciones
        {
            get
            {
                lstDesparasitaciones = lstDesparasitaciones ?? new List<Desparasitacion>();
                return lstDesparasitaciones;
            }
            set => lstDesparasitaciones = value;
        }

        public DateTime Fecha { get; set; }
        public String InformacionMedica { get; set; }
        public Int16 MedioAmbiente { get; set; }
        public Int16 TipoDieta { get; set; }
        public String Motivo { get; set; }
        public String Observaciones { get; set; }
        public Int32 NumeroFicha { get; set; }


    }
}
