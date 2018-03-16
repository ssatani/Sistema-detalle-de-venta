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
    class Dproveedor
    {
        //proveedor prov = new proveedor();
        public void ListarProveedores(DataGridView datos, List<proveedor> proveedor)
        {
            proveedor.Clear();
            string procedimiento = "listar_proveedor";
            SqlCommand comando = new SqlCommand(procedimiento, conexion.ObtenerConexion());
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);

            //cargando nuevo modelo de datos
            DataTable data_grid_model = new DataTable();
            data_grid_model.Columns.Add("Nombre").ReadOnly = true;
            data_grid_model.Columns.Add("Sector comercial").ReadOnly = false;
            data_grid_model.Columns.Add("Dirección").ReadOnly = true;
            data_grid_model.Columns.Add("Telefono").ReadOnly = true;
            datos.Tag = "proveedor";
            datos.DataSource = data_grid_model;

            foreach (DataRow dr in dt.Rows)
            {
                proveedor prov = new proveedor();
                prov.Id_proveedor = (Int32)dr["id_proveedor"];
                prov.Nombre = (String)dr["nombre"];
                prov.Sector_comercial = (String)dr["sector_comercial"];
                prov.Direccion = (String)dr["direccion"];
                prov.Telefono = (String)dr["telefono"];
                proveedor.Add(prov);

                DataRow row = data_grid_model.NewRow();
                row["Nombre"] = prov.Nombre;
                row["Sector comercial"] = prov.Sector_comercial;
                row["Dirección"] = prov.Direccion;
                row["Telefono"] = prov.Telefono;
                data_grid_model.Rows.Add(row);
            }
        }
        public proveedor FicharProveedor(proveedor prov)
        {
            string consulta = "fichar_proveedor";
            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_proveedor", SqlDbType.Int, 0).Value = prov.Id_proveedor;
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            DataRow row = dt.Rows[0];

            prov.Id_proveedor = (Int32)row["id_proveedor"];
            prov.Nombre = (String)row["nombre"];
            prov.Sector_comercial = (String)row["sector_comercial"];
            prov.Direccion = (String)row["direccion"];
            prov.Telefono = (String)row["telefono"];
            return prov;
        }

        public static bool Agregar(proveedor prov)
        {
            SqlCommand sql = new SqlCommand("insertar_proveedor", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = prov.Nombre;
            sql.Parameters.Add("@sector_comercial", SqlDbType.VarChar, 0).Value = prov.Sector_comercial;
            sql.Parameters.Add("@direccion", SqlDbType.VarChar, 0).Value = prov.Direccion;
            sql.Parameters.Add("@telefono", SqlDbType.VarChar, 0).Value = prov.Telefono;
            try
            {
                int resultado = sql.ExecuteNonQuery();
                return resultado > 0;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static int Actualizar(proveedor prov)
        {
            SqlCommand sql = new SqlCommand("actualizar_proveedor", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@id_proveedor", SqlDbType.VarChar, 0).Value = prov.Id_proveedor;
            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = prov.Nombre;
            sql.Parameters.Add("@sector_comercial", SqlDbType.VarChar, 0).Value = prov.Sector_comercial;
            sql.Parameters.Add("@direccion", SqlDbType.VarChar, 0).Value = prov.Direccion;
            sql.Parameters.Add("@telefono", SqlDbType.VarChar, 0).Value = prov.Telefono;

            int resul = sql.ExecuteNonQuery();
            return Convert.ToInt32(resul > 0);
        }
        public static int Eliminar(proveedor prov)
        {
            SqlCommand sql = new SqlCommand("delete_proveedor", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@id_proveedor", prov.Id_proveedor);
            int resul = sql.ExecuteNonQuery();
            return Convert.ToInt32(resul > 0);
        }
        public List<proveedor> buscar_proveedor(List<proveedor> proveedor, String palabra)
        {
            List<proveedor> proveedores_buscados = new List<proveedor>();
            foreach (proveedor p in proveedor)
            {
                //AQUI BUSCO SI TIENE EN SU CONTENIDO LA PALABRA (palabra) que ando buscando en cada uno de los campos
                if (p.Nombre.Contains(palabra) || p.Sector_comercial.Contains(palabra) || p.Direccion.Contains(palabra) || p.Sector_comercial.Contains(palabra))
                {
                    //si encuentra alguno con la palabra que se busca lo añade para ser listado
                    proveedores_buscados.Add(p);
                }
            }
            return proveedores_buscados;
        }
        public void BuscarDatos_proveedores(DataGridView datos, List<proveedor> prov, String palabra)
        {
            List<proveedor> nuevos_prov = new List<proveedor>();
            nuevos_prov = buscar_proveedor(prov, palabra);
            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Sector Comercial");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("Telefono");
            datos.DataSource = dt;
            foreach (proveedor p in nuevos_prov)
            {
                DataRow row = dt.NewRow();
                row["Nombre"] = p.Nombre;
                row["Sector Comercial"] = p.Sector_comercial;
                row["Direccion"] = p.Direccion;
                row["Telefono"] = p.Telefono;
                dt.Rows.Add(row);
            }
        }
    }
}
