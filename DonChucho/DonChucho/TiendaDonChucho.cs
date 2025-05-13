
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Bibliotecas
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections;
using DonChucho.Modelo;

// Nombre proyecto
namespace DonChucho
{
    // Nombre de la clase del proyecto
    public class TiendaDonChucho                       
    {
        // Link de la base de datos proyecto QSL SERVER
        private string conexionBaseDatos = "Server= DESKTOP-9GDVFAJ\\SQLEXPRESS;Database=TiendaChucho;Trusted_Connection=True;";

        // funcion de conexion
        public bool Conectar()
        {
            try
            {
               SqlConnection conexion = new SqlConnection(conexionBaseDatos);
            
                    conexion.Open();

                    conexion.Close();
                      return true;
                }
                 catch (Exception)
            {
            }
            return false;

       
        }
        // funcion para traer los datos de la base de datos
        public DataTable ObtenerProductos()
        {
            try
            {
               SqlConnection connection = new SqlConnection(conexionBaseDatos) ; //instancia
                //SqlDataAdapter canal = new SqlDataAdapter("SELECT idTipoProducto, Nombre ,Id FROM PRODUCTO", connection);

                SqlDataAdapter canal = new SqlDataAdapter("Select * from Producto inner join  TipoProducto on  Producto.IdTipoProducto = TipoProducto.Id", connection);
                    DataTable productos = new DataTable();
                    canal.Fill(productos);

            
                    return productos;
                
            }
            catch (Exception )
            {
           
                return null;
            
        }
            
        }
        public DataTable ObtenerTiposProductoDesdeProducto()
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionBaseDatos))
                {
                    string query = "SELECT  id, descripcion from  TipoProducto";

                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    return tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tipos de producto: " + ex.Message);
                return null;
            }
        }

        public DataTable ObtenerInventario()
        {
            try
            {
     
                SqlConnection connection = new SqlConnection(conexionBaseDatos); //instancia

                SqlDataAdapter canal = new SqlDataAdapter("select * from inventario inner join Producto on  Producto.IdTipoProducto=IdProducto ", connection);
         
                DataTable productoInventario = new DataTable();
                canal.Fill(productoInventario);


                return productoInventario;

            }
            catch (Exception)
            {

                return null;

            }

        }


        // funcion para insertar  datos a  la base de datos
        public bool InsertarElemento(int Id, string Nombre , int idTipoProducto)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionBaseDatos))
                {
                    string query = "INSERT INTO PRODUCTO (Id, Nombre, IdTipoProducto) VALUES (@Id, @Nombre ,@IdTipoProducto)";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Id", Id);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@IdTipoProducto", idTipoProducto);

                    conexion.Open();
                    int resultado = comando.ExecuteNonQuery();
                    conexion.Close();

                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
                return false;
            }
        }
 
        // funcion para eliminar los datos de la base de datos
        public bool EliminarElemento(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionBaseDatos))
                {
                    string query = "DELETE FROM PRODUCTO WHERE Id = @Id";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@Id", id);

                    conexion.Open();
                    int resultado = comando.ExecuteNonQuery();
                    conexion.Close();

                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
                return false;
            }
        }

        public int EditarProducto(int id, string Nombre, int idTipoProducto)
        {
            int resultado = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(conexionBaseDatos))
                {
                    connection.Open();
                    string query = "UPDATE PRODUCTO SET Nombre = @Nombre, IdTipoProducto = @IdTipoProducto WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@IdTipoProducto", idTipoProducto);
                    command.Parameters.AddWithValue("@Id", id);

                   
                    resultado = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar: " + ex.Message);
            }

            return resultado;
        }
        ///       Esto es para Proccesos Almacenados         /////
    

        public DataTable ObtenerProductosPro()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexionBaseDatos))
                {
                    SqlCommand comando = new SqlCommand("sp_ObtenerTipoProductos", connection);
                    comando.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                    DataTable productos = new DataTable();
                    adaptador.Fill(productos);

                    return productos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tipos de producto: " + ex.Message);
                return null;
            }
        }

        public bool InsertarTipoProductoPro(int id, string descripcion)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionBaseDatos))
                {
                    SqlCommand comando = new SqlCommand("sp_InsertarTipoProducto", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.Parameters.AddWithValue("@Descripcion", descripcion);

                    conexion.Open();
                    int resultado = comando.ExecuteNonQuery();
                    conexion.Close();

                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar tipo de producto: " + ex.Message);
                return false;
            }
        }
       


        public bool ActualizarTipoProductoPro(int id, string descripcion)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionBaseDatos))
                {
                    SqlCommand comando = new SqlCommand("sp_ActualizarTipoProducto", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", id);
                    comando.Parameters.AddWithValue("@Descripcion", descripcion);

                    conexion.Open();
                    int resultado = comando.ExecuteNonQuery();
                    conexion.Close();

                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar tipo de producto: " + ex.Message);
                return false;
            }
        }


        public bool EliminarTipoProductoPro(int id)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection(conexionBaseDatos))
                {
                    SqlCommand comando = new SqlCommand("sp_EliminarTipoProducto", conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id", id);

                    conexion.Open();
                    int resultado = comando.ExecuteNonQuery();
                    conexion.Close();

                    return resultado > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar tipo de producto: " + ex.Message);
                return false;
            }
        }


    }
}
    
