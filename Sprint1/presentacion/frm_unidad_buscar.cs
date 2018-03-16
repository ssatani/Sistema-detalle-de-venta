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

namespace Sprint1.presentacion
{
    public partial class frm_unidad_buscar : Form
    {
        List<unidad> unidades = new List<unidad>();
        unidad uni = new unidad();
        Dunidad aux = new Dunidad();

        public frm_unidad_buscar()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frm_unidad frm_uni = new frm_unidad();
            unidad uni = null;
            frm_uni.setdatos(uni, this);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frm_unidad frm_uni = new frm_unidad();
            if (uni.id > 0)
            {
                frm_uni.setdatos(uni, this);
                cargar();
                return;
            }
            MessageBox.Show("Seleccione una Fila.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (uni.id > 0)
            {
                if (Dunidad.Eliminar(uni) != 1)
                {
                   
                }
                cargar();
                return;
            }
            MessageBox.Show("Seleccione una Fila.");
            cargar();
        }
        public void cargar()
        {
            aux.ListarUnidad(datos_unidad,unidades);
            datos_unidad.AllowUserToAddRows = false;
        }

        private void frm_unidad_buscar_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void datos_unidad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*DataGridViewRow fila = datos_unidad.Rows[e.RowIndex];
            uni.id = Convert.ToInt16(fila.Cells["id_unidad"].Value);
            uni.nombre = Convert.ToString(fila.Cells["nombre"].Value);
            uni.descripcion = Convert.ToString(fila.Cells["descripcion"].Value);*/
            uni.id = unidades[e.RowIndex].id;
            uni.nombre = unidades[e.RowIndex].nombre;
            uni.descripcion = unidades[e.RowIndex].descripcion;
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            if (txt_Buscar.Text.Equals(""))
            {
                cargar();
            }
            else
            {
                aux.BuscarDatos_unidad(datos_unidad, unidades, txt_Buscar.Text);
            }
        }
    }
}
