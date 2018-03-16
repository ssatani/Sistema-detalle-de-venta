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
    public partial class frm_categoria : Form
    {
        categoria cat;
        frm_categoria_buscar frm_cat_bus;
        public frm_categoria()
        {
            InitializeComponent();
        }

        private void frm_categoria_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string sResultados = ValidarDatos();
                if (sResultados == "")
                {
                    
                    if (cat.id > 0)
                    {
                        cat.nombre = txtNombre.Text;
                        cat.descripcion = txtDescripcion.Text;
                        if (Dcategoria.Actualizar(cat) == 1)
                        {
                            //MessageBox.Show("Datos Actualizados correctamente");
                            frm_cat_bus.cargar();
                            this.Hide();
                            
                        }

                    }
                    else
                    {
                        cat.nombre = txtNombre.Text;
                        cat.descripcion = txtDescripcion.Text;
                        if (Dcategoria.Agregar(cat))
                        {
                            //MessageBox.Show("Datos insertados correctamente");
                            frm_cat_bus.cargar();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Datos repetidos no se puede insertar.");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Faltan Datos! \n" + sResultados);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        internal void setdatos(categoria cate, frm_categoria_buscar frm_categoria_buscar)
        {
            frm_cat_bus = frm_categoria_buscar;
            if (cate == null)
            {
                cate = new categoria();
                cat = cate;
                this.Show();
            }
            else
            {
                cat = cate;
                txtNombre.Text = cat.nombre;
                txtDescripcion.Text = cat.descripcion;
                this.Show();
            }
        }


        public string ValidarDatos()
        {
            string Resultados = "";
            if (txtNombre.Text == "")
            {
                Resultados = Resultados + "Nombre \n";
            }
            if (txtDescripcion.Text == "")
            {
                Resultados = Resultados + "Descripcion \n";
            }
            return Resultados;
        }

        private void frm_categoria_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void frm_categoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_categoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_categoria_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
