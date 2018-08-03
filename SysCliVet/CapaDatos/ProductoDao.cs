using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaLibreria.Conexiones;

namespace CapaDatos
{
    public class ProductoDao
    {
        #region Singleton
        private static ProductoDao instance = null;
        public static ProductoDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductoDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public Producto SetEntidad(SqlDataReader dr)
        {
            Producto producto = new Producto();
            producto.Id = dr.ObtenerValorColumna<Int32>("ID");
            producto.Codigo = dr.ObtenerValorColumna<String>("Codigo");
            producto.Descripcion = dr.ObtenerValorColumna<String>("Descripcion");
            producto.Estado = dr.ObtenerValorColumna<Int16>("Estado");
            producto.Categoria.Id = dr.ObtenerValorColumna<Int32>("Categoria_Id");
            producto.Categoria.Descripcion = dr.ObtenerValorColumna<String>("Categoria_Descripcion");
            return producto;
        }
        #endregion

        #region CRUD
        public Boolean Guardar(ref BaseEntidad baseEntidad, Producto objProducto)
        {

            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Producto_Guardar", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", objProducto.Id);
                cmd.Parameters.AddWithValue("@Codigo", objProducto.Codigo);
                cmd.Parameters.AddWithValue("@ProductoCategoryID", objProducto.Categoria.Id);
                cmd.Parameters.AddWithValue("@Descripcion", objProducto.Descripcion);
                cmd.Parameters.AddWithValue("@CantidadIngreso", objProducto.ProductoMovimiento.Cantidad);
                cmd.Parameters.AddWithValue("@Movimiento_Descripcion", objProducto.ProductoMovimiento.Descripcion);
                cmd.ExecuteReader();
                Resultado = true;
            }
            catch (Exception ex)
            {
                Resultado = false;
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return Resultado;
        }

        public Producto porID(ref BaseEntidad baseEntidad, Int32 id)
        {
            Producto objProducto = null;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Producto_PorID", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ID", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objProducto = SetEntidad(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                objProducto = null;
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return objProducto;
        }

        public List<Producto> Listar(ref BaseEntidad baseEntidad)
        {
            List<Producto> lstProductos = new List<Producto>();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("Producto_Listar", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Producto objProducto = new Producto();
                        objProducto = SetEntidad(dr);
                        lstProductos.Add(objProducto);
                    }
                }
            }
            catch (Exception ex)
            {
                lstProductos = null;
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return lstProductos;
        }

        public Boolean EliminarPorId(ref BaseEntidad baseEntidad, Int32 id)
        {
            Boolean resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Producto_EliminarPorId", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", id);
                resultado = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return resultado;
        }

        #endregion

    }
}
