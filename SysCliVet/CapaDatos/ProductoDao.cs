using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.Conexion;
using CapaLibreria.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            producto.Codigo= dr.ObtenerValorColumna<String>("Codigo");
            producto.Descripcion = dr.ObtenerValorColumna<String>("Descripcion");
            producto.CantidadMinima = dr.ObtenerValorColumna<Int16>("CantidadMinima");
            producto.Estado = dr.ObtenerValorColumna<Int16>("Estado");
            return producto;
        }
        #endregion

        #region CRUD
        public Boolean Guardar(ref clsBaseEntidad baseEntidad, Producto objProducto)
        {

            Boolean Resultado = false;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("Producto_Guardar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };  
                cmd.Parameters.AddWithValue("@Codigo", objProducto.Codigo);
                cmd.Parameters.AddWithValue("@ProductoCategoryID", objProducto.Categoria.Id);
                cmd.Parameters.AddWithValue("@Descripcion", objProducto.Descripcion);
                cmd.Parameters.AddWithValue("@CantidadMinima", objProducto.CantidadMinima);
                cmd.Parameters.AddWithValue("@CantidadIngreso", objProducto.ProductoMovimiento.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioCosto", objProducto.ProductoMovimiento.PrecioCosto);       
                Resultado = true;
            }
            catch (Exception ex)
            {
                Resultado = false;
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return Resultado;
        }
        #endregion

    }
}
