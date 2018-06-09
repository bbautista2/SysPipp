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
                        if(objUsuario.Estado == (Int32)EnumEstadoUsuario.Inactive)
                            baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(new Exception(), "Tu cuenta está inactiva"));
                    }
                    else
                        baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(new Exception(), "Usuario y/o contraseña inválidos"));
                }else
                    baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(new Exception(), "Ingresa tu Usuario y contraseña"));

            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }

            return objUsuario;
        }
        #endregion

        #region Propietario
        public clsPropietario Propietario_PorId(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            clsPropietario objPropietario = new clsPropietario();
            try
            {
                objPropietario = clsPropietarioDAO.Instance.porID(ref baseEntidad, id);
            } catch(Exception ex) {
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
        #endregion


    }
}
