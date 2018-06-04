using CapaLibreria.Base;
using System;

namespace CapaEntidad
{
    public class clsHistorialFotografico:clsBaseEntidad
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

        public String Foto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
