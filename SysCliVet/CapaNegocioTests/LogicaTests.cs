using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Tests
{
    [TestClass()]
    public class LogicaTests
    {
        [TestMethod()]
        public void FichaClinica_Guardar()
        {
            BaseEntidad baseEntidad = new BaseEntidad();
            Propietario objPropietario = new Propietario
            {
                Id = 0,
                Nombre = "Kevin",
                Apellidos = "Polo",
                Email = "kepyor@gmail.com",
                Direccion = "Av. Larco #123",
                Celular = "947980589",
                Telefono = "044211630",
                FechaNacimiento = "23/02/1993".ToStringDate(),
                Dni = 73437830,
                Estado = 1
            };
            Mascota objMascota = new Mascota
            {
                Id = 0,
                Nombre = "Tazz",
                FechaNacimiento = "23/07/2014".ToStringDate(),
                Raza = "Sharpei",
                Color = "Marrón",
                Especie = "Canino",
                Sexo = (Int16)EnumGeneroMascota.Macho,
                Intac = true,
                Cast = false,
                Peso = "20 Kg",
                MarcaDistintiva = "Todo marrón",
                Estado = 1
            };

            tListaVacunas ListaVacunas = new tListaVacunas();
            ListaVacunas.Add(new tVacuna
            {
                Id = 0,
                Fecha = "01/07/2018".ToStringDate(),
                Nombre = "Vacuna cuádruple",
                Descripcion = String.Empty,
                Estado = 1
            });
            
            tListaDesparasitacion ListaDesp = new tListaDesparasitacion();

            FichaClinica objFichaClinica = new FichaClinica
            {
                Propietario = objPropietario,
                Fecha = DateTime.ParseExact("01/07/2018 05:55 PM", "dd/MM/yyyy h:mm tt", CultureInfo.InvariantCulture),
                NumeroFicha = 1,
                Mascota = objMascota,
                InformacionMedica = "Alérgico",
                MedioAmbiente = (Int16)EnumMedioAmbiente.OtrosAnimales,
                TipoDieta = (Int16)EnumTipoDieta.Mixto,
                Motivo = "Alergia",
                Observaciones = "",
                ListaVacunas = ListaVacunas,
                ListaDesparasitaciones = ListaDesp,
                Estado = 1
            };

            Boolean resultado = Logica.Instance.FichaClinica_Guardar(ref baseEntidad, objFichaClinica);
            
            Assert.AreEqual(false, resultado);
        }

        [TestMethod()]
        public void Producto_Guardar()
        {
            BaseEntidad baseEntidad = new BaseEntidad();
            Producto objProducto = new Producto
            {
                Id = 0,
                Descripcion = "Vacuna para la rabia",
                Codigo = "SkuVac001",
            };
            objProducto.Categoria.Id = 1;
            objProducto.ProductoMovimiento.Cantidad = 10;
            objProducto.ProductoMovimiento.Descripcion = "Registro";

            Boolean resultado = Logica.Instance.Producto_Guardar(ref baseEntidad, objProducto);

            Assert.AreEqual(false, resultado);
        }

        [TestMethod()]
        public void Propietario_Guardar()
        {
            BaseEntidad baseEntidad = new BaseEntidad();
            Propietario objPropietario = new Propietario();
            objPropietario.Id = 0;
            objPropietario.Dni = 73437830;
            objPropietario.Nombre = "Kevin";
            objPropietario.Email = "kepyor@gmail.com";
            objPropietario.Direccion = "Mantaro #466";
            objPropietario.Telefono = "044449218";
            objPropietario.Celular = "947980589";
            objPropietario.FechaNacimiento = "23/02/1993".ToStringDate();
            objPropietario.Estado = 1;

            Boolean resultado = Logica.Instance.Propietario_Guardar(ref baseEntidad, objPropietario);

            Assert.AreEqual(false, resultado);
        }

    }
}

namespace CapaNegocioTests
{
    class LogicaTests
    {
    }
}
