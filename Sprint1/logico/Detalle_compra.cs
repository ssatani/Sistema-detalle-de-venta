using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1.logico
{
    public class Detalle_compra
    {
        private compra compra;
        private producto producto;
        private int id_detalle_ingreso;
        private String precio_compra;
        private String precio_venta;
        private int stock_inicial;
        private int stock_actual;
        private String fecha_produccion;
        private String fecha_vencimiento;

        public Detalle_compra() {
            DateTime thisDay = DateTime.Now;
            compra = new compra();
            producto = new producto();
            id_detalle_ingreso = 0;
            precio_compra = "0.00";
            Precio_venta = "0.00";
            stock_inicial = 0;
            stock_actual = 0;
            fecha_produccion = thisDay.ToString("d");
            Fecha_vencimiento = thisDay.ToString("d");
        }
        

        public compra Compra { get => compra; set => compra = value; }
        public producto Producto { get => producto; set => producto = value; }
        public int Id_detalle_ingreso { get => id_detalle_ingreso; set => id_detalle_ingreso = value; }
        public string Precio_compra { get => precio_compra; set => precio_compra = value; }
        public string Precio_venta { get => precio_venta; set => precio_venta = value; }
        public int Stock_inicial { get => stock_inicial; set => stock_inicial = value; }
        public int Stock_actual { get => stock_actual; set => stock_actual = value; }
        public string Fecha_produccion { get => fecha_produccion; set => fecha_produccion = value; }
        public string Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
    }
}
