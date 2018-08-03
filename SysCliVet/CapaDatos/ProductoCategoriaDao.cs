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

        public List<ProductoCategoria> ObtenerTodo(ref BaseEntidad baseEntidad)
        {
            List<ProductoCategoria> lstCategorias = new List<ProductoCategoria>();
            ProductoCategoria objCategoria;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("ProductoCategoria_Listar", Conexion.GetConexion())
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
                baseEntidad.Errores.Add(new BaseEntidad.ListaError(ex, "Ha ocurrido un error en la aplicación [3]"));
            }
            finally
            {
                Conexion.DisposeCommand(cmd);
            }
            return lstCategorias;
        }
        
        #endregion
    }
}
