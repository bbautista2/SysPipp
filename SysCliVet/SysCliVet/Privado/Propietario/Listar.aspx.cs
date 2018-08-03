﻿using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Propietario
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Propietario_Listar();
        }

        public void Propietario_Listar()
        {
            BaseEntidad baseEntidad = new BaseEntidad();
            DataTable dt = null;
            List<Object> lst = new List<Object>();
            try
            {
                dt = Logica.Instance.Propietario_Listar(ref baseEntidad);

                foreach (DataRow item in dt.Rows)
                {
                    lst.Add(new
                    {
                        Id = HttpUtility.UrlEncode(Encriptacion.Encriptar(item["ID"].ToString())),
                        Nombre = item["Nombre"] + " " + item["Apellidos"],
                        FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"]).ToStringDate(),
                        Direccion = item["Direccion"],
                        Celular = item["Celular"],
                        Telefono = item["Telefono"],
                        Email = item["Email"],
                        Estado = item["Estado"]
                    });
                }

                hfListadoPropietarios.Value = (new JavaScriptSerializer()).Serialize(lst);

            }
            catch (Exception ex)
            {
            }
        }

        [WebMethod]
        public static List<Object> ObtenerPropietarios()
        {
            List<Object> lst = new List<Object>();
            try
            {
                BaseEntidad baseEntidad = new BaseEntidad();
                DataTable dt = Logica.Instance.Propietario_Listar(ref baseEntidad);
                if (baseEntidad.Errores.Count == 0)
                {
                    if (dt != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            lst.Add(new
                            {
                                Id = HttpUtility.UrlEncode(Encriptacion.Encriptar(item["ID"].ToString())),
                                Nombre = item["Nombre"] + " " + item["Apellidos"],
                                FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"]).ToStringDate(),
                                Direccion = item["Direccion"],
                                Celular = item["Celular"],
                                Telefono = item["Telefono"],
                                Email = item["Email"],
                                Estado = item["Estado"]
                            });
                        }
                    }
                }
            }
            catch (Exception)
            {
                lst = null;
            }
            return lst;
        }

        [WebMethod]
        public static Object EliminarPropietario(String id)
        {
            Boolean resultado = false;

            try
            {
                Int32 idPropietario = Convert.ToInt32(Encriptacion.Desencriptar(HttpUtility.UrlDecode(id)));

                BaseEntidad baseEntidad = new BaseEntidad();

                resultado = Logica.Instance.Propietario_EliminarPorId(ref baseEntidad, idPropietario);
                
                if (resultado)
                    return new { Lista = ObtenerPropietarios(), correcto = true, mensaje = "Propietario Eliminado correctamente" };
                else
                    return new { Lista = new List<Object>(), correcto = false, mensaje = "Ha ocurrido un error eliminando el Propietario" };

            }
            catch (Exception)
            {
                return new { Lista = new List<Object>(), correcto = false, mensaje = "Ha ocurrido un error eliminando el Propietario [1]" };
            }
        }


    }
}