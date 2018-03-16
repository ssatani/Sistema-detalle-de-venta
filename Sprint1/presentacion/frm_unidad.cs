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
    public partial class frm_unidad : Form
    {
       
        unidad uni;
        frm_unidad_buscar frm_uni_bus;
        public frm_unidad()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string sResultados = ValidarDatos();
                if (sResultados == "")
                {

                    if (uni.id > 0)
                    {
                        uni.nombre = txtNombre.Text;
                        uni.descripcion = txtDescripcion.Text;
                        if (Dunidad.Actualizar(uni) == 1)
                        {
                            MessageBox.Show("Datos Actualizados correctamente");
                            frm_uni_bus.cargar();
                            this.Hide();

                        }

                    }
                    else
                    {
                        uni.nombre = txtNombre.Text;
                        uni.descripcion = txtDescripcion.Text;
                        if (Dunidad.Agregar(uni))
                        {
                            MessageBox.Show("Datos insertados correctamente");
                            frm_uni_bus.cargar();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }
        internal void setdatos(unidad un, frm_unidad_buscar frm_unidad_buscar)
        {
            frm_uni_bus = frm_unidad_buscar;
            if (un == null)
            {
                un = new unidad();
                uni = un;
                this.Show();
            }
            else
            {
                uni = un;
                txtNombre.Text = uni.nombre;
                txtDescripcion.Text = uni.descripcion;
                this.Show();
            }
        }

        private void frm_unidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_unidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Escape))
            {
                this.Close();
            }
        }

        private void frm_unidad_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
