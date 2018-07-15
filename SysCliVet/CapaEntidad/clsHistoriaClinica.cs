using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class clsHistoriaClinica:clsBaseEntidad
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

        public tListaAnalisis ListaAnalisis { get; set; }
        public tListaTratamientos ListaTratamientos { get; set; }

        public DateTime Fecha;
        public Int32 Temperatura;
        public Boolean Agitacion;
        public String AgitacionDescripcion;
        public Boolean Depresion;
        public String DepresionDescripcion;
        public Int16 Apetito;
        public Int16 CondicionCuerpo;
        public String PesoActual;
        public String PerdidaPeso;
        public String Sintomas;
        public String Descarte;
        public String PresuntivoDefinitivo;
        public String Resultados;
        public Int32 NumeroFicha;

    }
}
