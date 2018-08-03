using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using SysCliVet.src.app_code;
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

namespace SysCliVet.Privado.Mascota
{
    public partial class Ver : Page
    {

        public Int32 mascotaId
        {
            get { return ViewState["ID"] != null ? (Int32)ViewState["ID"] : default(Int32); }
            set { ViewState["ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["i"]))
            {
                String id = Encriptacion.Desencriptar(Request.QueryString["i"]);
                if (id != String.Empty)
                {
                    mascotaId = Convert.ToInt32(id);
                    hfIdMascota.Value = mascotaId.ToString();
                    BaseEntidad baseEntidad = new BaseEntidad();
                    CapaEntidad.Mascota objMascota = new CapaEntidad.Mascota();
                    CapaEntidad.FichaClinica objFichaClinica = new CapaEntidad.FichaClinica();
                    List<Object> lstVacunas = new List<Object>();
                    objMascota = Logica.Instance.Mascota_PorId(ref baseEntidad, mascotaId);
                    objFichaClinica = Logica.Instance.FichaClinica_ObtenerPorMascotaId(ref baseEntidad, mascotaId);
                    hfIdFicha.Value = objFichaClinica.Id.ToString();
                    Mascota_MostrarInformacion(objMascota);
                    FichaClinica_MostrarInformacion(objFichaClinica);

                    CargarDatos(objFichaClinica);

                    #region Lista Historias
                    List<HistoriaClinica> lstObjHistoria = new List<HistoriaClinica>();
                    List<Object> lstHistoria = new List<Object>();
                    lstObjHistoria = Logica.Instance.HistoriaClinica_ObtenerPorMascotaId(ref baseEntidad, mascotaId);

                    if (lstObjHistoria != null && lstObjHistoria.Count > 0)
                    {
                        foreach (HistoriaClinica historia in lstObjHistoria)
                        {
                            lstHistoria.Add(new
                            {
                                Id = HttpUtility.UrlEncode(Encriptacion.Encriptar(historia.Id.ToString())),
                                Fecha = historia.Fecha.ToStringDate(),
                                NroFicha = historia.NumeroFicha,
                                Apetito = historia.Apetito == (Int32)EnumApetito.Bueno ? "Bueno" : historia.Apetito == (Int32)EnumApetito.Malo ? "Malo" : "Normal",
                                CondicionCuerpo = historia.CondicionCuerpo == (Int32)EnumCC.Caquesico ? "Caquesico" : historia.CondicionCuerpo == (Int32)EnumCC.Obeso ? "Obeso" : "Normal",
                                historia.PesoActual,
                                NroFichaEncriptado = HttpUtility.UrlEncode(Encriptacion.Encriptar(historia.NumeroFicha.ToString()))
                            });
                        }
                        hfListadoHistoria.Value = (new JavaScriptSerializer()).Serialize(lstHistoria);
                    }
                    #endregion
                }
            }
        }

        private void FichaClinica_MostrarInformacion(CapaEntidad.FichaClinica objFichaClinica)
        {
            lblNumeroFicha.Text = objFichaClinica.NumeroFicha.ToString();
            hfNroFicha.Value = HttpUtility.UrlEncode(Encriptacion.Encriptar(objFichaClinica.NumeroFicha.ToString()));
        }

        private void Mascota_MostrarInformacion(CapaEntidad.Mascota objMascota) {
            lblNombreMascota.Text = objMascota.Nombre;
            lblRazaMascota.Text = objMascota.Raza;
            lblPesoMascota.Text = objMascota.Peso;
            lblEdadMascota.Text = objMascota.getEdad().ToString();
            ImgFotoMascota.ImageUrl = Config.MascotaRutaVirtual + "imagenes/" + objMascota.Foto;
        }
        private void CargarDatos(CapaEntidad.FichaClinica objFichaClinica)
        {
            #region Lista Vacunas

            List<Object> lstVacunas = new List<Object>();
            hfIdFicha.Value = objFichaClinica.Id.ToString();
            foreach (Vacuna vacuna in objFichaClinica.LstVacunas)
            {
                lstVacunas.Add(new
                {
                    id = vacuna.Id,
                    fecha = vacuna.Fecha.ToStringDate(),
                    nombre = vacuna.Nombre,
                    descripcion = vacuna.Descripcion
                });
            }

            hfListadoVacunas.Value = (new JavaScriptSerializer()).Serialize(lstVacunas);

            #endregion

            #region Lista Desparasitaciones
            List<Object> lstDesparasitaciones = new List<Object>();
            foreach (Desparasitacion desparasitacion in objFichaClinica.LstDesparasitaciones)
            {
                lstDesparasitaciones.Add(new
                {
                    id = desparasitacion.Id,
                    fecha = desparasitacion.Fecha.ToStringDate(),
                    nombre = desparasitacion.Nombre,
                    descripcion = desparasitacion.Descripcion
                });
            }
            hfListadoDesparasitaciones.Value = (new JavaScriptSerializer()).Serialize(lstDesparasitaciones);
            #endregion
        }
        protected void btnGuardarDatosMascota_Click(object sender, EventArgs e)
        {
            try
            {
                BaseEntidad baseEntidad = new BaseEntidad();
                Boolean resultado = false;

                JavaScriptSerializer srVacunas = new JavaScriptSerializer();
                List<Vacuna> lstVacunas = new List<Vacuna>();
                tListaVacunas ListaVacunas = new tListaVacunas();
                lstVacunas = srVacunas.Deserialize<List<Vacuna>>(hfVacunas.Value);
                if (lstVacunas != null)
                {
                    foreach (Vacuna item in lstVacunas)
                    {
                        ListaVacunas.Add(new tVacuna
                        {
                            Id = item.Id,
                            Fecha = DateTime.ParseExact(item.SFecha.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Nombre = item.Nombre,
                            Descripcion = String.Empty,
                            Estado = 1
                        });
                    }
                }

                JavaScriptSerializer srDesp = new JavaScriptSerializer();
                List<Desparasitacion> lstDesp = new List<Desparasitacion>();
                tListaDesparasitacion ListaDesp = new tListaDesparasitacion();
                lstDesp = srDesp.Deserialize<List<Desparasitacion>>(hfDesparasitaciones.Value);
                if (lstDesp != null)
                {
                    foreach (Desparasitacion item in lstDesp)
                    {
                        ListaDesp.Add(new tDesparasitacion
                        {
                            Id = item.Id,
                            Fecha = DateTime.ParseExact(item.SFecha.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                            Nombre = item.Nombre,
                            Descripcion = String.Empty,
                            Estado = 1
                        });
                    }
                }

                CapaEntidad.FichaClinica objFichaClinica = new CapaEntidad.FichaClinica
                {
                    Id = Convert.ToInt32(hfIdFicha.Value),
                    ListaVacunas = ListaVacunas,
                    ListaDesparasitaciones = ListaDesp
                };

                resultado = Logica.Instance.FichaClinica_Actualizar(ref baseEntidad, objFichaClinica);
                if (resultado)
                {
                    objFichaClinica = new CapaEntidad.FichaClinica();
                    objFichaClinica = Logica.Instance.FichaClinica_ObtenerPorMascotaId(ref baseEntidad, mascotaId);
                    CargarDatos(objFichaClinica);
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"s\"" + ", " + "\"Datos de la Mascota Guardada Correctamente\"" + ");</script>", false);
                }
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando los datos de la Mascota\"" + ");</script>", false);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error actualizando los datos de la Mascota\"" + ");</script>", false);
            }
        }

        [WebMethod]
        public static Object EliminarHistoria(String id, Int32 idMascota)
        {
            Boolean resultado = false;

            try
            {
                Int32 idHistoria = Convert.ToInt32(Encriptacion.Desencriptar(HttpUtility.UrlDecode(id)));

                BaseEntidad baseEntidad = new BaseEntidad();

                resultado = Logica.Instance.HistoriaClinica_EliminarPorId(ref baseEntidad, idHistoria);

                if (resultado)
                    return new { Lista = ObtenerHistorias(idMascota), correcto = true, mensaje = "Historia Eliminada correctamente" };
                else
                    return new { Lista = new List<Object>(), correcto = false, mensaje = "Ha ocurrido un error eliminando la Historia" };

            }
            catch (Exception)
            {
                return new { Lista = new List<Object>(), correcto = false, mensaje = "Ha ocurrido un error eliminando la Historia [1]" };
            }
        }

        [WebMethod]
        public static List<Object> ObtenerHistorias(Int32 idMascota)
        {
            List<Object> lst = new List<Object>();
            try
            {
                BaseEntidad baseEntidad = new BaseEntidad();
                List<HistoriaClinica> lstObjHistoria = new List<HistoriaClinica>();
                lstObjHistoria = Logica.Instance.HistoriaClinica_ObtenerPorMascotaId(ref baseEntidad, idMascota);
                if (baseEntidad.Errores.Count == 0 && lstObjHistoria != null && lstObjHistoria.Count > 0)
                {
                    foreach (HistoriaClinica historia in lstObjHistoria)
                    {
                        lst.Add(new
                        {
                            Id = HttpUtility.UrlEncode(Encriptacion.Encriptar(historia.Id.ToString())),
                            Fecha = historia.Fecha.ToStringDate(),
                            NroFicha = historia.NumeroFicha,
                            Apetito = historia.Apetito == (Int32)EnumApetito.Bueno ? "Bueno" : historia.Apetito == (Int32)EnumApetito.Malo ? "Malo" : "Normal",
                            CondicionCuerpo = historia.CondicionCuerpo == (Int32)EnumCC.Caquesico ? "Caquesico" : historia.CondicionCuerpo == (Int32)EnumCC.Obeso ? "Obeso" : "Normal",
                            historia.PesoActual,
                            NroFichaEncriptado = HttpUtility.UrlEncode(Encriptacion.Encriptar(historia.NumeroFicha.ToString()))
                        });
                    }
                }
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }

    }
}