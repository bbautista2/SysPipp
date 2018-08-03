using CapaLibreria.Base;
using System;

namespace CapaEntidad
{
    public class HistorialFotografico:BaseEntidad
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

        public String Foto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
