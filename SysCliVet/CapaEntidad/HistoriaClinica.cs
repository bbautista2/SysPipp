using CapaLibreria.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class HistoriaClinica:BaseEntidad
    {
        FichaClinica _FichaClinica;
        public FichaClinica FichaClinica
        {
            get
            {
                _FichaClinica = _FichaClinica ?? new FichaClinica();
                return _FichaClinica;
            }
            set => _FichaClinica = value;
        }

        public tListaAnalisis ListaAnalisis { get; set; }
        List<Analisis> lstAnalisis;
        public List<Analisis> LstAnalisis
        {
            get
            {
                lstAnalisis = lstAnalisis ?? new List<Analisis>();
                return lstAnalisis;
            }
            set => lstAnalisis = value;
        }

        public tListaTratamientos ListaTratamientos { get; set; }
        List<Tratamiento> lstTratamientos;
        public List<Tratamiento> LstTratamientos
        {
            get
            {
                lstTratamientos = lstTratamientos ?? new List<Tratamiento>();
                return lstTratamientos;
            }
            set => lstTratamientos = value;
        }

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
