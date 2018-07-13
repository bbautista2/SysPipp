using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace SysCliVet.Privado.HistorialClinico
{
    public partial class Guardar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ObtenerInformacion();
            }
        }

        private void ObtenerInformacion()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["nf"]))
            {
                String id = clsEncriptacion.Desencriptar(Request.QueryString["nf"]);
                lblNroFicha.Text = id;
            }
        }

        protected void btnGuardarHistoria_Click(object sender, EventArgs e)
        {
            try
            {
                clsBaseEntidad baseEntidad = new clsBaseEntidad();
                Boolean resultado = false;
                clsFichaClinica objFicha = new clsFichaClinica
                {
                    NumeroFicha = !String.IsNullOrEmpty(lblNroFicha.Text) ? Convert.ToInt32(lblNroFicha.Text) : 0
                };
                //Analisis
                JavaScriptSerializer srAnalisis = new JavaScriptSerializer();
                List<clsAnalisis> lstAnalisis = new List<clsAnalisis>();
                tListaAnalisis ListaAnalisis = new tListaAnalisis();
                lstAnalisis = srAnalisis.Deserialize<List<clsAnalisis>>(hfAnalisis.Value);
                if (lstAnalisis != null)
                {
                    foreach (clsAnalisis item in lstAnalisis)
                    {
                        ListaAnalisis.Add(new tAnalisis
                        {
                            Id = item.Id,
                            HistoriaClinicaId = 0,
                            TipoAnalisisId = item.TipoId,
                            Estado = 1
                        });
                    }
                }

                JavaScriptSerializer srTratamientos = new JavaScriptSerializer();
                List<clsTratamiento> lstTratamientos = new List<clsTratamiento>();
                tListaTratamientos ListaTratamientos = new tListaTratamientos();
                lstTratamientos = srTratamientos.Deserialize<List<clsTratamiento>>(hfTratamientos.Value);
                if (lstTratamientos != null)
                {
                    foreach (clsTratamiento item in lstTratamientos)
                    {
                        ListaTratamientos.Add(new tTratamiento
                        {
                            Id = item.Id,
                            FechaTratamiento = DateTime.ParseExact(item.SFechaTratamiento.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Droga = item.Droga,
                            Dosis = item.Dosis,
                            Observacion = item.Observacion,
                            Estado = 1
                        });
                    }
                }

                clsHistoriaClinica objHistoriaClinica = new clsHistoriaClinica
                {
                    FichaClinica = objFicha,
                    ListaAnalisis = ListaAnalisis,
                    ListaTratamientos = ListaTratamientos,
                    Fecha = Convert.ToDateTime(txtFechaHistoria.Value),
                    Agitacion = chkAgitacion.Checked,
                    Depresion = chkDepresion.Checked,
                    Apetito = rbApBueno.Checked ? (Int16)EnumApetito.Bueno : rbApMalo.Checked ? (Int16)EnumApetito.Malo : rbApNormal.Checked ? (Int16)EnumApetito.Normal : (Int16)0,
                    CondicionCuerpo = rbCCNormal.Checked ? (Int16)EnumCC.Normal : rbCCObeso.Checked ? (Int16)EnumCC.Obeso : rbCCCaquesico.Checked ? (Int16)EnumCC.Caquesico : (Int16)0,
                    PesoActual = txtPeso.Value,
                    PerdidaPeso = txtPesoPerdida.Value,
                    Sintomas = txtSintomas.Value,
                    Descarte = txtDescarte.Value,
                    Resultados = txtResultado.Value,
                    PresuntivoDefinitivo = txtPresunDefin.Value,
                    Estado = 1
                };
                resultado = clsLogica.Instance.HistoriaClinica_Guardar(ref baseEntidad, objHistoriaClinica);
                if(resultado)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"s\"" + ", " + "\"Historia Clínica Guardada Correctamente\"" + ");</script>", false);
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando la Historia Clínica\"" + ");</script>", false);
                }
            }
            catch (Exception ex) {
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando la Historia Clínica\"" + ");</script>", false);
            }
        }

    }
}