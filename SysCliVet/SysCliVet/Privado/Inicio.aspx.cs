using CapaEntidad;
using CapaLibreria.Base;
using CapaNegocio;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado
{
    public partial class Inicio : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            #region Lista Citas

            BaseEntidad baseEntidad = new BaseEntidad();
            List<Cita> lstCitas = new List<Cita>();
            List<Object> lstObject = new List<Object>();

            lstCitas = Logica.Instance.Cita_ObtenerPorFechaActual(ref baseEntidad);

            if(lstCitas != null)
            {
                foreach (Cita cita in lstCitas)
                {
                    lstObject.Add(new
                    {
                        Mes = cita.Fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")),
                        Dia = cita.Fecha.Day,
                        Paciente = cita.Mascota.Nombre,
                        cita.Motivo
                    });
                }

                hfListadoCitas.Value = (new JavaScriptSerializer()).Serialize(lstObject);
            }

            #endregion

            #region Lista Citas

            List<CapaEntidad.Mascota> lstMascotas = new List<CapaEntidad.Mascota>();
            List<Object> lstObjectCumple = new List<Object>();

            lstMascotas = Logica.Instance.Mascota_ObtenerPorCumpleMesActual(ref baseEntidad);

            if (lstMascotas != null)
            {
                foreach (CapaEntidad.Mascota mascota in lstMascotas)
                {
                    lstObjectCumple.Add(new
                    {
                        Mes = mascota.FechaNacimiento.ToString("MMMM", CultureInfo.CreateSpecificCulture("es")),
                        Dia = mascota.FechaNacimiento.Day,
                        Paciente = mascota.Nombre,
                        Edad = mascota.getEdad()
                    });
                }

                hfListadoCumple.Value = (new JavaScriptSerializer()).Serialize(lstObjectCumple);
            }

            #endregion

            #region Lista Citas

            List<ProductoMovimiento> lstProductos = new List<ProductoMovimiento>();
            List<Object> lstObjectProducto = new List<Object>();

            lstProductos = Logica.Instance.ProductoMovimiento_ObtenerMasVendidos(ref baseEntidad);

            if (lstProductos != null)
            {
                foreach (ProductoMovimiento producto in lstProductos)
                {
                    lstObjectProducto.Add(new
                    {
                        Nombre = producto.Descripcion,
                        Salida = producto.Cantidad * -1,
                    });
                }

                hfListadoProductos.Value = (new JavaScriptSerializer()).Serialize(lstObjectProducto);
            }

            #endregion

        }

    }
}