using CapaEntidad;
using CapaLibreria.Base;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Citas
{
    public partial class Ver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { TipoCita_Obtener(); }
        }
        public void TipoCita_Obtener() {
            clsBaseEntidad objBase = new clsBaseEntidad();
            List<TipoCita> lstTiposCita = new List<TipoCita>();
            lstTiposCita = clsLogica.Instance.TipoCita_ObtenerTodo(ref objBase);
                         
                cmbTipoCita.DataTextField = "Nombre";
                cmbTipoCita.DataValueField = "ID";
                cmbTipoCita.DataSource = lstTiposCita;
                cmbTipoCita.DataBind();
            

        }

        [WebMethod]
        public static List<Object> ListaMascotasPorNombre(String nombre)
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            List<clsMascota> listaMascota = new List<clsMascota>();
            List<Object> lista = new List<Object>();
            nombre = nombre == "undefined" ? "" : nombre;
            try
            {               

                listaMascota = clsLogica.Instance.Mascota_PorNombre(ref baseEntidad, nombre);

                if (listaMascota != null && listaMascota.Count > 0)
                {
                    foreach (clsMascota mascota in listaMascota)
                    {
                        lista.Add(new
                        {
                            id = mascota.Id,
                            nombre = mascota.obtenerNombrePropietario()                         
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return lista;
        }

        [WebMethod]
        public static Object Cita_Guardar(dynamic objCita)
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            Object respuesta = new Object();
            Boolean guardado = false;
            Cita cita = new Cita();
            try
            {
               
                if (objCita != null)
                {
                    cita.Motivo = objCita["motivo"];
                    cita.Fecha = Convert.ToDateTime(objCita["inicio"]);
                    cita.Mascota.Id = Convert.ToInt32(objCita["mascotaId"]);
                    cita.TipoCita.Id = Convert.ToInt32(objCita["tipoCita"]);                    

                    guardado = clsLogica.Instance.Cita_Guardar(ref baseEntidad, cita);
                }
               
            }
            catch (Exception ex)
            {
                return null;
            }
            return respuesta;
        }

        [WebMethod]
        public static Object Cita_Listar()
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            List<Cita> lstCitas = new List<Cita>();
            List<Object> lstObject = new List<object>();
            Object objCita;
            try
            {
                lstCitas = clsLogica.Instance.Cita_ObtenerTodo(ref baseEntidad);
                foreach (Cita cita in lstCitas) {
                    objCita = new
                    {
                        title = cita.TipoCita.Descripcion + " - " + cita.Mascota.Nombre,
                        start = cita.Fecha
                     };
                    lstObject.Add(objCita);
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            return lstObject;
        }



    }
}