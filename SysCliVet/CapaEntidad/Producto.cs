using CapaLibreria.Base;
using System;
using System.Collections.Generic;


namespace CapaEntidad
{
    public class Producto: clsBaseEntidad
    {
        public Int32 CantidadMinima { get; set; }
        public String Codigo { get; set; }
        ProductoCategoria categoria;
        public ProductoCategoria Categoria
        {
            get
            {
                categoria = categoria ?? new ProductoCategoria();
                return categoria;
            }
            set => categoria = value;
        }

        ProductoMovimiento productoMovimiento;
        public ProductoMovimiento ProductoMovimiento
        {
            get
            {
                productoMovimiento = productoMovimiento ?? new ProductoMovimiento();
                return productoMovimiento;
            }
            set => productoMovimiento = value;
        }

        List<ProductoMovimiento> lstProductoMovimiento;
        public List<ProductoMovimiento> LstProductoMovimientos
        {
            get
            {
                lstProductoMovimiento = lstProductoMovimiento ?? new List<ProductoMovimiento>();
                return lstProductoMovimiento;
            }
            set => lstProductoMovimiento = value;
        }

        public Int32 Stock() {
            Int32 stock = 0;
            foreach (ProductoMovimiento movimiento in LstProductoMovimientos) {
                stock += movimiento.Cantidad;
            }
            return stock;
        }

    }
}
