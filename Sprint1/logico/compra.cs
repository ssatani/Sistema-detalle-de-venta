using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1.logico
{
    public class compra
    {
        private proveedor proveedor=new proveedor();
        private empleado empleado=new empleado();

        private int id_ingreso;
        private String fecha;
        private int num_comprobante;
        private String tipo_comprobante;
        private String total;
        private Boolean estado;

        public proveedor Proveedor { get => proveedor; set => proveedor = value; }
        public empleado Empleado { get => empleado; set => empleado = value; }
        public int Id_ingreso { get => id_ingreso; set => id_ingreso = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Num_comprobante { get => num_comprobante; set => num_comprobante = value; }
        public string Tipo_comprobante { get => tipo_comprobante; set => tipo_comprobante = value; }
        public string Total { get => total; set => total = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
