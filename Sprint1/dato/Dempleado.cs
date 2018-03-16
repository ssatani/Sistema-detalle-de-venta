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
    class Dempleado
    {
       
        public void ListarEmpleados(DataGridView datos, List<empleado> empleados)
        {
            empleado empl = new empleado();
            empleados.Clear();
            string procedimiento = "listar_empleado";
            SqlCommand comando = new SqlCommand(procedimiento, conexion.ObtenerConexion());
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            datos.DataSource = dt;
            foreach (DataRow dr in dt.Rows)
            {
                empl.id_empleado = (Int32)dr["id_empleado"];
                empl.nombre = (String)dr["nombre"];
                empl.apellidos = (String)dr["apellidos"];
                empl.sexo = (String)dr["sexo"];
                empl.ci = (String)dr["ci"];
                empl.fono = (String)dr["fono"];
                empl.direccion = (String)dr["direccion"];
                empl.login = (String)dr["login"];
                empl.password = (String)dr["password"];
                empleados.Add(empl);
            }
        }
        public empleado FicharEmpleado(empleado empl)
        {
            string consulta = "fichar_empleado";
            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.Add("@id_empleado", SqlDbType.Int, 0).Value = empl.id_empleado;
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            DataRow row = dt.Rows[0];
            
            empl.nombre = (String)row["nombre"];
            empl.apellidos = (String)row["apellidos"];
            empl.sexo = (String)row["sexo"];
            empl.ci = (String)row["ci"];
            empl.fono = (String)row["fono"];
            empl.direccion = (String)row["direccion"];
            empl.login = (String)row["login"];
            empl.password = (String)row["password"];
           
            return empl;

        }

        public static bool Agregar(empleado empl)
        {
            SqlCommand sql = new SqlCommand("insertar_empleado", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;
            
            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = empl.nombre;
            sql.Parameters.Add("@apellidos", SqlDbType.VarChar, 0).Value = empl.apellidos;
            sql.Parameters.Add("@sexo", SqlDbType.VarChar, 0).Value = empl.sexo ;
            sql.Parameters.Add("@ci", SqlDbType.VarChar, 0).Value = empl.ci ;
            sql.Parameters.Add("@fono", SqlDbType.VarChar, 0).Value = empl.fono ;
            sql.Parameters.Add("@direccion", SqlDbType.VarChar, 0).Value = empl.direccion ;
            sql.Parameters.Add("@login", SqlDbType.VarChar, 0).Value = empl.login ;
            sql.Parameters.Add("@password", SqlDbType.VarChar, 0).Value = empl.password;
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
        public static int Actualizar(empleado empl)
        {
            SqlCommand sql = new SqlCommand("actualizar_empleado", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@id_empleado", SqlDbType.VarChar, 0).Value = empl.id_empleado;
            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = empl.nombre;
            sql.Parameters.Add("@apellidos", SqlDbType.VarChar, 0).Value = empl.apellidos;
            sql.Parameters.Add("@sexo", SqlDbType.VarChar, 0).Value = empl.sexo;
            sql.Parameters.Add("@ci", SqlDbType.VarChar, 0).Value = empl.ci;
            sql.Parameters.Add("@fono", SqlDbType.VarChar, 0).Value = empl.fono;
            sql.Parameters.Add("@direccion", SqlDbType.VarChar, 0).Value = empl.direccion;
            sql.Parameters.Add("@login", SqlDbType.VarChar, 0).Value = empl.login;
            sql.Parameters.Add("@password", SqlDbType.VarChar, 0).Value = empl.password;

            int resul = sql.ExecuteNonQuery();
            return Convert.ToInt32(resul > 0);
        }
        public static int Eliminar(empleado empl)
        {
            SqlCommand sql = new SqlCommand("delete_empleado", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@id_empleado", empl.id_empleado);
            int resul = sql.ExecuteNonQuery();
            return Convert.ToInt32(resul > 0);
        }
    }
}
