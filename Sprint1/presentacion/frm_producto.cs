using Sprint1.dato;
using Sprint1.logico;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprint1
{
    public partial class frm_producto : Form
    {
        List<producto> productos = new List<producto>();
        producto product = new producto();
        Dproducto prod = new Dproducto();

        public frm_producto()
        {
            InitializeComponent();
        }


        private void frm_producto_Load(object sender, EventArgs e)
        {
            cargar();
        }

        public void cargar()
        {
           
            prod.ListarProductos(datos_productos,productos);
        }

        private void datos_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            product.id_producto = productos[e.RowIndex].id_producto;
            product.codigo = productos[e.RowIndex].codigo;
            product.nombre = productos[e.RowIndex].nombre;
            product.descripcion = productos[e.RowIndex].descripcion;
            product.imagen = productos[e.RowIndex].imagen;
            product.Cate = productos[e.RowIndex].Cate;
            product.Unid = productos[e.RowIndex].Unid;
    }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            if (product.id_producto > 0)
            {
                frm_producto_nuevo frm_prod_nue = new frm_producto_nuevo();
                frm_prod_nue.setDatos(product, this);
               
            }
            else
            {
                MessageBox.Show("Seleccione un item de la tabla para editar.");

            }
           
        }


        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            frm_producto_nuevo frm_prod_nue = new frm_producto_nuevo();
            producto p = new producto();
            frm_prod_nue.setDatos(p, this);
           
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            
            if (product.id_producto > 0)
            {

                if (Dproducto.Eliminar(product) != 1)
                {
                    //MessageBox.Show("Datos Eliminados correctamente");
                }
                cargar();
                return;
            }
            else
            {
                MessageBox.Show("Seleccione un item de la tabla para Eliminar.");

            }
        }

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Equals(""))
            {
                cargar();
            }
            else
            {
                prod.BuscarDatos_productos(datos_productos, productos, txt_buscar.Text);
            }
            
        }
    }
}
