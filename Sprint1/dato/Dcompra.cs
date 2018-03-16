using Sprint1.logico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprint1.dato
{
    
    class Dcompra
    {
        //compra compra = new compra();

        public void Listar_compra(DataGridView datos, List<compra> comp)
        {
            comp.Clear();
            string procedimiento = "listar_compra";
            SqlCommand comando = new SqlCommand(procedimiento, conexion.ObtenerConexion());
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);

            DataTable data_grid_model = new DataTable();
            data_grid_model.Columns.Add("Fecha").ReadOnly = true;
            data_grid_model.Columns.Add("Proveedor").ReadOnly = false;
            data_grid_model.Columns.Add("Tipo Comprobante").ReadOnly = true;
            data_grid_model.Columns.Add("Numero Comprobante").ReadOnly = true;
            data_grid_model.Columns.Add("Estado").ReadOnly = true;
            data_grid_model.Columns.Add("Total").ReadOnly = true;
            data_grid_model.Columns.Add("Empleado").ReadOnly = true;
            datos.Tag = "compra";
            datos.DataSource = data_grid_model;

            foreach (DataRow rows in dt.Rows)
            {
                compra compra = new compra();
                compra.Id_ingreso = (Int32)rows["id_ingreso"];
                compra.Fecha = rows["fecha"].ToString();
                compra.Num_comprobante = (Int32)rows["num_comprobante"];
                compra.Tipo_comprobante = (String)rows["tipo_comprobante"];
                compra.Total = rows["total"].ToString();
                if (rows["estado"].ToString().Equals("1"))
                {
                    compra.Estado = true;
                }
                else
                {
                    compra.Estado = false;
                }

                compra.Empleado.id_empleado = (Int32)rows["empleado_id_empleado"];
                compra.Empleado.nombre = (String)rows["empleado_nombre"];
                compra.Empleado.apellidos = (String)rows["empleado_apellidos"];
                compra.Empleado.sexo = (String)rows["empleado_sexo"];
                compra.Empleado.ci = (String)rows["empleado_ci"];
                compra.Empleado.fono = (String)rows["empleado_fono"];
                compra.Empleado.direccion = (String)rows["empleado_direccion"];
                compra.Empleado.login = (String)rows["empleado_login"];

                compra.Proveedor.Id_proveedor = (Int32)rows["proveedor_id_proveedor"];
                compra.Proveedor.Nombre = (String)rows["proveedor_nombre"];
                compra.Proveedor.Sector_comercial = (String)rows["proveedor_sector_comercial"];
                compra.Proveedor.Direccion = (String)rows["proveedor_direccion"];
                compra.Proveedor.Telefono = (String)rows["proveedor_telefono"];

                comp.Add(compra);

                DataRow drw = data_grid_model.NewRow();
                drw["Fecha"] = compra.Fecha;
                drw["Proveedor"] = compra.Proveedor.Nombre;
                drw["Tipo Comprobante"] = compra.Tipo_comprobante;
                drw["Numero Comprobante"] = compra.Num_comprobante;
                if (compra.Estado)
                {
                    drw["Estado"] = "Activo";
                }
                else
                {
                    drw["Estado"] = "Inactivo";
                }
                drw["Total"] = compra.Total;
                drw["Empleado"] = compra.Empleado.nombre+" "+compra.Empleado.apellidos;
                data_grid_model.Rows.Add(drw);
            }
        }
        public List<compra> buscar_compra(List<compra> compra, String palabra)
        {
            List<compra> compras_buscados = new List<compra>();
            foreach (compra c in compra)
            {
                //AQUI BUSCO SI TIENE EN SU CONTENIDO LA PALABRA (palabra) que ando buscando en cada uno de los campos
                if (c.Fecha.Contains(palabra) || c.Proveedor.Nombre.Contains(palabra) || c.Tipo_comprobante.Contains(palabra) || c.Num_comprobante.ToString().Contains(palabra)|| c.Empleado.nombre.Contains(palabra)||c.Total.Contains(palabra))
                {
                    //si encuentra alguno con la palabra que se busca lo añade para ser listado
                    compras_buscados.Add(c);
                }
            }
            return compras_buscados;
        }
        public void BuscarDatos_compras(DataGridView datos, List<compra> compra, String palabra)
        {
            List<compra> nuevos_comp = new List<compra>();
            nuevos_comp = buscar_compra(compra, palabra);
            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Proveedor");
            dt.Columns.Add("Tipo comprobante");
            dt.Columns.Add("Numero comprobante");
            dt.Columns.Add("Descuento");
            dt.Columns.Add("Total");
            dt.Columns.Add("Empleado");

            datos.DataSource = dt;
            foreach (compra c in nuevos_comp)
            {
                DataRow row = dt.NewRow();
                row["Fecha"] = c.Fecha;
                row["Proveedor"] = c.Proveedor;
                row["Tipo comprobante"] = c.Tipo_comprobante;
                row["Numero comprobante"] = c.Num_comprobante;
                row["Descuento"] = "";
                row["Total"] = c.Total;
                row["Empleado"] = c.Empleado.nombre;
                
                dt.Rows.Add(row);
            }
        }
        public int Agregar_compra(compra compra)
        {
            SqlCommand sql = new SqlCommand("insertar_compra", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@id_empleado", SqlDbType.Int, 0).Value = compra.Empleado.id_empleado;
            sql.Parameters.Add("@id_proveedor", SqlDbType.Int, 0).Value = compra.Proveedor.Id_proveedor;
            sql.Parameters.Add("@fecha", SqlDbType.Date, 0).Value = compra.Fecha;
            sql.Parameters.Add("@num_comprobante", SqlDbType.Int, 0).Value = compra.Num_comprobante;
            sql.Parameters.Add("@tipo_comprobante", SqlDbType.VarChar, 0).Value = compra.Tipo_comprobante;
            sql.Parameters.Add("@total", SqlDbType.Money, 0).Value = compra.Total;
            sql.Parameters.Add("@estado", SqlDbType.TinyInt, 0).Value = compra.Estado;

            SqlDataReader rdr = sql.ExecuteReader();
            if (rdr.Read())
            {
                return (int)rdr["insertado"];
            }
            else
            {
                return 0;
            }
        }

        public int Eliminar_compra(compra com)
        {
            SqlCommand sql = new SqlCommand("borrar_compra", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@id_ingreso", com.Id_ingreso);
            int resul = sql.ExecuteNonQuery();
            return Convert.ToInt32(resul > 0);
            
        }

        internal void Listar_compra(DataGridView datos_varios, List<compra> lcompra, string dato1, string dato2)
        {
            lcompra.Clear();
            string procedimiento = "listar_compra_rango";
            SqlCommand comando = new SqlCommand(procedimiento, conexion.ObtenerConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@dato1", dato1);
            comando.Parameters.AddWithValue("@dato2", dato2);
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            datos_varios.DataSource = dt;
            datos_varios.Tag = "compra";
            foreach (DataRow row in dt.Rows)
            {
                compra compra = new compra();
                compra.Id_ingreso = (Int32)row["id_ingreso"];
                compra.Fecha = row["fecha"].ToString();
                compra.Num_comprobante = (Int32)row["num_comprobante"];
                compra.Tipo_comprobante = (String)row["tipo_comprobante"];
                compra.Total = row["total"].ToString();
                compra.Estado = row["estado"].Equals("1");

                compra.Empleado.id_empleado = (Int32)row["empleado_id_empleado"];
                compra.Empleado.nombre = (String)row["empleado_nombre"];
                compra.Empleado.apellidos = (String)row["empleado_apellidos"];
                compra.Empleado.sexo = (String)row["empleado_sexo"];
                compra.Empleado.ci = (String)row["empleado_ci"];
                compra.Empleado.fono = (String)row["empleado_fono"];
                compra.Empleado.direccion = (String)row["empleado_direccion"];
                compra.Empleado.login = (String)row["empleado_login"];
                compra.Empleado.password = (String)row["empleado_password"];

                compra.Proveedor.Id_proveedor = (Int32)row["proveedor_id_proveedor"];
                compra.Proveedor.Nombre = (String)row["proveedor_nombre"];
                compra.Proveedor.Sector_comercial = (String)row["proveedor_sector_comercial"];
                compra.Proveedor.Direccion = (String)row["proveedor_direccion"];
                compra.Proveedor.Telefono = (String)row["proveedor_telefono"];

                lcompra.Add(compra);
            }
        }
    }
}
