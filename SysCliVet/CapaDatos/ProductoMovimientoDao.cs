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
    public class ProductoMovimientoDao
    {
        #region Singleton
        private static ProductoMovimientoDao instance = null;
        public static ProductoMovimientoDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductoMovimientoDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public ProductoMovimiento SetEntidad(SqlDataReader dr)
        {
            ProductoMovimiento productoMovimiento = new ProductoMovimiento();
            productoMovimiento.Descripcion = dr.ObtenerValorColumna<String>("Descripcion");
            productoMovimiento.Cantidad = dr.ObtenerValorColumna<Int32>("Cantidad");
            return productoMovimiento;
        }
        #endregion

        public List<ProductoMovimiento> porProductoID(ref clsBaseEntidad baseEntidad, Int32 id)
        {
            List<ProductoMovimiento> lstProductoMovimiento = new List<ProductoMovimiento>();
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("ProductoMovimiento_PorProductoID", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductoId", id);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ProductoMovimiento objProductoMovimiento = new ProductoMovimiento();
                        objProductoMovimiento = SetEntidad(dr);
                        lstProductoMovimiento.Add(objProductoMovimiento);
                    }
                }
            }
            catch (Exception ex)
            {
                lstProductoMovimiento = null;
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return lstProductoMovimiento;
        }

        public Int32 ActualizarStock(ref clsBaseEntidad baseEntidad, Int32 productoId, String descripcion, Int32 cantidad)
        {
            Int32 stockActual = 0;
            SqlCommand cmd = null;
            try
            {
                cmd = new SqlCommand("ProductoMovimiento_ActualizarStock", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter outputId = cmd.Parameters.Add("@StockActual", SqlDbType.Int);
                outputId.Direction = ParameterDirection.Output;

                cmd.Parameters.AddWithValue("@ProductoId", productoId);
                cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.ExecuteReader();
                stockActual = Convert.ToInt32(cmd.Parameters["@StockActual"].Value);
            }
            catch (Exception ex)
            {
                stockActual = 0;
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return stockActual;
        }

    }
}
