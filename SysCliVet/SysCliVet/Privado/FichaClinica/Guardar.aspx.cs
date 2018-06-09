using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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

        protected void GuardarFicha(object sender, EventArgs e)
        {
            try
            {
                clsBaseEntidad baseEntidad = new clsBaseEntidad();
                Boolean resultado = false;
                clsPropietario objPropietario = new clsPropietario
                {
                    Id = Convert.ToInt32(hfIdPropietario.Value),
                    Nombre = txtNombrePro.Value,
                    Email = txtEmail.Value,
                    Direccion = txtDireccion.Value,
                    Telefono = txtTelefono.Value,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacPro.Value, CultureInfo.InvariantCulture),
                    Dni = Convert.ToInt32(txtDni.Value)
                };
                clsPaciente objPaciente = new clsPaciente
                {
                    Id = Convert.ToInt32(hfIdPropietario.Value),
                    Nombre = txtNombrePro.Value,
                    FechaNacimiento = Convert.ToDateTime(txtFechaNacPac.Value, CultureInfo.InvariantCulture),
                    Raza = txtRaza.Value,
                    Color = txtDireccion.Value,
                    Especie = txtEspecie.Value,
                    Sexo = rbMacho.Checked ? (Int16)EnumGeneroMascota.Macho : (Int16)EnumGeneroMascota.Hembra,
                    Intac = rbIntacSi.Checked ? true : false,
                    Cast = rbCastSi.Checked ? true : false,
                    Peso = txtPeso.Value,
                    MarcaDistintiva = txtMarcaDist.Value,                    
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
                            Fecha = DateTime.ParseExact(item.Fecha.ToString(), "d", CultureInfo.InvariantCulture),
                            Descripcion = item.Descripcion,
                            Estado = 1
                        });
                    }
                }

                clsFichaClinica objFichaClinica = new clsFichaClinica
                {
                    Propietario = objPropietario,
                    Paciente = objPaciente,
                    InformacionMedica = txtInfMedica.Value,
                    MedioAmbiente = rbViveSolo.Checked ? (Int16)EnumMedioAmbiente.ViveSolo : (Int16)EnumMedioAmbiente.OtrosAnimales,
                    TipoDieta = rbComidaCasera.Checked ? (Int16)EnumTipoDieta.ComidaCasera : rbConcentrado.Checked ? (Int16)EnumTipoDieta.Concentrado : (Int16)EnumTipoDieta.Mixto,
                    Motivo = txtMotivoCons.Value,
                    Observaciones = txtObservacion.Value,
                    ListaVacunas = ListaVacunas
                };

                resultado = clsLogica.Instance.FichaClinica_Guardar(ref baseEntidad, objFichaClinica);

            }
            catch (Exception ex) { }
        }

    }
}