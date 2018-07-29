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
    public class ProductoCategoriaDao
    {
        #region Singleton
        private static ProductoCategoriaDao instance = null;
        public static ProductoCategoriaDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductoCategoriaDao();
                return instance;
            }
        }
        #endregion

        #region Llenar Entidades
        public ProductoCategoria SetEntidad(SqlDataReader dr)
        {
            ProductoCategoria categoria = new ProductoCategoria();
            categoria.Id = dr.ObtenerValorColumna<Int32>("ID");
            categoria.Descripcion= dr.ObtenerValorColumna<String>("Descripcion");
            categoria.Estado= dr.ObtenerValorColumna<Int16>("Estado");
            return categoria;
        }
        #endregion

        #region Crud


        public List<ProductoCategoria> ObtenerTodo(ref clsBaseEntidad baseEntidad)
        {
            List<ProductoCategoria> lstCategorias = new List<ProductoCategoria>();
            ProductoCategoria objCategoria;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("ProductoCategoria_Listar", clsConexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objCategoria = new ProductoCategoria();
                        objCategoria = SetEntidad(dr);
                        lstCategorias.Add(objCategoria);
                    }

                }
            }
            catch (Exception ex)
            {
                baseEntidad.Errores.Add(new clsBaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                clsConexion.DisposeCommand(cmd);
            }
            return lstCategorias;
        }



        #endregion
    }
}
