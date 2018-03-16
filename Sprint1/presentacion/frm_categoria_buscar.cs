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
    public partial class frm_categoria_buscar : Form
    {
        List<categoria> categorias = new List<categoria>();
        categoria cat = new categoria();
        Dcategoria aux = new Dcategoria();

        public frm_categoria_buscar()
        {
            InitializeComponent();
        }

        private void frm_categoria_buscar_Load(object sender, EventArgs e)
        {
            cargar();

        }

        public void cargar()
        {
            aux.ListarCategoria(dataGridView1,categorias);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cat.id > 0)
            {
                if (Dcategoria.Eliminar(cat) != 1)
                {
                }
                cargar();
                return;
            }
            MessageBox.Show("Seleccione una Fila.");
            cargar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_categoria frm_cat = new frm_categoria();
            if (cat.id > 0)
            {
                frm_cat.setdatos(cat, this);
                cargar();
                return;
            }
            MessageBox.Show("Seleccione una Fila.");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_categoria frm_cat = new frm_categoria();
            categoria cate = null;
            frm_cat.setdatos(cate, this);


            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscar.Text.Equals(""))
            {
                cargar();
            }
            else
            {
                aux.BuscarDatos_categoria(dataGridView1, categorias, txt_buscar.Text);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
            //cat.id = Convert.ToInt32(fila.Cells["id_categoria"].Value);
            //cat.nombre = Convert.ToString(fila.Cells["nombre"].Value);
            //cat.descripcion = Convert.ToString(fila.Cells["descripcion"].Value);

            cat.id = categorias[e.RowIndex].id;
            cat.nombre = categorias[e.RowIndex].nombre;
            cat.descripcion = categorias[e.RowIndex].descripcion;
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("entre");
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
            }
        }
    }
}
