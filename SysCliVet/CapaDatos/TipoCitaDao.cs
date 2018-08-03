﻿using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaLibreria.Conexiones;

namespace CapaDatos
{
    public class TipoCitaDao
    {

        #region Singleton
        private static TipoCitaDao instance = null;
        public static TipoCitaDao Instance
        {
            get
            {
                if (instance == null)
                    instance = new TipoCitaDao();
                return instance;
            }
        }
        #endregion
        #region Llenar Entidades
        public TipoCita SetEntidad(SqlDataReader dr)
        {
            TipoCita tipoCita = new TipoCita();
            tipoCita.Id = dr.ObtenerValorColumna<Int16>("ID");
            tipoCita.Nombre = dr.ObtenerValorColumna<String>("Nombre");
            tipoCita.Estado= dr.ObtenerValorColumna<Int16>("Estado");
            tipoCita.Descripcion= dr.ObtenerValorColumna<String>("Descripcion");
            return tipoCita;
        }
        #endregion

        public List<TipoCita> ObtenerTodo(ref BaseEntidad baseEntidad)
        {
            List<TipoCita> lstTiposCita = new List<TipoCita>();
            TipoCita objTipoCita;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                cmd = new SqlCommand("TipoCita_Listar", Conexion.GetConexion())
                {
                    CommandType = CommandType.StoredProcedure
                };               
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        objTipoCita = new TipoCita();
                        objTipoCita = SetEntidad(dr);
                        lstTiposCita.Add(objTipoCita);
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
            return lstTiposCita;
        }
    }
}
