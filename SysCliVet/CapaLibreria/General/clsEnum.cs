using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLibreria.General
{
    public static class clsEnum
    {

    }

    public enum EnumEstadoUsuario
    {
        Inactive = 0,
        Active = 1
    }

    public enum EnumGeneroMascota
    {
        Macho = 1,
        Hembra = 2
    }

    public enum EnumMedioAmbiente
    {
        ViveSolo = 1,
        OtrosAnimales = 2
    }

    public enum EnumTipoDieta
    {
        ComidaCasera = 1,
        Concentrado = 2,
        Mixto = 3
    }

    public enum EnumTipoBusqueda
    {
        Inexacta = 0,
        Exacta = 1
    }

}
