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
            txtFechaNac.Value = objMascota.FechaNacimiento.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
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
            ImageMain.Src = Config.MascotaRutaVirtual + "imagenes/" + objMascota.Foto;
        }

        public void Message(String title, String text, String tipo)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>Fn_Mensaje('" + title + "', '" + text + "','" + tipo + "');</script>", false);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
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
                FechaNacimiento = Convert.ToDateTime(txtFechaNac.Value, CultureInfo.InvariantCulture)
            };
            try
            {
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

        [WebMethod]
        public static void UploadQR(/*String codigoId*/)
        {
            /*if (String.IsNullOrEmpty(codigoId))
                return;*/

            QRCodeEncoder qrEncoder = new QRCodeEncoder();
            String url = "http://40.121.42.36/Privado/Mascota/Listar.aspx";
            Bitmap img = qrEncoder.Encode(url);
            System.Drawing.Image imgQr = img;
            
            Random ran = new Random();
            String nombreImagen = DateTime.Now.ToString("ddMMyyyyHHmmss") + "_" + ran.Next(0, 10000) + "MascotaQR";
            String resourcePath = Config.PacienteRutaFisica + "imagenes\\" + nombreImagen + ".png";

            if (!Directory.Exists(Config.PacienteRutaFisica + "imagenes\\"))
                Directory.CreateDirectory(Config.PacienteRutaFisica + "imagenes\\");
            

            using (FileStream fs = new FileStream(resourcePath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        imgQr.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        byte[] imagenBytes = ms.ToArray();
                        bw.Write(imagenBytes);
                        bw.Close();
                    }                    
                }
            }
        }

    }
}