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
    class Dcategoria
    {

        public void ListarCategoria(DataGridView datos,List<categoria> cat)
        {
            string consulta = "listar_categoria";
            cat.Clear();

            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            //datos.DataSource = dt;

            DataTable data_grid_model = new DataTable();
            data_grid_model.Columns.Add("Nro").ReadOnly = true;
            data_grid_model.Columns.Add("Nombre").ReadOnly = true;
            data_grid_model.Columns.Add("Descripcion").ReadOnly = true;
            datos.Tag = "categoria";
            datos.DataSource = data_grid_model;

            foreach (DataRow dr in dt.Rows)
            {
                categoria c = new categoria();
                c.id = (Int32)dr[0];
                c.nombre = (String)dr[1];
                c.descripcion = (String)dr[2];
                cat.Add(c);

                DataRow drw = data_grid_model.NewRow();
                drw["Nro"] = datos.Rows.Count+1;
                drw["Nombre"] = c.nombre;
                drw["Descripcion"] = c.descripcion;
                data_grid_model.Rows.Add(drw);
            }
        }

        public void CargarCategoria(ComboBox datos)
        {
            string consulta = "listar_categoria";

            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            datos.DisplayMember = "nombre";
            datos.ValueMember = "id_categoria";
            datos.DataSource = dt;
        }

        public static bool Agregar(categoria categoria)
        {
            SqlCommand sql = new SqlCommand("insertar_categoria", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = categoria.nombre;
            sql.Parameters.Add("@descripcion", SqlDbType.VarChar, 0).Value = categoria.descripcion;
            
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
        public static int Actualizar(categoria categoria)
        {
            SqlCommand sql = new SqlCommand("editar_categoria", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.AddWithValue("@id_categoria", categoria.id);
            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = categoria.nombre;
            sql.Parameters.Add("@descripcion", SqlDbType.VarChar, 0).Value = categoria.descripcion;

            int resul = sql.ExecuteNonQuery();
            return Convert.ToInt32(resul > 0);

        }
        public static int Eliminar(categoria categoria)
        {
            SqlCommand sql = new SqlCommand("eliminar_categoria", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.AddWithValue("@id_categoria", categoria.id);
            try
            {
                int resul = sql.ExecuteNonQuery();
                return Convert.ToInt32(resul > 0);
            }
            catch(Exception)
            {
                MessageBox.Show("La categoria esta siendo usado por otros datos.");
                return 0;
            }
        }
        public List<categoria> buscar_categoria(List<categoria> categorias, String palabra)
        {
            List<categoria> categorias_buscados = new List<categoria>();
            foreach (categoria c in categorias)
            {
                if (c.nombre.Contains(palabra) || c.descripcion.Contains(palabra))
                {
                    categorias_buscados.Add(c);
                }
            }
            return categorias_buscados;
        }

        public void BuscarDatos_categoria(DataGridView datos, List<categoria> cat, String palabra)
        {

            List<categoria> nuevos_cat = new List<categoria>();

            nuevos_cat = buscar_categoria(cat, palabra);

            DataTable dt = new DataTable();
            dt.Columns.Add("Nro");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripción");
            datos.DataSource = dt;
            foreach (categoria c in nuevos_cat)
            {
                DataRow row = dt.NewRow();
                row["Nro"] = datos.Rows.Count+1;
                row["Nombre"] = c.nombre;
                row["Descripción"] = c.descripcion;
                dt.Rows.Add(row);
            }


        }
    }
}
