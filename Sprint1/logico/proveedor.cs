using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint1.logico
{
    public class proveedor
    {
        private int id_proveedor;
        private String nombre;
        private String sector_comercial;
        private String direccion;
        private String telefono;

        public int Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sector_comercial { get => sector_comercial; set => sector_comercial = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
    }
}
