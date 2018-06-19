﻿using CapaLibreria.Base;
using System;

namespace CapaEntidad
{
    public class clsVacuna : clsBaseEntidad
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

        public String Fecha { get; set; }
        public DateTime FechaVacunacion { get; set; }
    }
}
