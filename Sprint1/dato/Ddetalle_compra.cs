using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sprint1.logico;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace Sprint1.dato
{
    public class Ddetalle_compra
    {
        List<Detalle_compra> ds_cs = new List<Detalle_compra>();
        DataTable dt = new DataTable();
        producto productos = new producto();
        DataGridView datos;
        public void SetDataGrid(DataGridView datos_table)
        {
            datos = datos_table;
            //Modificando tabla
            dt.Columns.Add("Nro").ReadOnly = true;
            dt.Columns.Add("Codigo").ReadOnly = true;
            dt.Columns.Add("Nombre").ReadOnly = true;
            dt.Columns.Add("Stock Inicial").ReadOnly= false;
            dt.Columns.Add("Unidades").ReadOnly = true;
            dt.Columns.Add("Precio Compra").ReadOnly = false;
            dt.Columns.Add("Descuento").ReadOnly = false;
            dt.Columns.Add("Importe").ReadOnly = false;
            dt.Columns.Add("Precio Venta").ReadOnly = false;
            dt.Columns.Add("Stock Actual").ReadOnly = false;
            datos.DataSource = dt;
            datos.Columns["Nro"].DefaultCellStyle.BackColor = Color.SkyBlue;
            datos.Columns["Codigo"].DefaultCellStyle.BackColor = Color.SkyBlue;
            datos.Columns["Nombre"].DefaultCellStyle.BackColor = Color.SkyBlue;
            datos.Columns["Unidades"].DefaultCellStyle.BackColor = Color.SkyBlue;
        }
        //con esta funcion elimino todos los datos de la tabla para poder insertar denuevo datos que vendran en una nueva carga realizada por las funciones
        internal void limpiar_datos(DataGridView d_t)
        {
            int e = dt.Rows.Count;
            int r = d_t.Rows.Count;
            int d = ds_cs.Count;
            for (int i = r-1; i >= 0; i--)
            {
                d_t.Rows.RemoveAt(i);
                //eliminar_detalle_compra_dview(i);
            }
        }
        internal void añadir_detalle_compra(Detalle_compra d)
        {
                ds_cs.Add(d);
                DataRow row = dt.NewRow();
                row["Nro"] = (datos.Rows.Count+1);
                row["Codigo"] = d.Producto.codigo;
                row["Nombre"] = d.Producto.nombre;
                row["Stock Inicial"] = d.Stock_inicial;
                row["Unidades"] = d.Producto.Unid.nombre;
                row["Precio Compra"] = d.Precio_compra;
                row["Descuento"] = "0,00";
                row["Importe"] = "0,00";
                row["Precio Venta"] = d.Precio_venta;
                row["Stock Actual"] = d.Stock_actual;
                dt.Rows.Add(row);
        }

        internal void eliminar_detalle_compra_list(int i)
        {
                ds_cs.RemoveAt(i);
        }
        /*internal void eliminar_detalle_compra_dview(int i)
        {
            dt.Rows.RemoveAt(i);
        }*/


        internal void datos_detalle_compra(int columnIndex, int rowIndex, string v)
        {
            switch (columnIndex)
            {
                case 3:
                    try
                    {
                        ds_cs[rowIndex].Stock_inicial = Convert.ToInt32(v);
                    }
                    catch(Exception)
                    {
                        MessageBox.Show("Stock Inicial debe ser entero.");
                    }
                    break;
                case 5:
                    ds_cs[rowIndex].Precio_compra =v;
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    ds_cs[rowIndex].Precio_venta = v;
                    break;
                case 9:
                    try
                    {
                        ds_cs[rowIndex].Stock_actual = Convert.ToInt32(v);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Stock Inicial debe ser entero.");
                    }
                    break;
            }
        }

        public void guardar_detalle_compra(int v)
        {
            SqlCommand sql = new SqlCommand("insertar_detalle_compra", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;
            foreach (Detalle_compra deta_comp in ds_cs){
                sql.Parameters.Clear();
                sql.Parameters.Add("@id_ingreso", SqlDbType.Int, 0).Value = v;
                sql.Parameters.Add("@id_producto", SqlDbType.Int, 0).Value = deta_comp.Producto.id_producto;
                sql.Parameters.Add("@precio_compra", SqlDbType.Money, 0).Value = deta_comp.Precio_compra;
                sql.Parameters.Add("@precio_venta", SqlDbType.Money, 0).Value = deta_comp.Precio_venta;
                sql.Parameters.Add("@stock_inicial", SqlDbType.Int, 0).Value = deta_comp.Stock_inicial;
                sql.Parameters.Add("@stock_actual", SqlDbType.Int, 0).Value = deta_comp.Stock_actual;
                sql.Parameters.Add("@fecha_produccion", SqlDbType.Date, 0).Value = deta_comp.Fecha_produccion;
                sql.Parameters.Add("@fecha_vencimiento", SqlDbType.Date, 0).Value = deta_comp.Fecha_vencimiento;
                sql.ExecuteNonQuery();
            }
        }

        internal void cargar_detalle_compra(compra com)
        {
            limpiar_datos(datos);
            string procedimiento = "fichar_detalle_compra_de_compra";
            SqlCommand comando = new SqlCommand(procedimiento, conexion.ObtenerConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_ingreso", SqlDbType.Int, 0).Value = com.Id_ingreso;
           
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                
                Detalle_compra deta_comp = new Detalle_compra();
                
               
                deta_comp.Id_detalle_ingreso = (Int32)dr["id_detalle_ingreso"];
                deta_comp.Precio_compra = dr["precio_compra"].ToString();
                deta_comp.Precio_venta = dr["precio_venta"].ToString();
                deta_comp.Stock_inicial = (Int32)dr["stock_inicial"];
                deta_comp.Stock_actual = (Int32)dr["stock_actual"];
                deta_comp.Fecha_produccion = dr["fecha_produccion"].ToString();
                deta_comp.Fecha_vencimiento =dr["fecha_vencimiento"].ToString();

                deta_comp.Compra.Id_ingreso = (Int32)dr["compra_id_ingreso"];
                deta_comp.Producto.id_producto = (Int32)dr["producto_id_producto"];
                deta_comp.Producto.codigo = (String)dr["producto_codigo"];
                deta_comp.Producto.nombre = (String)dr["producto_nombre"];
                deta_comp.Producto.Unid.id = (Int32)dr["unidad_id_unidad"];
                deta_comp.Producto.Unid.nombre = (String)dr["unidad_nombre"];
                deta_comp.Producto.Unid.descripcion = (String)dr["unidad_descripcion"];
                añadir_detalle_compra(deta_comp);
            }
        }

        internal string getTotalCompra()
        {

            int e = dt.Rows.Count;
            //int r = d_t.Rows.Count; 7
            int d = ds_cs.Count;
            float acumulador = 0;
            foreach (DataRow dr in dt.Rows)
            {
                //dr["Importe"] = "";
                acumulador = (Convert.ToSingle(dr["Stock inicial"])*Convert.ToSingle(dr["Precio Compra"])) +acumulador;
            }
            return acumulador.ToString("N2");
        }

        internal string getDescuentoTotal()
        {

            int e = dt.Rows.Count;
            //int r = d_t.Rows.Count; 5
            int d = dt.Columns.Count;
            float acumulador = 0;

           

            //datos[7, y].Value
            foreach (DataRow dr in dt.Rows)
            {
                //MessageBox.Show("->" + dr["Descuento"]);
                //acumulador = Convert.ToSingle(dr["Descuento"]) + acumulador;
            }
            //return acumulador.ToString("N2");
            return "0,00";
        }
    }
}
