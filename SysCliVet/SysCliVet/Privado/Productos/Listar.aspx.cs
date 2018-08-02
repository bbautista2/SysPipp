using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using MessagingToolkit.QRCode.Codec;
using SysCliVet.src.app_code;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;

namespace SysCliVet.Privado.Productos
{
    public partial class Listar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Producto_Listar();
        }

        public void Producto_Listar()
        {
            clsBaseEntidad baseEntidad = new clsBaseEntidad();
            List<Producto> lstProductos = null;
            List<Object> lst = new List<Object>();
            try
            {
                lstProductos = clsLogica.Instance.Producto_Listar(ref baseEntidad);

                foreach (Producto item in lstProductos)
                {
                    var Producto = new
                    {
                        Id = HttpUtility.UrlEncode(clsEncriptacion.Encriptar(item.Id.ToString())),
                        Categoria = item.Categoria.Descripcion,
                        item.Descripcion,
                        Stock = item.Stock().ToString(),
                        item.Codigo
                    };
                    lst.Add(Producto);
                }

                hfListadoProductos.Value = (new JavaScriptSerializer()).Serialize(lst);

            }
            catch (Exception ex)
            {

            }
        }

        [WebMethod]
        public static Object EliminarProducto(String id)
        {
            Boolean resultado = false;

            try
            {
                Int32 idProducto = Convert.ToInt32(clsEncriptacion.Desencriptar(HttpUtility.UrlDecode(id)));

                clsBaseEntidad baseEntidad = new clsBaseEntidad();

                resultado = clsLogica.Instance.Producto_EliminarPorId(ref baseEntidad, idProducto);

                if (resultado)
                    return new { Lista = ObtenerProductos(), correcto = true, mensaje = "Producto Eliminado Correctamente" };
                else
                    return new { Lista = new List<Object>(), correcto = false, mensaje = "Ha ocurrido un Error Eliminando el Producto" };

            }
            catch (Exception)
            {
                return new { Lista = new List<Object>(), correcto = false, mensaje = "Ha ocurrido un error eliminando el producto [1]" };
            }
        }

        [WebMethod]
        public static List<Object> ObtenerProductos()
        {
            List<Object> lst = new List<Object>();
            try
            {
                clsBaseEntidad baseEntidad = new clsBaseEntidad();
                List<Producto> lstProductos = null;
                lstProductos = clsLogica.Instance.Producto_Listar(ref baseEntidad);
                if (baseEntidad.Errores.Count == 0)
                {
                    if (lstProductos != null)
                    {
                        foreach (Producto item in lstProductos)
                        {
                            lst.Add(new
                            {
                                Id = HttpUtility.UrlEncode(clsEncriptacion.Encriptar(item.Id.ToString())),
                                Categoria = item.Categoria.Descripcion,
                                item.Descripcion,
                                Stock = item.Stock().ToString()
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

        protected void btnDescargarQr_Click(object sender, EventArgs e)
        {
            DescargarQr();
        }

        public void DescargarQr()
        {
            try
            {
                String url = Config.UrlDomain + "Privado/Productos/Guardar.aspx?i=" + hfProductoId.Value + "&s=1";
                String codigo = hfCodigo.Value;
                QRCodeEncoder qrEncoder = new QRCodeEncoder();
                Bitmap img = qrEncoder.Encode(url);
                System.Drawing.Image imgQr = img;

                MemoryStream ms = new MemoryStream();
                imgQr.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                byte[] imagenBytes = ms.ToArray();
                HttpContext.Current.Response.AddHeader("Content-disposition", "attachment; filename=" + "CodigoQr_" + codigo + ".png");
                HttpContext.Current.Response.ContentType = "image/png";
                HttpContext.Current.Response.BinaryWrite(imagenBytes);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.SuppressContent = true;
                HttpContext.Current.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {

            }
        }
    }
}