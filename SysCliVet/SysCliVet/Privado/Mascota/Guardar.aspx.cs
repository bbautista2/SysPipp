using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;

namespace SysCliVet.Privado.Mascota
{
    public partial class Guardar : Page
    {
        public Int32 vsId
        {
            get { return ViewState["ID"] != null ? (Int32)ViewState["ID"] : default(Int32); }
            set { ViewState["ID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtenerInformacion();
            }
        }

        private void ObtenerInformacion()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["i"]))
            {
                String id = clsEncriptacion.Desencriptar(Request.QueryString["i"]);
                if (id != String.Empty)
                {
                    vsId = Convert.ToInt32(id);
                    try
                    {
                        clsBaseEntidad baseEntidad = new clsBaseEntidad();
                        clsMascota objMascota = new clsMascota();
                        objMascota = clsLogica.Instance.Mascota_PorId(ref baseEntidad, vsId);
                        if (objMascota.Id == 0) { Volver(); }
                        MostrarInformacion(objMascota);
                    }
                    catch (Exception ex)
                    {

                    }

                }
                else
                {
                    Volver();
                }
            }
        }

        public void Volver()
        {
            Response.Redirect("Listar.aspx");
        }

        private void MostrarInformacion(clsMascota objMascota)
        {
            txtNombre.Value = objMascota.Nombre;
            txtFechaNac.Value = objMascota.FechaNacimiento.ToStringDate();
            txtRaza.Value = objMascota.Raza;
            txtColor.Value = objMascota.Color;
            txtEspecie.Value = objMascota.Especie;
            rbMacho.Checked = objMascota.Sexo == (Int16)EnumGeneroMascota.Macho;
            rbHembra.Checked = objMascota.Sexo == (Int16)EnumGeneroMascota.Hembra;
            rbIntacSi.Checked = objMascota.Intac;
            rbIntacNo.Checked = !objMascota.Intac;
            rbCastSi.Checked = objMascota.Cast;
            rbCastNo.Checked = !objMascota.Cast;
            txtPeso.Value = objMascota.Peso;
            txtMarcaDist.Value = objMascota.MarcaDistintiva;
            txtPropietario.Value = objMascota.Propietario.Nombre;
            hfPropietarioId.Value = objMascota.Propietario.Id.ToString();
            hfMascotaId.Value = objMascota.Id.ToString();
            ImageMain.Src = Config.MascotaRutaVirtual + "imagenes/" + objMascota.Foto;        
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {            
            try
            {
                clsBaseEntidad baseEntidad = new clsBaseEntidad();
                Boolean resultado = false;
                clsMascota objMascota = new clsMascota
                {
                    Id = vsId,
                    Nombre = txtNombre.Value,
                    Raza = txtRaza.Value,
                    Color = txtColor.Value,
                    Especie = txtEspecie.Value,
                    Peso = txtPeso.Value,
                    MarcaDistintiva = txtMarcaDist.Value,
                    Intac = rbIntacSi.Checked,
                    Cast = rbCastSi.Checked,
                    Foto = hfMain.Value,
                    Sexo = rbMacho.Checked ? (Int16)EnumGeneroMascota.Macho : (Int16)EnumGeneroMascota.Hembra,
                    FechaNacimiento = txtFechaNac.Value.ToStringDate()
                };
                resultado = clsLogica.Instance.Mascota_Guardar(ref baseEntidad, objMascota);
                if (resultado)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"s\"" + ", " + "\"Paciente guardado correctamente\"" + ");</script>", false);
                    ObtenerInformacion();
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando el Paciente\"" + ");</script>", false);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando el Paciente [1]\"" + ");</script>", false);
            }
        }

        protected void btnGenerar_Click(Object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(hfMascotaId.Value))
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"El paciente no existe\"" + ");</script>", false);

                String url = Config.UrlInfoCodigoQr + "Mascota.aspx?i=" + HttpUtility.UrlEncode(clsEncriptacion.Encriptar(hfMascotaId.Value));

                String email = Config.EmailQr;

                if(email.IndexOf("@gmail.com") != -1)
                {
                    String mensaje = @"<html><body><img src='cid:{imageQrId}' /></body></html>";
                    Email.EnviarEmailQr(email, mensaje, "Código QR - Mascota - " + txtNombre.Value, url);
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
                        srcImagen = "data:image/gif;base64," + Convert.ToBase64String(imagenBytes);
                    }
                    String mensaje = @"<html><body><img src='" + srcImagen + "' /></body></html>";
                    Email.EnviarEmail(email, mensaje, "Código QR - Mascota - " + txtNombre.Value);
                }
                

                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"s\"" + ", " + "\"El código Qr del Paciente se ha enviado satisfactoriamente\"" + ");</script>", false);
            }
            catch (Exception)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error enviando el código Qr del Paciente\"" + ");</script>", false);
            }
        }

        //[WebMethod]
        //public static void GenerarCodigoQr(String mascotaId, String nombreMascota)
        //{
        //    //if (String.IsNullOrEmpty(mascotaId))
        //    //    return new { tipo = "e", mensaje = "El paciente no existe" };
            
        //    String url = Config.UrlInfoCodigoQr + "Mascota.aspx?i=" + HttpUtility.UrlEncode(clsEncriptacion.Encriptar(mascotaId));

        //    String mensaje = @"<html><body><img src='cid:{imageQrId}' /></body></html>";
        //    String email = Config.EmailQr;
        //    Boolean success = Email.EnviarEmailQr(email, mensaje, "Código QR - Mascota - " + nombreMascota, url);
        //    //if (success)
        //    //    return new { tipo = "s", mensaje = "El código Qr del Paciente se ha enviado satisfactoriamente" };
        //    //else
        //    //    return new { tipo = "e", mensaje = "Ha ocurrido un error enviando el código Qr del Paciente" };
        //}

    }
}