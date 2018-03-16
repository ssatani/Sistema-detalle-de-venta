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
    public partial class frm_compra : Form
    {
        //para expansion de la ventana derecha
        int x = 0;
        int y = 0;
        bool ex = true;

        //para la consulta de los datos de productos proveedores y compras
        Dproducto dprod = new Dproducto();
        Dproveedor dprov = new Dproveedor();
        Dcompra dcom = new Dcompra();
        Ddetalle_compra ddet = new Ddetalle_compra();

        //listas de los datos que deseo cargar
        List<compra> lcompra = new List<compra>();
        List<proveedor> lproveedor = new List<proveedor>();
        List<producto> lproducto = new List<producto>();
        List<Detalle_compra> dets_coms = new List<Detalle_compra>();
        //iniciamos objetos nativos que se manejaran en el formulario
        compra com = new compra();
        proveedor prov = new proveedor();
        producto prod = new producto();
        Detalle_compra det_com;

        public frm_compra()
        {
            InitializeComponent();
        }
        //para la ventana derecha
        private void expandir()
        {
            btn_contraer.Text = "< Expandir";
            x = panel_expand.Height;
            y = panel_expand.Width;
            panel_buscar.Width = panel_buscar.Width + y;
            panel_detalle_compra.Width = panel_detalle_compra.Width + y;
            panel_expand.Width = 0;
            ex = false;
        }
        private void contraer()
        {
            btn_contraer.Text = "Contraer >";
            panel_buscar.Width = panel_buscar.Width - y;
            panel_detalle_compra.Width = panel_detalle_compra.Width - y;
            panel_expand.Width = y;
            ex = true;
        }


        private void btn_contraer_Click(object sender, EventArgs e)
        {
            if (ex)
            {
                expandir();
            }
            else
            {
                contraer();
            }
           
        }

        private void btn_fecha_Click(object sender, EventArgs e)
        {
            cargar_fecha();
        }

        private void btn_listar_productos_Click(object sender, EventArgs e)
        {
            cargar_productos();
        }

        private void btn_compras_Click(object sender, EventArgs e)
        {
            cargar_compras();
        }
       

        private void btn_listar_proveedores_Click(object sender, EventArgs e)
        {
            cargar_proveedores();
        }
        
        //aqui se generan las cargas
        private void cargar_fecha()
        {
            DateTime thisDay = DateTime.Today;
            txt_fecha.Text=thisDay.ToString("d");
        }
        public void cargar_compras()
        {
            btn_listar_proveedores.BackColor = Color.White;
            btn_listar_productos.BackColor = Color.White;
            btn_listar_compras.BackColor = Color.SkyBlue;
            panel_desde.Visible = true;
            panel_hasta.Visible = true;
            dcom.Listar_compra(datos_varios, lcompra);
            com=new compra();   //agrego esto mas pork se agrega en el objeto compra y se elimina sin aver seleccionado elemento de la tabla pequeña
        }
        public void cargar_proveedores()
        {
            btn_listar_proveedores.BackColor = Color.SkyBlue;
            btn_listar_productos.BackColor = Color.White;
            btn_listar_compras.BackColor = Color.White;
            panel_desde.Visible = false;
            panel_hasta.Visible = false;
            dprov.ListarProveedores(datos_varios, lproveedor);
        }
        public void cargar_productos()
        {
            btn_listar_proveedores.BackColor = Color.White;
            btn_listar_productos.BackColor = Color.SkyBlue;
            btn_listar_compras.BackColor = Color.White;
            panel_desde.Visible = false;
            panel_hasta.Visible = false;
            dprod.ListarProductos(datos_varios, lproducto);
        }
        private void datos_varios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = datos_varios.Rows[e.RowIndex];
            //product.id_producto = Convert.ToInt32(fila.Cells["id_producto"].Value);
            switch (datos_varios.Tag)
            {
                case "proveedor":
                    prov = lproveedor[e.RowIndex];
                    txt_proveedor.Text = "" + prov.Nombre;
                    break;
                case "compra":
                    com = lcompra[e.RowIndex];
                    cargar_compra(com);
                    break;
                case "producto":
                    det_com = new Detalle_compra();
                    prod = lproducto[e.RowIndex];
                    det_com.Producto=prod;
                    ddet.añadir_detalle_compra(det_com);
                    break;
            }
        }

        private void cargar_compra(compra com)
        {
            txt_fecha.Text = com.Fecha;
            txt_proveedor.Text = com.Proveedor.Id_proveedor+"";
            frm_compra.ActiveForm.Tag = com.Empleado.id_empleado;
            txt_num_doc.Text = com.Num_comprobante+"";
            cmb_tipo_doc.Text = com.Tipo_comprobante;
            
            
            ddet.cargar_detalle_compra(com);
            cargar_datos_calculo();
        }   

       

        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            switch (datos_varios.Tag)
            {
                case "proveedor":
                    dprov.BuscarDatos_proveedores(datos_varios, lproveedor,txt_buscar.Text);
                    break;
                case "compra":
                    dcom.BuscarDatos_compras(datos_varios, lcompra, txt_buscar.Text);
                    break;
                case "producto":
                    dprod.BuscarDatos_productos(datos_varios, lproducto, txt_buscar.Text);
                    break;
            }
        }

        private void frm_compra_Load(object sender, EventArgs e)
        {
            ddet.SetDataGrid(datos_detalle_compra);
            cargar_fecha();
            cargar_configuracion();
        }

        

        private void datos_varios_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
           
        }
        private void datos_detalle_compra_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ddet.eliminar_detalle_compra_list(e.RowIndex);
        }
        int row = 0;
        private void datos_detalle_compra_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            row = e.RowIndex;
            //MessageBox.Show("data " + row);
        }

        private void datos_detalle_compra_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 3:
                    ddet.datos_detalle_compra(e.ColumnIndex, e.RowIndex, datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value.ToString());
                    calculos(e.RowIndex, datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value.ToString(), datos_detalle_compra[5, e.RowIndex].Value.ToString(), datos_detalle_compra[6, e.RowIndex].Value.ToString());
                    break;
                case 5:
                    ddet.datos_detalle_compra(e.ColumnIndex, e.RowIndex, datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value + "");
                    calculos( e.RowIndex, datos_detalle_compra[3, e.RowIndex].Value.ToString(), datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value.ToString(), datos_detalle_compra[6, e.RowIndex].Value.ToString());
                    datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value=numero(datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value.ToString());
                    break;
                case 6:
                    ddet.datos_detalle_compra(e.ColumnIndex, e.RowIndex, datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value + "");
                    calculos(e.RowIndex, datos_detalle_compra[3, e.RowIndex].Value + "", datos_detalle_compra[5, e.RowIndex].Value + "", datos_detalle_compra[6, e.RowIndex].Value + "");
                    datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value = numero(datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value.ToString());
                    break;
                case 7:
                    ddet.datos_detalle_compra(e.ColumnIndex, e.RowIndex, datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value + "");
                    break;
                case 8:
                    ddet.datos_detalle_compra(e.ColumnIndex, e.RowIndex, datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value + "");
                    break;
                case 9:
                    ddet.datos_detalle_compra(e.ColumnIndex, e.RowIndex, datos_detalle_compra[e.ColumnIndex, e.RowIndex].Value + "");
                    break;
            }
            cargar_datos_calculo();
        }
        public void calculos(int y,String dato1,String dato2,String dato3)
        {
            try
            {
                //float n = Convert.ToInt32(dato1) * Convert.ToSingle(numero(dato2)) - (Convert.ToSingle(numero(dato3)) * (Convert.ToInt32(dato1)));
                //float n = Convert.ToInt32(dato1) * Convert.ToSingle(numero(dato2));
                //float n1 = Convert.ToSingle(numero(dato3)) * (Convert.ToInt32(dato1));
                float n1 = Convert.ToSingle(numero(dato2));
                MessageBox.Show("->>"+ n1);
                //para el importe
                //datos_detalle_compra[7, y].Value = (Convert.ToInt32(dato1) * Convert.ToSingle(numero(dato2))-(Convert.ToSingle(numero(dato3))* (Convert.ToInt32(dato1))));
                //para el precio de venta
                //datos_detalle_compra[8, y].Value = Convert.ToSingle(datos_detalle_compra[5, y].Value) + (Convert.ToSingle(datos_detalle_compra[5, y].Value) * 20 / 100);
            }
            catch (Exception e)
            {
                MessageBox.Show("Datos para importe Invalidos "+e.Message);
            }
        }

        private void cargar_datos_calculo()
        {
            lbl_descuento.Text = ddet.getDescuentoTotal();
            lbl_total_compra.Text = ddet.getTotalCompra();
        }       
       
        private void datos_detalle_compra_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            datos_detalle_compra.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected=true;
        }
        

        private void btn_guardar_compra_Click(object sender, EventArgs e)
        {
            if (!txt_proveedor.Text.Equals(""))
            {
                ddet.guardar_detalle_compra(dcom.Agregar_compra(com));
                //MessageBox.Show("->"+dcom.Agregar_compra(com));

                nueva_compra();
            }
            else
            {
                MessageBox.Show(" Aun falta agregar Proveedor ");
            }
            
        }

        private void btn_nueva_compra_Click(object sender, EventArgs e)
        {
            nueva_compra();
        }

        private void btn_imprimir_comprovante_Click(object sender, EventArgs e)
        {

        }

        private void btn_eliminar_compra_Click(object sender, EventArgs e)
        {

            if (com.Id_ingreso > 0)
            {
                if (dcom.Eliminar_compra(com) > 0)
                {
                    cargar_compras();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar.");
                }
                com.Id_ingreso = 0;
            }
            else
            {
                MessageBox.Show("Elija una compra primero.");
            }
        }

        private void txt_fecha_TextChanged(object sender, EventArgs e)
        {
            com.Fecha = txt_fecha.Text;
        }

        private void txt_proveedor_TextChanged(object sender, EventArgs e)
        {
            com.Proveedor = prov;
        }

        private void btn_añadir_proveedor_Click(object sender, EventArgs e)
        {
            cargar_proveedores();
        }

        private void cmb_tipo_doc_TextChanged(object sender, EventArgs e)
        {
            com.Tipo_comprobante = cmb_tipo_doc.Text;
        }

        private void txt_num_doc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                com.Num_comprobante = Convert.ToInt32(txt_num_doc.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Inserte solo Numeros");
                txt_num_doc.Text = "0";
            }
            
        }

        //Esta funcion me ayudara a convertir un string a un numero con 2 decimales
        String numero(String dato)
        {
            float n = Convert.ToSingle(dato);
            return n.ToString("n2");
        }
        void nueva_compra()
        {
            if (btn_nueva_compra.Text.Equals("Nueva Compra"))
            {
                panel_datos.Enabled = true;
                btn_nueva_compra.Text = "Cancelar";
                com.Id_ingreso = 0;
                //para que cargue al empleado su id
                empleado emp = new empleado();
                emp.id_empleado = Convert.ToInt32(frm_compra.ActiveForm.Tag);

                com.Empleado = emp;
                com.Proveedor = prov;
                com.Fecha = txt_fecha.Text;
                com.Tipo_comprobante = cmb_tipo_doc.Text;
                
                try
                {
                    com.Num_comprobante = Convert.ToInt32(txt_num_doc.Text);
                }
                catch (Exception)
                {
                    com.Num_comprobante = 0;
                }
                com.Total = "0";
                com.Estado = true;
                btn_guardar_compra.Enabled = true;
                btn_listar_compras.Enabled = false;
                panel_detalle_compra.Enabled = true;

                ddet.limpiar_datos(datos_detalle_compra);
            }
            else
            {
                panel_datos.Enabled = false;
                btn_listar_compras.Enabled = true;
                btn_guardar_compra.Enabled = false;
                btn_nueva_compra.Text = "Nueva Compra";
                ddet.limpiar_datos(datos_detalle_compra);
            }
        }

        private void calendar_desde_DateChanged(object sender, DateRangeEventArgs e)
        {
            filtro_calendario();
        }

        private void calendar_hasta_DateChanged(object sender, DateRangeEventArgs e)
        {
            filtro_calendario();
        }
        private void filtro_calendario()
        {
            String dato1 = Convert.ToString(calendar_desde.SelectionRange.Start);
            String dato2 = Convert.ToString(calendar_hasta.SelectionRange.Start);
            //MessageBox.Show("" + dato);
            dcom.Listar_compra(datos_varios, lcompra, dato1, dato2);
        }
        private void cargar_configuracion()
        {
            System.Globalization.CultureInfo r = new System.Globalization.CultureInfo("es-ES");
            //r.NumberFormat.CurrencyDecimalSeparator = ".";
            r.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = r;
        }
    }
}
