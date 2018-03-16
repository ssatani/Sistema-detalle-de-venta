using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sprint1.dato
{

    class conexion
    {

        public static SqlConnection ObtenerConexion()
        {
            //DESKTOP-0BO0MGN\CYBELION
            SqlConnection conectar = new SqlConnection(@"Data Source=DESKTOP-0BO0MGN\CYBELION;Initial Catalog=bd_VentasMerlo;Integrated Security=True");
            conectar.Open();
            return conectar;
        }
    }
}
