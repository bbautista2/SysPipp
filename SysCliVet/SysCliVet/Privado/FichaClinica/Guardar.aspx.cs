using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.FichaClinica
{
    public partial class Guardar : Page
    {
        public Int32 IdFicha { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardarFicha_Click(object sender, EventArgs e)
        {
            try
            {
                clsBaseEntidad baseEntidad = new clsBaseEntidad();
                Boolean resultado = false;
                clsPropietario objPropietario = new clsPropietario
                {
                    Id = Convert.ToInt32(hfIdPropietario.Value),
                    Nombre = txtNombrePro.Value,
                    Apellidos = txtApellidos.Value,
                    Email = txtEmail.Value,
                    Direccion = txtDireccion.Value,
                    Celular = txtCelular.Value,
                    Telefono = txtTelefono.Value,
                    FechaNacimiento = !String.IsNullOrEmpty(txtFechaNacPro.Value) ? DateTime.ParseExact(txtFechaNacPro.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture) : DateTime.Now,
                    Dni = Convert.ToInt32(txtDni.Value),
                    Estado = 1
                };
                clsMascota objMascota = new clsMascota
                {
                    Id = 0,
                    Nombre = txtNombreMas.Value,
                    FechaNacimiento = DateTime.ParseExact(txtFechaNacMas.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture),//Convert.ToDateTime(txtFechaNacMas.Value, CultureInfo.InvariantCulture),
                    Raza = txtRaza.Value,
                    Color = txtColor.Value,
                    Especie = txtEspecie.Value,
                    Sexo = rbMacho.Checked ? (Int16)EnumGeneroMascota.Macho : (Int16)EnumGeneroMascota.Hembra,
                    Intac = rbIntacSi.Checked ? true : false,
                    Cast = rbCastSi.Checked ? true : false,
                    Peso = txtPeso.Value,
                    MarcaDistintiva = txtMarcaDist.Value,
                    Estado = 1
                };

                JavaScriptSerializer srVacunas = new JavaScriptSerializer();
                List<clsVacuna> lstVacunas = new List<clsVacuna>();
                tListaVacunas ListaVacunas = new tListaVacunas();
                lstVacunas = srVacunas.Deserialize<List<clsVacuna>>(hfVacunas.Value);
                if (lstVacunas != null)
                {
                    foreach (clsVacuna item in lstVacunas)
                    {
                        ListaVacunas.Add(new tVacuna
                        {
                            Id = item.Id,
                            Fecha = item.SFecha.ToStringDate(),
                            Nombre = item.Nombre,
                            Descripcion = String.Empty,
                            Estado = 1
                        });
                    }
                }

                JavaScriptSerializer srDesp = new JavaScriptSerializer();
                List<clsDesparasitacion> lstDesp = new List<clsDesparasitacion>();
                tListaDesparasitacion ListaDesp = new tListaDesparasitacion();
                lstDesp = srDesp.Deserialize<List<clsDesparasitacion>>(hfDesparasitaciones.Value);
                if (lstDesp != null)
                {
                    foreach (clsDesparasitacion item in lstDesp)
                    {
                        ListaDesp.Add(new tDesparasitacion
                        {
                            Id = item.Id,
                            Fecha = item.SFecha.ToStringDate(),
                            Nombre = item.Nombre,
                            Descripcion = String.Empty,
                            Estado = 1
                        });
                    }
                }

                clsFichaClinica objFichaClinica = new clsFichaClinica
                {
                    Propietario = objPropietario,
                    Fecha = DateTime.ParseExact(txtFechaFicha.Value, "dd/MM/yyyy h:mm tt", CultureInfo.InvariantCulture),
                    NumeroFicha = Convert.ToInt32(txtNroFicha.Value),
                    Mascota = objMascota,
                    InformacionMedica = txtInfMedica.Value,
                    MedioAmbiente = rbViveSolo.Checked ? (Int16)EnumMedioAmbiente.ViveSolo : (Int16)EnumMedioAmbiente.OtrosAnimales,
                    TipoDieta = rbComidaCasera.Checked ? (Int16)EnumTipoDieta.ComidaCasera : rbConcentrado.Checked ? (Int16)EnumTipoDieta.Concentrado : (Int16)EnumTipoDieta.Mixto,
                    Motivo = txtMotivoCons.Value,
                    Observaciones = txtObservacion.Value,
                    ListaVacunas = ListaVacunas,
                    ListaDesparasitaciones = ListaDesp,
                    Estado = 1
                };

                resultado = clsLogica.Instance.FichaClinica_Guardar(ref baseEntidad, objFichaClinica);
                if (resultado)
                {
                    String id = HttpUtility.UrlEncode(clsEncriptacion.Encriptar(objFichaClinica.NumeroFicha.ToString()));
                    Response.Redirect("~/Privado/HistorialClinico/Guardar.aspx?nf=" + id + "&s=si");
                }
                else ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando la Ficha Clínica\"" + ");</script>", false);
            }
            catch (Exception ex) {
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando la Ficha Clínica\"" + ");</script>", false);
            }
        }

        [WebMethod]
        public static List<Object> ListaPropietariosPorDni(String dni)
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            List<Object> lista = new List<Object>();
            dni = dni == "undefined" ? "" : dni;
            try
            {
                Int16 tipo;
                var longitud = dni != "" ? dni.Length : 0;
                if (longitud == 8)
                    tipo = (Int16)EnumTipoBusqueda.Exacta;
                else
                    tipo = (Int16)EnumTipoBusqueda.Inexacta;

                DataTable dtPropietarios = clsLogica.Instance.Propietario_ObtenerPorDni(ref baseEntidad, dni, tipo);

                if (dtPropietarios != null && dtPropietarios.Rows.Count > 0)
                {
                    foreach (DataRow item in dtPropietarios.Rows)
                    {
                        lista.Add(new
                        {
                            Id = item["Id"].ToString(),
                            Dni = item["Dni"].ToString(),
                            Nombre = item["Nombre"].ToString(),
                            Apellidos = item["Apellidos"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"]).ToStringDate(),
                            Direccion = item["Direccion"].ToString(),
                            Celular = item["Celular"].ToString(),
                            Telefono = item["Telefono"].ToString(),
                            Email = item["Email"].ToString()
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

    }
}