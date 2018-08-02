using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class clsFichaClinica : clsBaseEntidad
    {
        clsPropietario _Propietario;
        public clsPropietario Propietario
        {
            get
            {
                _Propietario = _Propietario ?? new clsPropietario();
                return _Propietario;
            }
            set => _Propietario = value;
        }

        clsMascota _Mascota;
        public clsMascota Mascota
        {
            get
            {
                _Mascota = _Mascota ?? new clsMascota();
                return _Mascota;
            }
            set => _Mascota = value;
        }

        public tListaVacunas ListaVacunas { get; set; }
        public tListaDesparasitacion ListaDesparasitaciones { get; set; }

        List<clsVacuna> lstVacunas;
        public List<clsVacuna> LstVacunas
        {
            get
            {
                lstVacunas = lstVacunas ?? new List<clsVacuna>();
                return lstVacunas;
            }
            set => lstVacunas = value;
        }

        List<clsDesparasitacion> lstDesparasitaciones;
        public List<clsDesparasitacion> LstDesparasitaciones
        {
            get
            {
                lstDesparasitaciones = lstDesparasitaciones ?? new List<clsDesparasitacion>();
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
