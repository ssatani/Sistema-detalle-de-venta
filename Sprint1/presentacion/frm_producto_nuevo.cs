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
    public partial class frm_producto_nuevo : Form
    {
        producto product;
        Dproducto Dproduct = new Dproducto();
        frm_producto frm_prod;
        public frm_producto_nuevo()
        {
            InitializeComponent();
        }

        private void frm_producto_nuevo_Load(object sender, EventArgs e)
        {
            Dcategoria cat = new Dcategoria();
            Dunidad uni = new Dunidad();
            cat.CargarCategoria(cmb_categoria);
            uni.CargarUnidad(cmb_unidad);
            
        }

        internal void setDatos(producto p, frm_producto frm_producto)
        {
            product = p;
            frm_prod = frm_producto;
            if (product.id_producto>0)
            {
                //MessageBox.Show(product.id_producto+"<-");
                product = Dproduct.FicharProducto(product);
                // MessageBox.Show(product.nombre);
                txt_codigo.Text = product.codigo;
                txt_nombre.Text = product.nombre;
                txt_descripcion.Text = product.descripcion;
                txt_image.Image = product.imagen;
                cmb_categoria.SelectedValue = product.Cate.id;
                cmb_unidad.SelectedValue = product.Unid.id;
               
            }
            else
            {
                //MessageBox.Show("aqui es nuevo");
            }
            this.Show();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string sResultados = ValidarDatos();
                if (sResultados == "")
                {
                    //MessageBox.Show("->"+product.id_producto);

                    if (product.id_producto > 0)
                    {
                        product.codigo = txt_codigo.Text;
                        product.nombre = txt_nombre.Text;
                        product.descripcion = txt_descripcion.Text;
                        product.imagen = txt_image.Image;
                        product.Cate.id = (int)cmb_categoria.SelectedValue;
                        product.Unid.id = (int)cmb_unidad.SelectedValue;
                        if (Dproducto.Actualizar(product) == 1)
                        {
                            MessageBox.Show("Datos Actualizados correctamente");
                            frm_prod.cargar();
                            this.Hide();

                        }

                    }
                    else
                    {
                        product.codigo = txt_codigo.Text;
                        product.nombre = txt_nombre.Text;
                        product.descripcion = txt_descripcion.Text;
                        product.imagen = txt_image.Image;
                        product.Cate.id = (int)cmb_categoria.SelectedValue;
                        product.Unid.id = (int)cmb_unidad.SelectedValue;

                        if (Dproducto.Agregar(product))
                        {
                            MessageBox.Show("Datos insertados correctamente.");
                            frm_prod.cargar();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Error en la insercion de datos."+ cmb_categoria.SelectedValue + "."+ cmb_unidad.SelectedValue );

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

        private void txt_image_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string imagen = openFileDialog1.FileName;
                    txt_image.Image = Image.FromFile(imagen);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
            
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Hide();
        }
        public string ValidarDatos()
        {
            string Resultados = "";
            if (txt_codigo.Text == "")
            {
                Resultados = Resultados + "Codigo \n";
            }
            if (txt_nombre.Text == "")
            {
                Resultados = Resultados + "Nombre \n";
            }
            if (txt_descripcion.Text == "")
            {
                Resultados = Resultados + "Descripcion \n";
            }
            return Resultados;
        }
    }
}
