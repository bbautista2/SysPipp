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
    public class Logica
    {
        #region Singleton
        private static Logica instance = null;
        public static Logica Instance
        {
            get
            {
                if (instance == null)
                    instance = new Logica();
                return instance;
            }
        }
        #endregion

        #region Acceso
        public Usuario Usuario_ValidarAcceso(ref BaseEntidad baseEntidad, String usuario, String password)
        {
            Usuario objUsuario = null;
            try
            {
                if (!String.IsNullOrEmpty(usuario) && !String.IsNullOrEmpty(password))
                {
                    objUsuario = UsuarioDao.Instance.ValidarAcceso(ref baseEntidad, usuario, Encriptacion.Encriptar(password));
                    String message = String.Empty;
                    if (objUsuario != null)
                    {
                        if (objUsuario.Estado == (Int32)EnumEstadoUsuario.Inactive)
                            baseEntidad.Errores.Add(new BaseEntidad.ListaError(new Exception(), "Tu cuenta está inactiva"));
                    }
                    else
                        baseEntidad.Errores.Add(new BaseEntidad.ListaError(new Exception(), "NombreUsuario y/o contraseña inválidos"));
                }
                else
                    baseEntidad.Errores.Add(new BaseEntidad.ListaError(new Exception(), "Ingresa tu NombreUsuario y contraseña"));

            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }

            return objUsuario;
        }
        #endregion

        #region Mascota
        public List<Mascota> Mascota_PorNombre(ref BaseEntidad baseEntidad, String nombre)
        {
            List<Mascota> lstMascota = new List<Mascota>();
            try
            {
                lstMascota = MascotaDao.Instance.porNombre(ref baseEntidad, nombre);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstMascota;
        }

        public Mascota Mascota_PorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Mascota objMascota = new Mascota();
            try
            {
                objMascota = MascotaDao.Instance.porID(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return objMascota;
        }

        public Boolean Mascota_Guardar(ref BaseEntidad baseEntidad, Mascota objMascota)
        {
            Boolean resultado = false;
            try
            {
                resultado = MascotaDao.Instance.Guardar(ref baseEntidad, objMascota);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        public DataTable Mascota_Listar(ref BaseEntidad baseEntidad)
        {
            DataTable dt = null;
            try
            {
                dt = MascotaDao.Instance.Listar(ref baseEntidad);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return dt;
        }

        public Boolean Mascota_EliminarPorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = MascotaDao.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        public List<Mascota> Mascota_ObtenerPorCumpleMesActual(ref BaseEntidad objBase)
        {
            List<Mascota> lstMascota = new List<Mascota>();
            try
            {
                lstMascota = MascotaDao.Instance.ObtenerPorCumpleMesActual(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstMascota;
        }

        #endregion

        #region Propietario
        public Propietario Propietario_PorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Propietario objPropietario = new Propietario();
            try
            {
                objPropietario = PropietarioDao.Instance.porID(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return objPropietario;
        }

        public Boolean Propietario_Guardar(ref BaseEntidad baseEntidad, Propietario objPropietario)
        {
            Boolean resultado = false;
            try
            {
                resultado = PropietarioDao.Instance.Guardar(ref baseEntidad, objPropietario);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        public DataTable Propietario_Listar(ref BaseEntidad baseEntidad)
        {
            DataTable dt = null;
            try
            {
                dt = PropietarioDao.Instance.Listar(ref baseEntidad);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return dt;
        }

        public DataTable Propietario_ObtenerPorDni(ref BaseEntidad baseEntidad, String dni, Int16 tipoBusqueda)
        {
            DataTable dt = null;
            try
            {
                dt = PropietarioDao.Instance.ObtenerPorDni(ref baseEntidad, dni, tipoBusqueda);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return dt;
        }

        public Boolean Propietario_EliminarPorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = PropietarioDao.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        #endregion

        #region Ficha Clinica
        public Boolean FichaClinica_Guardar(ref BaseEntidad baseEntidad, FichaClinica objFichaClinica)
        {
            Boolean resultado = false;
            try
            {
                resultado = FichaClinicaDao.Instance.Guardar(ref baseEntidad, objFichaClinica);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }
        public Boolean FichaClinica_Actualizar(ref BaseEntidad baseEntidad, FichaClinica objFichaClinica)
        {
            Boolean resultado = false;
            try
            {
                resultado = FichaClinicaDao.Instance.Actualizar(ref baseEntidad, objFichaClinica);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }
        public FichaClinica FichaClinica_ObtenerPorMascotaId(ref BaseEntidad objEntidad, Int32 mascotaId)
        {
            FichaClinica objFichaClinica = new FichaClinica();
            try
            {
                objFichaClinica = FichaClinicaDao.Instance.ObtenerPorMascotaID(ref objEntidad, mascotaId);

            }
            catch (Exception ex)
            {
                objEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicacion [2]"));
            }
            return objFichaClinica;
        }
        #endregion

        #region Historia Clinica
        public Boolean HistoriaClinica_Guardar(ref BaseEntidad baseEntidad, HistoriaClinica objHistoriaClinica)
        {
            Boolean resultado = false;
            try
            {
                resultado = HistoriaClinicaDao.Instance.Guardar(ref baseEntidad, objHistoriaClinica);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        public List<HistoriaClinica> HistoriaClinica_ObtenerPorMascotaId(ref BaseEntidad objEntidad, Int32 mascotaId)
        {
            List<HistoriaClinica> lstObjHistoriaClinica = new List<HistoriaClinica>();
            try
            {
                lstObjHistoriaClinica = HistoriaClinicaDao.Instance.ObtenerPorMascotaID(ref objEntidad, mascotaId);
            }
            catch (Exception ex)
            {
                objEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicacion [2]"));
            }
            return lstObjHistoriaClinica;
        }

        public HistoriaClinica HistoriaClinica_PorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            HistoriaClinica objHistoria = new HistoriaClinica();
            try
            {
                objHistoria = HistoriaClinicaDao.Instance.porID(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return objHistoria;
        }

        public bool HistoriaClinica_EliminarPorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = HistoriaClinicaDao.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        #endregion

        #region TipoCita
        public List<TipoCita> TipoCita_ObtenerTodo(ref BaseEntidad objBase)
        {
            List<TipoCita> lstTiposCita = new List<TipoCita>();
            try
            {
                lstTiposCita = TipoCitaDao.Instance.ObtenerTodo(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstTiposCita;
        }
        #endregion

        #region Cita
        public List<Cita> Cita_ObtenerTodo(ref BaseEntidad objBase)
        {
            List<Cita> lstCita = new List<Cita>();
            try
            {
                lstCita = CitaDao.Instance.ObtenerTodo(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstCita;
        }

        public List<Cita> Cita_ObtenerPorFechaActual(ref BaseEntidad objBase)
        {
            List<Cita> lstCita = new List<Cita>();
            try
            {
                lstCita = CitaDao.Instance.ObtenerPorFechaActual(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstCita;
        }

        public Boolean Cita_Guardar(ref BaseEntidad objBase, Cita objCita)
        {
            Boolean respuesta = false;
            try
            {
                respuesta = CitaDao.Instance.Guardar(ref objBase, objCita);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return respuesta;
        }

        public Boolean Cita_EliminarPorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = CitaDao.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        #endregion

        #region Producto Categoria
        public List<ProductoCategoria> ProductoCategoria_ObtenerTodo(ref BaseEntidad objBase)
        {
            List<ProductoCategoria> lstCategorias = new List<ProductoCategoria>();
            try
            {
                lstCategorias = ProductoCategoriaDao.Instance.ObtenerTodo(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstCategorias;
        }

        #endregion

        #region Producto
        public Boolean Producto_Guardar(ref BaseEntidad objBase, Producto objProducto)
        {
            Boolean respuesta = false;
            try
            {
                respuesta = ProductoDao.Instance.Guardar(ref objBase, objProducto);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return respuesta;
        }

        public Producto Producto_PorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Producto objProducto = new Producto();
            try
            {
                objProducto = ProductoDao.Instance.porID(ref baseEntidad, id);
                if (objProducto != null && objProducto.Id > 0)
                    objProducto.LstProductoMovimientos = ProductoMovimientoDao.Instance.porProductoID(ref baseEntidad, objProducto.Id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return objProducto;
        }

        public List<Producto> Producto_Listar(ref BaseEntidad baseEntidad)
        {
            List<Producto> lstProductos = new List<Producto>();
            try
            {
                lstProductos = ProductoDao.Instance.Listar(ref baseEntidad);
                if(lstProductos != null && lstProductos.Count > 0)
                {
                    foreach (Producto objProducto in lstProductos)
                    {
                        if (objProducto != null && objProducto.Id > 0)
                            objProducto.LstProductoMovimientos = ProductoMovimientoDao.Instance.porProductoID(ref baseEntidad, objProducto.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstProductos;
        }

        public Boolean Producto_EliminarPorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            try
            {
                resultado = ProductoDao.Instance.EliminarPorId(ref baseEntidad, id);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return resultado;
        }

        public Int32 ProductoMovimiento_ActualizarStock(ref BaseEntidad baseEntidad, Int32 productoId, String descripcion, Int32 cantidad)
        {
            Int32 stockActual = 0;
            try
            {
                stockActual = ProductoMovimientoDao.Instance.ActualizarStock(ref baseEntidad, productoId, descripcion, cantidad);
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return stockActual;
        }

        public List<ProductoMovimiento> ProductoMovimiento_ObtenerMasVendidos(ref BaseEntidad objBase)
        {
            List<ProductoMovimiento> lstProductoMovimientos = new List<ProductoMovimiento>();
            try
            {
                lstProductoMovimientos = ProductoMovimientoDao.Instance.ObtenerMasVendidos(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstProductoMovimientos;
        }

        #endregion

        #region Recordatorio
        public List<Recordatorio> Recordatorio_ObtenerTodo(ref BaseEntidad objBase)
        {
            List<Recordatorio> lstRecordatorio = new List<Recordatorio>();
            try
            {
                lstRecordatorio = RecordatorioDao.Instance.ObtenerTodo(ref objBase);
            }
            catch (Exception ex)
            {
                objBase.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [2]"));
            }
            return lstRecordatorio;
        }
        #endregion

    }
}
