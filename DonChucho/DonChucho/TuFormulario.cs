using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace DonChucho
{
    public partial class TuFormulario : Form
    {
        TiendaDonChucho tienda = new TiendaDonChucho();

        public TuFormulario()
        {
            InitializeComponent();








        }
    

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void bntCargarDatos_Click(object sender, EventArgs e)
        {
            bntCargarDatos.BackColor = Color.White;
         
            // Crear instancia de la clase TiendaDonChucho
            TiendaDonChucho tienda = new TiendaDonChucho();

            // Obtener los productos como DataTable
            DataTable productos = tienda.ObtenerProductos();

            if (productos != null && productos.Rows.Count > 0)
            {
                // Asignar el DataTable al DataGridView
                dataGridViewProductos.DataSource = productos;
               
            }
            else
            {
                MessageBox.Show("No se encontraron productos o hubo un error al obtenerlos.");
            }
           
        }
        
        private void btnConexion_Click_1(object sender, EventArgs e)
        {
            // validar la conenexion 
            btnConexion.BackColor = Color.White;

            this.Controls.Remove(btnConexion);


            TiendaDonChucho mensaje = new TiendaDonChucho();
            if (mensaje.Conectar())

                MessageBox.Show("conexion Exitosa");
            else
                MessageBox.Show("No hay Conexion");

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
          
      

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // valida los datos de la base de datos y los vuelve a mostrar
            CargarProductos();

         
            


        }
        private void CargarProductos()
        {
            TiendaDonChucho tienda = new TiendaDonChucho();

            DataTable productos = tienda.ObtenerProductos();

            if (productos != null && productos.Rows.Count > 0)
            {
                dataGridViewProductos.DataSource = productos;
             
              
            }
            else
            {
                MessageBox.Show("No se encontraron productos o hubo un error al obtenerlos.");
            }
                 btnActualizar.BackColor = Color.White;
           
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProductos.MultiSelect = false;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
         


        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la fila seleccionada.
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
               
             
                try
                {
                    // Obtener el ID de la fila seleccionada.
                    int idProductoEliminar = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["Id"].Value);

                    // Pedir confirmación al usuario (recomendado)
                    DialogResult confirmacion = MessageBox.Show($"¿Estás seguro de que deseas eliminar el producto con ID {idProductoEliminar}?",
                                                             "Confirmar Eliminación",
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        // Llamar al método de tu clase para eliminar
                        bool eliminado = tienda.EliminarElemento(idProductoEliminar);

                        if (eliminado)
                        {
                            MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Actualizar el DataGridView para reflejar el cambio
                            CargarProductos();
                        }
                        else
                        {
                            // El método EliminarElemento ya muestra un MessageBox en caso de error,
                         
                            MessageBox.Show("No se pudo eliminar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener el ID del producto seleccionado o al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila completa para eliminar.", "Selección Requerida", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        


            ///


        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
     
 
           
         //System.Windows.Forms.DataGridViewBorders.None;
            TiendaDonChucho tienda = new TiendaDonChucho();
            DataTable productos = tienda.ObtenerProductos();

            if (productos != null)
            {
                
                dataGridViewProductos.DataSource = productos;
            }
            else
            {
                MessageBox.Show("No se pudieron obtener los productos de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

   


    }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // crear varibles,ponerles el tryparse para  convertir de string a int 
            //int id, tipoProducto;



            //if (int.TryParse(TxtId.Text, out id) && int.TryParse(comboBoxTipoProducto.Text, out tipoProducto))
            //{
            //    string nombre = TxtNombre.Text;
            //     // inserto los datos del clase insercion 
            //    bool insertado = tienda.InsertarElemento(id, nombre, tipoProducto);
            //    //bool insertad = tienda.InsertarElemento(comboBox1.tipoProducto);

            //    if (insertado && TxtNombre.Text != "" && comboBoxTipoProducto.Text != "" && TxtId.Text != "")
            //    {


            //        btnAgregar.BackColor = Color.White;
            //        TxtId.Clear();
            //        TxtNombre.Clear();

            //        MessageBox.Show("Elemento insertado correctamente.");
            //        CargarElementos();
            //    }
            //    else
            //    {
            //        MessageBox.Show("No se pudo insertar el elemento.");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Ingrese valores numéricos válidos para Id y TipoProducto.");


            //    if (int.TryParse(comboBoxTipoProducto.SelectedItem?.ToString(), out int IdtipoProducto))
            //    {
            //        // ahora tienes el idTipoProducto en tipoProducto
            //               MessageBox.Show("Sválido.");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Selecciona un tipo de producto válido.");
            //    }


            
        }
            //if (int.TryParse(comboBoxTipoProducto.SelectedItem?.ToString(), out int IdtipoProducto))
            //{
            //    MessageBox.Show("válido.");
            //}
            //else
            //{
            //    MessageBox.Show("Selecciona un tipo de producto válido.");
            //}

        //}

        private void CargarElementos()
        {
            DataTable datos = tienda.ObtenerProductos();
            if (datos != null)
            {
                dataGridViewProductos.DataSource = datos;
               

            }
            else
            {
                MessageBox.Show("No se pudieron cargar los elementos.");
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {
       

        }

        private void Inventario_Click(object sender, EventArgs e)
        {


            bntCargarDatos.BackColor = Color.White;
            // Crear instancia de la clase TiendaDonChucho
            TiendaDonChucho tienda = new TiendaDonChucho();

            // Obtener los productos como DataTable
            DataTable sucursales = tienda.ObtenerInventario();

            if (sucursales != null && sucursales.Rows.Count > 0)
            {
                // Asignar el DataTable al DataGridView
                dataGridViewProductos.DataSource =sucursales;
            }
            else
            {
                MessageBox.Show("No se encontraron productos o hubo un error al obtenerlos.");

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void TxtIdTipoProducto_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void X_Click(object sender, EventArgs e)
        {
            TuFormulario form = new TuFormulario();
            form.Close();
            this.Close();

        }

        private void dataGridViewProductos_SelectionChanged(object sender, EventArgs e)
        {




        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewProductos.SelectedRows.Count > 0)
            {
                try
                {
                    // Extraer los valores seleccionados
                    int id = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["Id"].Value);
                    string nombre = dataGridViewProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    int tipoProducto = Convert.ToInt32(dataGridViewProductos.SelectedRows[0].Cells["IdTipoProducto"].Value); // Asegúrate de que esta columna exista

                    // Abrir Form1 y pasar los valores
                    Form1 formIngreso = new Form1(this, id, nombre, tipoProducto);
                    formIngreso.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener datos de la fila seleccionada: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona una fila completa para editar.");
            }
        }

        private void dataGridViewProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

         


        }
        public void AgregarProductoDesdeFormulario(int id, string nombre, int tipoProducto)
        {
        //TEditar el producto en la base de datos
    TiendaDonChucho tienda = new TiendaDonChucho();
    int filasAfectadas = tienda.EditarProducto(id, nombre, tipoProducto);

    if (filasAfectadas > 0)
    {
        MessageBox.Show("Producto actualizado desde el formulario.");
        CargarProductos(); // Vuelve a cargar los datos en el DataGridView
    }
    else
    {
        MessageBox.Show("No se pudo actualizar el producto desde el formulario.");
    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TxtId.Clear();
            //TxtNombre.Clear();
        }
    }
}






















