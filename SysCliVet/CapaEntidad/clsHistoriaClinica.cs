using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class clsHistoriaClinica:clsBase
    {
        clsFichaClinica _FichaClinica;
        public clsFichaClinica FichaClinica
        {
            get
            {
                _FichaClinica = _FichaClinica ?? new clsFichaClinica();
                return _FichaClinica;
            }
            set => _FichaClinica = value;
        }
        public DateTime Fecha;
        public Int32 Temperatura;
        public Boolean Agitacion;
        public Boolean Depresion;
        public String Apetito;
        public String CondicionCuerpo;
        public Decimal PesoActual;
        public String PerdidaPeso;
        public String Sintomas;
        public String Descarte;
        public String PresuntivoDefinitivo;
        public String Observaciones;

    }
}
