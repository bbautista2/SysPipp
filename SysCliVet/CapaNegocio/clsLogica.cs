using CapaDatos;
using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class clsLogica
    {
        #region Singleton
        private static clsLogica instance = null;
        public static clsLogica Instance
        {
            get
            {
                if (instance == null)
                    instance = new clsLogica();
                return instance;
            }
        }
        #endregion

        #region Acceso
        public clsUsuario Usuario_ValidarAcceso(ref clsBaseEntidad baseEntidad, String usuario, String password)
        {
            clsUsuario objUsuario = null;
            try
            {
                if (!String.IsNullOrEmpty(usuario) && !String.IsNullOrEmpty(password))
                {
                    objUsuario = clsUsuarioDao.Instance.ValidarAcceso(ref baseEntidad, usuario, clsEncriptacion.Encriptar(password));
                    String message = String.Empty;
                    if (objUsuario != null)
                    {
                        if (objUsuario.Estado == (Int32)EnumEstadoUsuario.Inactive)
                            baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(new Exception(), "Tu cuenta está inactiva"));
                    }
                    else
                        baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(new Exception(), "Usuario y/o contraseña inválidos"));
                } else
                    baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(new Exception(), "Ingresa tu Usuario y contraseña"));

            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }

            return objUsuario;
        }
        #endregion

        #region Mascota
        public List<clsMascota> Mascota_PorNombre(ref clsBaseEntidad baseEntidad, String nombre)
        {
            List<clsMascota> lstMascota = new List<clsMascota>();
            try
            {
                lstMascota = clsMascotaDAO.Instance.porNombre(ref baseEntidad, nombre);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstMascota;
        }

        public clsMascota Mascota_PorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            clsMascota objMascota = new clsMascota();
            try
            {
                objMascota = clsMascotaDAO.Instance.porID(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return objMascota;
        }

        public Boolean Mascota_Guardar(ref clsBaseEntidad baseEntidad, clsMascota objMascota)
        {
            Boolean resultado = false;
            try
            {
                resultado = clsMascotaDAO.Instance.Guardar(ref baseEntidad, objMascota);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        public DataTable Mascota_Listar(ref clsBaseEntidad baseEntidad)
        {
            DataTable dt = null;
            try
            {
                dt = clsMascotaDAO.Instance.Listar(ref baseEntidad);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return dt;
        }

        public Boolean Mascota_EliminarPorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = clsMascotaDAO.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        #endregion

        #region Propietario
        public clsPropietario Propietario_PorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            clsPropietario objPropietario = new clsPropietario();
            try
            {
                objPropietario = clsPropietarioDAO.Instance.porID(ref baseEntidad, id);
            } catch (Exception ex) {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return objPropietario;
        }

        public Boolean Propietario_Guardar(ref clsBaseEntidad baseEntidad, clsPropietario objPropietario)
        {
            Boolean resultado = false;
            try
            {
                resultado = clsPropietarioDAO.Instance.Guardar(ref baseEntidad, objPropietario);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        public DataTable Propietario_Listar(ref clsBaseEntidad baseEntidad)
        {
            DataTable dt = null;
            try
            {
                dt = clsPropietarioDAO.Instance.Listar(ref baseEntidad);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return dt;
        }

        public DataTable Propietario_ObtenerPorDni(ref clsBaseEntidad baseEntidad, String dni, Int16 tipoBusqueda)
        {
            DataTable dt = null;
            try
            {
                dt = clsPropietarioDAO.Instance.ObtenerPorDni(ref baseEntidad, dni, tipoBusqueda);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return dt;
        }

        public Boolean Propietario_EliminarPorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = clsPropietarioDAO.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        #endregion

        #region Ficha Clinica
        public Boolean FichaClinica_Guardar(ref clsBaseEntidad baseEntidad, clsFichaClinica objFichaClinica)
        {
            Boolean resultado = false;
            try
            {
                resultado = clsFichaClinicaDAO.Instance.Guardar(ref baseEntidad, objFichaClinica);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }
        public Boolean FichaClinica_Actualizar(ref clsBaseEntidad baseEntidad, clsFichaClinica objFichaClinica)
        {
            Boolean resultado = false;
            try
            {
                resultado = clsFichaClinicaDAO.Instance.Actualizar(ref baseEntidad, objFichaClinica);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }
        public clsFichaClinica FichaClinica_ObtenerPorMascotaId(ref clsBaseEntidad objEntidad,Int32 mascotaId) {
            clsFichaClinica objFichaClinica = new clsFichaClinica();
            try {
                objFichaClinica = clsFichaClinicaDAO.Instance.ObtenerPorMascotaID(ref objEntidad,mascotaId);

            } catch(Exception ex) {
                objEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex,"Ha ocurrido un error en la aplicacion [2]"));
            }
            return objFichaClinica;
        }
        #endregion

        #region Historia Clinica
        public Boolean HistoriaClinica_Guardar(ref clsBaseEntidad baseEntidad, clsHistoriaClinica objHistoriaClinica)
        {
            Boolean resultado = false;
            try
            {
                resultado = clsHistoriaClinicaDAO.Instance.Guardar(ref baseEntidad, objHistoriaClinica);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        public List<clsHistoriaClinica> HistoriaClinica_ObtenerPorMascotaId(ref clsBaseEntidad objEntidad, Int32 mascotaId)
        {
            List<clsHistoriaClinica> lstObjHistoriaClinica = new List<clsHistoriaClinica>();
            try
            {
                lstObjHistoriaClinica = clsHistoriaClinicaDAO.Instance.ObtenerPorMascotaID(ref objEntidad, mascotaId);
            }
            catch (Exception ex)
            {
                objEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicacion [2]"));
            }
            return lstObjHistoriaClinica;
        }

        public clsHistoriaClinica HistoriaClinica_PorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            clsHistoriaClinica objHistoria = new clsHistoriaClinica();
            try
            {
                objHistoria = clsHistoriaClinicaDAO.Instance.porID(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return objHistoria;
        }

        public bool HistoriaClinica_EliminarPorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = clsHistoriaClinicaDAO.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        #endregion

        #region TipoCita
        public List<TipoCita> TipoCita_ObtenerTodo(ref clsBaseEntidad objBase)
        {
            List<TipoCita> lstTiposCita = new List<TipoCita>();
            try
            {
                lstTiposCita = TipoCitaDao.Instance.ObtenerTodo(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstTiposCita;
        }
        #endregion

        #region Cita
        public List<Cita> Cita_ObtenerTodo(ref clsBaseEntidad objBase)
        {
            List<Cita> lstCita = new List<Cita>();
            try
            {
                lstCita = CitaDao.Instance.ObtenerTodo(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstCita;
        }

        public Boolean Cita_Guardar(ref clsBaseEntidad objBase,Cita objCita)
        {
            Boolean respuesta = false;
            try
            {
                respuesta = CitaDao.Instance.Guardar(ref objBase,objCita);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return respuesta;
        }

        public Boolean Cita_EliminarPorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = CitaDao.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        #endregion
    }
}
