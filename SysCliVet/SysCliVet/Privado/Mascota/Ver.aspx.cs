using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
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
                String id = clsEncriptacion.Desencriptar(Request.QueryString["i"]);
                if (id != String.Empty)
                {
                    clsBaseEntidad baseEntidad = new clsBaseEntidad();
                    clsMascota objMascota = new clsMascota();
                    clsFichaClinica objFichaClinica = new clsFichaClinica();
                    List<Object> lstVacunas = new List<Object>();
                    objMascota = clsLogica.Instance.Mascota_PorId(ref baseEntidad, Convert.ToInt32(id));
                    objFichaClinica = clsLogica.Instance.FichaClinica_ObtenerPorMascotaId(ref baseEntidad, Convert.ToInt32(id));

                    foreach (clsVacuna vacuna in objFichaClinica.LstVacunas)
                    {
                        lstVacunas.Add(new {
                            id = vacuna.Id,
                            fecha = vacuna.Fecha.ToStringDate(),
                            nombre = vacuna.Nombre,
                            descripcion = vacuna.Descripcion                            
                        });                        
                    }
                    
                    hfListadoVacunas.Value = (new JavaScriptSerializer()).Serialize(lstVacunas); 
                    Mascota_MostrarInformacion(objMascota);
                    FichaClinica_MostrarInformacion(objFichaClinica);

                    #region Lista Historias
                    List<clsHistoriaClinica> lstObjHistoria = new List<clsHistoriaClinica>();
                    List<Object> lstHistoria = new List<object>();
                    lstObjHistoria = clsLogica.Instance.HistoriaClinica_ObtenerPorMascotaId(ref baseEntidad, Convert.ToInt32(id));

                    if(lstObjHistoria != null && lstObjHistoria.Count > 0)
                    {
                        foreach (clsHistoriaClinica historia in lstObjHistoria)
                        {
                            lstHistoria.Add(new
                            {
                                Id = clsEncriptacion.Encriptar(historia.Id.ToString()),
                                Fecha = historia.Fecha.ToStringDate(),
                                NroFicha = historia.NumeroFicha,
                                Apetito = historia.Apetito == (Int32)EnumApetito.Bueno ? "Bueno" : historia.Apetito == (Int32)EnumApetito.Malo ? "Malo" : "Normal",
                                CondicionCuerpo = historia.CondicionCuerpo == (Int32)EnumCC.Caquesico ? "Caquesico" : historia.CondicionCuerpo == (Int32)EnumCC.Obeso ? "Obeso" : "Normal",
                                historia.PesoActual
                            });
                        }
                        hfListadoHistoria.Value = (new JavaScriptSerializer()).Serialize(lstHistoria);
                    }
                    
                    #endregion
                }
            }
        }

        private void FichaClinica_MostrarInformacion(clsFichaClinica objFichaClinica)
        {
            lblNumeroFicha.Text = objFichaClinica.NumeroFicha.ToString();
        }

        private void Mascota_MostrarInformacion(clsMascota objMascota) {
            lblNombreMascota.Text = objMascota.Nombre;
            lblRazaMascota.Text = objMascota.Raza;
            lblPesoMascota.Text = objMascota.Peso;
            lblEdadMascota.Text = objMascota.getEdad().ToString();
            ImgFotoMascota.ImageUrl = Config.MascotaRutaVirtual + "imagenes/" + objMascota.Foto;

        }
         

    }
}