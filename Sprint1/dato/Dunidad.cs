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
    class Dunidad
    {
        DataGridView dt_view;

        public void ListarUnidad(DataGridView datos,List<unidad> uni)
        {
            string consulta = "listar_unidad";
            uni.Clear();
            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);

            DataTable data_grid_model = new DataTable();
            data_grid_model.Columns.Add("Nro").ReadOnly = true;
            data_grid_model.Columns.Add("Nombre").ReadOnly = true;
            data_grid_model.Columns.Add("Descripcion").ReadOnly = true;
            datos.Tag = "unidad";
            datos.DataSource = data_grid_model;

            foreach (DataRow dr in dt.Rows)
            {
                unidad u = new unidad();
                u.id = (Int32)dr[0];
                u.nombre = (String)dr[1];
                u.descripcion = (String)dr[2];
                uni.Add(u);

                DataRow drw = data_grid_model.NewRow();
                drw["Nro"] = (datos.Rows.Count + 1) + "";
                drw["Nombre"] = u.nombre;
                drw["Descripcion"] = u.descripcion;
                data_grid_model.Rows.Add(drw);
                
            }
        }


        public void CargarUnidad(ComboBox datos)
        {
            string consulta = "listar_unidad";

            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            datos.DisplayMember = "nombre";
            datos.ValueMember = "id_unidad";
            datos.DataSource = dt;
        }
        public static bool Agregar(unidad unidad)
        {
            SqlCommand sql = new SqlCommand("insertar_unidad", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = unidad.nombre;
            sql.Parameters.Add("@descripcion", SqlDbType.VarChar, 0).Value = unidad.descripcion;

            try
            {
                int resultado = sql.ExecuteNonQuery();
                return resultado > 0;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public static int Actualizar(unidad unidad)
        {
            SqlCommand sql = new SqlCommand("editar_unidad", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.AddWithValue("@id_unidad", unidad.id);
            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = unidad.nombre;
            sql.Parameters.Add("@descripcion", SqlDbType.VarChar, 0).Value = unidad.descripcion;

            int resul = sql.ExecuteNonQuery();
            return Convert.ToInt32(resul > 0);

        }
        public static int Eliminar(unidad unidad)
        {
            SqlCommand sql = new SqlCommand("eliminar_unidad", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.AddWithValue("@id_unidad", unidad.id);
            try
            {
                int resul = sql.ExecuteNonQuery();
                return Convert.ToInt32(resul > 0);
            }
            catch (Exception)
            {
                MessageBox.Show("La Unidad esta siendo usado por otros datos.");
                return 0;
            }

        }

        public List<unidad> buscar_unidad(List<unidad> unidades, String palabra)
        {
            List<unidad> unidades_buscados = new List<unidad>();
            foreach (unidad u in unidades)
            {
                if (u.nombre.Contains(palabra) || u.descripcion.Contains(palabra))
                {
                    unidades_buscados.Add(u);
                }
            }
            return unidades_buscados;
        }

        public void BuscarDatos_unidad(DataGridView datos, List<unidad> uni, String palabra)
        {
            List<unidad> nuevos_uni = new List<unidad>();
            nuevos_uni = buscar_unidad(uni, palabra);
            DataTable dt = new DataTable();
            dt.Columns.Add("Nro");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");
            datos.DataSource = dt;
            foreach (unidad u in nuevos_uni)
            {
                DataRow row = dt.NewRow();
                row["Nro"] = datos.Rows.Count+1;
                row["Nombre"] = u.nombre;
                row["Descripcion"] = u.descripcion;
                dt.Rows.Add(row);

            }
        }
    }
}
