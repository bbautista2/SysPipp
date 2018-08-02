using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using MessagingToolkit.QRCode.Codec;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Services;

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
                            nombre = mascota.obtenerNombrePropietario(),
                            email = mascota.Propietario.Email
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

                    if (guardado && !String.IsNullOrEmpty(objCita["emailPropietario"]))
                        CodigoQr_Crear(objCita);

                    if (guardado)
                        return new { correcto = true, mensaje = "Cita guardada correctamente" };
                    else
                        return new { correcto = false, mensaje = "Ha ocurrido un error guardando la Cita" };

                }else
                    return new { correcto = false, mensaje = "Ha ocurrido un error guardando la Cita" };
            }
            catch (Exception)
            {
                return new { correcto = false, mensaje = "Ha ocurrido un error guardando la Cita [1]" };
            }
        }

        [WebMethod]
        public static Object Cita_Eliminar(Int32 id)
        {
            Boolean resultado = false;
            
            try
            {
                clsBaseEntidad baseEntidad = new clsBaseEntidad();
                resultado = clsLogica.Instance.Cita_EliminarPorId(ref baseEntidad, id);
                if (resultado)
                    return new { correcto = true, mensaje = "Cita Eliminada correctamente" };
                else
                    return new { correcto = false, mensaje = "Ha ocurrido un error eliminando la Cita" };
            }
            catch (Exception)
            {
                return new { correcto = false, mensaje = "Ha ocurrido un error eliminando la Cita [1]" };
            }
            
        }

        public static void CodigoQr_Crear(dynamic objCita)
        {

            String url = Config.UrlDomain + "Privado/Mascota/Ver.aspx?i="+ HttpUtility.UrlEncode(clsEncriptacion.Encriptar(objCita["mascotaId"]));
            String telefonoVeterinaria = Config.TelefonoVeterinaria;

            if (objCita["emailPropietario"].IndexOf("@gmail.com") != -1)
            {
                String mensaje = HttpUtility.HtmlDecode("<div style='text-align: center; '><img class='image-res' src='http://intranet.vetpippapets.com/src/mascota/imagenes/logo.jpg' width: 200px; height: 200px; style ='background-color: transparent;'></div><div style='text-align: center; '><br></div><div style='text-align: left;'><br></div><div style='text-align: left;'><b>Fecha:&nbsp;</b>&nbsp; &nbsp; " + objCita["inicio"] + "<img src='cid:{imageQrId}' style='float: right; width: 25%; margin-right: 20px;'></div><div style='text-align: left;'><b>Motivo:</b>&nbsp; &nbsp; " + objCita["motivo"] + "</div><div style='text-align: left;'><br></div><div style='text-align: left;'><b>*Si desea anular la cita, contactarse con el número " + telefonoVeterinaria + "</b></div>");

                Email.EnviarEmailQr(objCita["emailPropietario"], mensaje, "Cita - " + objCita["nombrePropietario"], url);
            }
            else
            {
                QRCodeEncoder qrEncoder = new QRCodeEncoder();
                Bitmap img = qrEncoder.Encode(url);
                System.Drawing.Image imgQr = img;
                String srcImagen = String.Empty;

                using (MemoryStream ms = new MemoryStream())
                {
                    imgQr.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] imagenBytes = ms.ToArray();
                    srcImagen = "data:image/png;base64," + Convert.ToBase64String(imagenBytes);
                }

                String mensaje = HttpUtility.HtmlDecode("<div style='text-align: center; '><img class='image-res' src='http://intranet.vetpippapets.com/src/mascota/imagenes/logo.jpg' width: 200px; height: 200px; style='background-color: transparent; width: 300px; height: 300px; '></div><div style='text-align: center; '><br></div><div style='text-align: left;'><br></div><div style='text-align: left;'><b>Fecha:&nbsp;</b>&nbsp; &nbsp; " + objCita["inicio"] + "<img src='" + srcImagen + "' style='float: right; width: 25%; margin-right: 20px;'></div><div style='text-align: left;'><b>Motivo:</b>&nbsp; &nbsp; " + objCita["motivo"] + "</div><div style='text-align: left;'><br></div><div style='text-align: left;'><b>*Si desea anular la cita, contactarse con el número " + telefonoVeterinaria + "</b></div>");

                Email.EnviarEmail(objCita["emailPropietario"], mensaje, "Cita - " + objCita["nombrePropietario"]);
            }

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
                        title = cita.TipoCita.Nombre + " - " + cita.Mascota.Nombre,
                        start = cita.Fecha,
                        id = cita.Id,
                        mascota = cita.Mascota.Nombre,
                        motivo = cita.Motivo
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