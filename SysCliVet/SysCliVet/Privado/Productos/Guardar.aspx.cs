using CapaEntidad;
using CapaLibreria.Base;
using CapaLibreria.General;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Productos
{
    public partial class Guardar : Page
    {
        public Int32 vsId
        {
            get { return ViewState["ID"] != null ? (Int32)ViewState["ID"] : default(Int32); }
            set { ViewState["ID"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoCategorias_Obtener();
                ObtenerInformacion();
            }
        }

        private void ObtenerInformacion()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["i"]))
            {
                String id = clsEncriptacion.Desencriptar(Request.QueryString["i"]);
                if (id != String.Empty)
                {
                    vsId = Convert.ToInt32(id);
                    hfProductoId.Value = id;
                    try
                    {
                        clsBaseEntidad baseEntidad = new clsBaseEntidad();
                        Producto objProducto = new Producto();
                        objProducto = clsLogica.Instance.Producto_PorId(ref baseEntidad, vsId);
                        if (objProducto.Id == 0) { Volver(); }
                        MostrarInformacion(objProducto);
                    }
                    catch (Exception ex)
                    {
                    }
                }
                else
                {
                    Volver();
                }
            }
            if (!String.IsNullOrEmpty(Request.QueryString["s"]))
            {
                divStock.Visible = true;
            }
            else
                divStock.Visible = false;
        }

        private void MostrarInformacion(Producto objProducto)
        {
            cmbProductoCategoria.SelectedValue = objProducto.Categoria.Id.ToString();
            txtCodigo.Value = objProducto.Codigo;
            txtDescripcion.Value = objProducto.Descripcion;
            txtCantidadIngreso.Value = objProducto.Stock().ToString();
            txtCantidadIngreso.Disabled = true;
        }

        public void ProductoCategorias_Obtener()
        {
            try
            {
                clsBaseEntidad objBase = new clsBaseEntidad();
                List<ProductoCategoria> lstTiposProducto = new List<ProductoCategoria>();
                lstTiposProducto = clsLogica.Instance.ProductoCategoria_ObtenerTodo(ref objBase);
                cmbProductoCategoria.DataTextField = "Descripcion";
                cmbProductoCategoria.DataValueField = "ID";
                cmbProductoCategoria.DataSource = lstTiposProducto;
                cmbProductoCategoria.DataBind();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean resultado = false;
                clsBaseEntidad objBase = new clsBaseEntidad();
                Producto objProducto = new Producto
                {
                    Id = vsId,
                    Descripcion = txtDescripcion.Value,
                    Codigo = txtCodigo.Value,
                };
                objProducto.Categoria.Id = Convert.ToInt32(cmbProductoCategoria.SelectedValue);
                objProducto.ProductoMovimiento.Cantidad = Convert.ToInt32(txtCantidadIngreso.Value);
                objProducto.ProductoMovimiento.Descripcion = "Registro";
                resultado = clsLogica.Instance.Producto_Guardar(ref objBase, objProducto);
                if (resultado)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"s\"" + ", " + "\"Producto guardado correctamente\"" + ");</script>", false);
                    ObtenerInformacion();
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando el Producto\"" + ");</script>", false);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando el Producto\"" + ");</script>", false);
            }
        }

        public void Volver()
        {
            Response.Redirect("Listar.aspx");
        }

        [WebMethod]
        public static Object ActualizarStock(Int16 tipo, String id, String descripcion, Int32 cantidad)
        {
            Int32 stockActual = 0;

            try
            {
                clsBaseEntidad baseEntidad = new clsBaseEntidad();

                Int32 idProducto = Convert.ToInt32(id);
                cantidad = tipo == 1 ? cantidad : cantidad * -1;

                stockActual = clsLogica.Instance.ProductoMovimiento_ActualizarStock(ref baseEntidad, idProducto, descripcion, cantidad);

                if (baseEntidad.Errores.Count == 0)
                    return new { correcto = true, mensaje = "Stock actualizado correctamente", stockActual };
                else
                    return new { correcto = false, mensaje = "Ha ocurrido un Error actualizando el Stock" };

            }
            catch (Exception)
            {
                return new { correcto = false, mensaje = "Ha ocurrido un error actualizando el Stock [1]" };
            }
        }

    }
}