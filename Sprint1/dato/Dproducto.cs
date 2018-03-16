using Sprint1.logico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sprint1.dato
{
    class Dproducto
    {
        //categoria cate = new categoria();
        //unidad unid = new unidad();
        
        public void ListarProductos(DataGridView datos,List<producto> productos)
        {
            //limpiamos la lista de los productos para rellenarlo con los nuevos datos que en la base de datos se alla llenado
            productos.Clear();
            string consulta = "listar_productos";
            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();

            da.Fill(dt);
           
            datos.Tag = "producto";
            

            DataTable data_grid_model = new DataTable();
            data_grid_model.Columns.Add("Codigo").ReadOnly = true;
            data_grid_model.Columns.Add("Nombre").ReadOnly = true;
            data_grid_model.Columns.Add("Descripción").ReadOnly = false;
            data_grid_model.Columns.Add("Unidad").ReadOnly = true;
            data_grid_model.Columns.Add("Categoria").ReadOnly = true;
            data_grid_model.Columns.Add("Stock").ReadOnly = true;
            datos.DataSource = data_grid_model;

            foreach (DataRow dr in dt.Rows)
            {
                producto p = new producto();
                p.id_producto = (Int32)dr["id_producto"];
                p.codigo = (String)dr["codigo"];
                p.nombre= (String)dr["nombre"];
                p.descripcion= (String)dr["descripcion"];
                try
                {
                    byte[] imageBuffer = (byte[])dr["imagen"];
                    System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                    p.imagen = Image.FromStream(ms);
                }
                catch(Exception)
                {
                    p.imagen = null;
                }
                p.Cate.id = (Int32)dr["categoria_id_categoria"];
                p.Cate.nombre = (String)dr["categoria_nombre"];
                p.Cate.descripcion = (String)dr["categoria_descripcion"];
                p.Unid.id = (Int32)dr["unidad_id_unidad"];
                p.Unid.nombre=(String)dr["unidad_nombre"];
                p.Unid.descripcion= (String)dr["unidad_descripcion"];
                
                productos.Add(p);

                DataRow row = data_grid_model.NewRow();
                row["Codigo"] = p.codigo;
                row["Nombre"] = p.nombre;
                row["Descripción"] = p.descripcion;
                row["Unidad"] = p.Unid.descripcion;
                row["Categoria"] = p.Cate.descripcion;
                row["Stock"] = dr["stock"].ToString();
                data_grid_model.Rows.Add(row);
            }
        }
        public producto FicharProducto(producto prod)
        {
            string consulta = "fichar_producto";
            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@id_producto", SqlDbType.Int, 0).Value = prod.id_producto;
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);

            DataRow row = dt.Rows[0];
            producto p = new producto();

            p.id_producto = (Int32)row["id_producto"];
            p.codigo = (String)row["codigo"];
            p.nombre = (String)row["nombre"];
            p.descripcion = (String)row["descripcion"];

            try
            {
                // El campo productImage primero se almacena en un buffer
                byte[] imageBuffer = (byte[])row["imagen"];
                // Se crea un MemoryStream a partir de ese buffer
                System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBuffer);
                // Se utiliza el MemoryStream para extraer la imagen
                p.imagen = Image.FromStream(ms);
            }
            catch(Exception)
            {
                p.imagen = null;
            }
           

            p.Cate.id = (Int32)row["categoria_id_categoria"];
            p.Cate.nombre = (String)row["categoria_nombre"];
            p.Cate.descripcion = (String)row["categoria_descripcion"];
            p.Unid.id = (Int32)row["unidad_id_unidad"];
            p.Unid.nombre = (String)row["unidad_nombre"];
            p.Unid.descripcion = (String)row["unidad_descripcion"];
            
            return p;
            
        }

        

        public void CargarProducto(ComboBox datos)
        {
            string consulta = "listar_producto";

            SqlCommand comando = new SqlCommand(consulta, conexion.ObtenerConexion());
            
            comando.Connection = conexion.ObtenerConexion();
            comando.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(dt);
            datos.DisplayMember = "nombre";
            datos.ValueMember = "id_producto";
            datos.DataSource = dt;
        }

        public static bool Agregar(producto producto)
        {
            SqlCommand sql = new SqlCommand("insertar_productos", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.Add("@codigo", SqlDbType.VarChar, 0).Value = producto.codigo;
            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = producto.nombre;
            sql.Parameters.Add("@descripcion", SqlDbType.VarChar, 0).Value = producto.descripcion;

            // Stream usado como buffer
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            // Se guarda la imagen en el buffer
            producto.imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            // Se extraen los bytes del buffer para asignarlos como valor para el 
            // parámetro.
            sql.Parameters.Add("@imagen", SqlDbType.Image, 0).Value = ms.GetBuffer(); 
            sql.Parameters.Add("@id_categoria", SqlDbType.Int, 0).Value = producto.Cate.id;
            sql.Parameters.Add("@id_unidad", SqlDbType.Int, 0).Value = producto.Unid.id;

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
        public static int Actualizar(producto producto)
        {
            SqlCommand sql = new SqlCommand("editar_productos", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;

            sql.Parameters.AddWithValue("@id_producto", producto.id_producto);
            sql.Parameters.Add("@codigo", SqlDbType.VarChar, 0).Value = producto.codigo;
            sql.Parameters.Add("@nombre", SqlDbType.VarChar, 0).Value = producto.nombre;
            sql.Parameters.Add("@descripcion", SqlDbType.VarChar, 0).Value = producto.descripcion;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            // Se guarda la imagen en el buffer
            producto.imagen.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            // Se extraen los bytes del buffer para asignarlos como valor para el 
            // parámetro.
            sql.Parameters.Add("@imagen", SqlDbType.Image, 0).Value = ms.GetBuffer();
            
            sql.Parameters.Add("@id_categoria", SqlDbType.Int, 0).Value = producto.Cate.id;
            sql.Parameters.Add("@id_unidad", SqlDbType.Int, 0).Value = producto.Unid.id;
            int resul = sql.ExecuteNonQuery();
            return Convert.ToInt32(resul > 0);
        }
        public static int Eliminar(producto producto)
        {
            SqlCommand sql = new SqlCommand("eliminar_productos", conexion.ObtenerConexion());
            sql.CommandType = CommandType.StoredProcedure;
            sql.Parameters.AddWithValue("@id_producto", producto.id_producto);
            try
            {
                int resul = sql.ExecuteNonQuery();
                return Convert.ToInt32(resul > 0);
            }
            catch(Exception)
            {
                MessageBox.Show("El producto esta siendo usados en otros registros.");
                return 0;
            }
           
        }
        public List<producto> buscar_producto(List<producto> proveedor, String palabra)
        {
            List<producto> productos_buscados = new List<producto>();
            foreach (producto p in proveedor)
            {
                //AQUI BUSCO SI TIENE EN SU CONTENIDO LA PALABRA (palabra) que ando buscando en cada uno de los campos
                if (p.codigo.Contains(palabra) || p.nombre.Contains(palabra) || p.descripcion.Contains(palabra) || p.Unid.nombre.Contains(palabra)||p.Cate.nombre.Contains(palabra))
                {
                    //si encuentra alguno con la palabra que se busca lo añade para ser listado
                    productos_buscados.Add(p);
                }
            }
            return productos_buscados;
        }
        public void BuscarDatos_productos(DataGridView datos, List<producto> prov, String palabra)
        {
            List<producto> nuevos_prov = new List<producto>();
            nuevos_prov = buscar_producto(prov, palabra);
            DataTable dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Unidad");
            dt.Columns.Add("Categoria");
            datos.DataSource = dt;
            foreach (producto p in nuevos_prov)
            {
                DataRow row = dt.NewRow();
                row["Codigo"] = p.codigo;
                row["Nombre"] = p.nombre;
                row["Descripcion"] = p.descripcion;
                row["Unidad"] = p.Unid.nombre;
                row["Categoria"] = p.Cate.nombre;
                
                dt.Rows.Add(row);
            }
        }
       
    }
}
