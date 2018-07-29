using CapaEntidad;
using CapaLibreria.Base;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SysCliVet.Privado.Productos
{
    public partial class Guardar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductoCategorias_Obtener();
        }

        public void ProductoCategorias_Obtener() {
            try
            {
                clsBaseEntidad objBase = new clsBaseEntidad();
                List<ProductoCategoria> lstTiposCita = new List<ProductoCategoria>();
                lstTiposCita = clsLogica.Instance.ProductoCategoria_ObtenerTodo(ref objBase);
                cmbProductoCategoria.DataTextField = "Descripcion";
                cmbProductoCategoria.DataValueField = "ID";
                cmbProductoCategoria.DataSource = lstTiposCita;
                cmbProductoCategoria.DataBind();
            } catch(Exception ex)
            {
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                Boolean resultado = false;
                clsBaseEntidad objBase = new clsBaseEntidad();
                Producto objProducto = new Producto
                {
                    Descripcion = txtDescripcion.Value,
                    Codigo = txtCodigo.Value,
                    CantidadMinima = Convert.ToInt32(txtCantidadMinima.Value)
            };
                objProducto.Categoria.Id = Convert.ToInt32(cmbProductoCategoria.SelectedValue); 
                objProducto.ProductoMovimiento.Cantidad = Convert.ToInt32(txtCantidadIngreso.Value);
                objProducto.ProductoMovimiento.PrecioCosto = Convert.ToDecimal(txtPrecioCosto.Value);
                resultado = clsLogica.Instance.Producto_Guardar(ref objBase, objProducto);
                if (resultado)
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"s\"" + ", " + "\"Producto guardado correctamente\"" + ");</script>", false);
               
                }
                else
                {
                    ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando el Producto\"" + ");</script>", false);
                }
            } catch (Exception ex) {
                ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>FN_Mensaje(" + "\"e\"" + ", " + "\"Ha ocurrido un error guardando el Producto\"" + ");</script>", false);
            }
        }
    }
}