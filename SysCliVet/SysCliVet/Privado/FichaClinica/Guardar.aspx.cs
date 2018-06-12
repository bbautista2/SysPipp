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
                    Telefono = txtTelefono.Value,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacPro.Value, CultureInfo.InvariantCulture),
                    Dni = Convert.ToInt32(txtDni.Value),
                    Estado = 1
                };
                clsMascota objMascota = new clsMascota
                {
                    Id = Convert.ToInt32(hfIdPropietario.Value),
                    Nombre = txtNombreMas.Value,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacMas.Value, CultureInfo.InvariantCulture),
                    Raza = txtRaza.Value,
                    Color = txtDireccion.Value,
                    Especie = txtEspecie.Value,
                    Sexo = rbMacho.Checked ? (Int16)EnumGeneroMascota.Macho : (Int16)EnumGeneroMascota.Hembra,
                    Intac = rbIntacSi.Checked ? true : false,
                    Cast = rbCastSi.Checked ? true : false,
                    Peso = txtPeso.Value,
                    MarcaDistintiva = txtMarcaDist.Value,
                    Estado = 1
                };

                JavaScriptSerializer sr = new JavaScriptSerializer();
                List<clsVacuna> lstVacunas = new List<clsVacuna>();
                tListaVacunas ListaVacunas = new tListaVacunas();
                lstVacunas = sr.Deserialize<List<clsVacuna>>(hfVacunas.Value);
                if (lstVacunas != null)
                {
                    foreach (clsVacuna item in lstVacunas)
                    {
                        ListaVacunas.Add(new tVacuna
                        {
                            Id = item.Id,
                            Fecha = Convert.ToDateTime(txtFechaNacMas.Value, CultureInfo.InvariantCulture),
                            Descripcion = item.Descripcion,
                            Estado = 1
                        });
                    }
                }

                clsFichaClinica objFichaClinica = new clsFichaClinica
                {
                    Propietario = objPropietario,
                    Fecha = Convert.ToDateTime(txtFechaFicha.Value, CultureInfo.InvariantCulture),
                    Mascota = objMascota,
                    InformacionMedica = txtInfMedica.Value,
                    MedioAmbiente = rbViveSolo.Checked ? (Int16)EnumMedioAmbiente.ViveSolo : (Int16)EnumMedioAmbiente.OtrosAnimales,
                    TipoDieta = rbComidaCasera.Checked ? (Int16)EnumTipoDieta.ComidaCasera : rbConcentrado.Checked ? (Int16)EnumTipoDieta.Concentrado : (Int16)EnumTipoDieta.Mixto,
                    Motivo = txtMotivoCons.Value,
                    Observaciones = txtObservacion.Value,
                    ListaVacunas = ListaVacunas,
                    Estado = 1
                };

                resultado = clsLogica.Instance.FichaClinica_Guardar(ref baseEntidad, objFichaClinica);

            }
            catch (Exception ex) { }
        }

        [WebMethod]
        public static List<clsPropietario> ListaPropietariosPorDni(String dni)
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            List<clsPropietario> lista = new List<clsPropietario>();
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
                        lista.Add(new clsPropietario
                        {
                            Dni = Convert.ToInt32(item["Dni"]),
                            Nombre = item["Nombre"].ToString(),
                            Apellidos = item["Apellidos"].ToString(),
                            FechaNacimiento = DateTime.ParseExact(item["FechaNacimiento"].ToString(), "d", CultureInfo.InvariantCulture),
                            Direccion = item["Direccion"].ToString(),
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