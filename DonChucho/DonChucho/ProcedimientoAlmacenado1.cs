
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DonChucho.Modelo;

namespace DonChucho
{
    public partial class ProcedimientoAlmacenado1 : Form
    {
        TiendaDonChucho tienda = new TiendaDonChucho();
        public ProcedimientoAlmacenado1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {

            // Obtener los productos como DataTable

            DataTable productos = tienda.ObtenerProductosPro();

            if (productos != null && productos.Rows.Count > 0)
            {
                // Asignar el DataTable al DataGridView
                dataGridViewPro.DataSource = productos;

            }
            else
            {
                MessageBox.Show("No se encontraron productos o hubo un error al obtenerlos.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridViewPro.CurrentRow != null)
            {
                try
                {
                    int id = Convert.ToInt32(dataGridViewPro.CurrentRow.Cells["Id"].Value);
                    string descripcion = dataGridViewPro.CurrentRow.Cells["Descripcion"].Value.ToString();

                    TipoProducto tipoSeleccionado = new TipoProducto(id, descripcion);

                    ProcedimientoAlmacenado2 form2 = new ProcedimientoAlmacenado2(tipoSeleccionado);
                    form2.ShowDialog();
                    form2.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona una fila completa para editar.");
            }


        }

        private void button1_Click(object sender, EventArgs e)

        {
            if (dataGridViewPro.SelectedRows.Count > 0)
            {
                try
                {
                    int idProductoEliminar = Convert.ToInt32(dataGridViewPro.SelectedRows[0].Cells["Id"].Value);

                    DialogResult confirmacion = MessageBox.Show($"¿Estás seguro de que deseas eliminar el producto con ID {idProductoEliminar}?",
                                                                 "Confirmar Eliminación",
                                                                 MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        bool eliminado = tienda.EliminarElemento(idProductoEliminar);

                        if (eliminado)
                        {
                            MessageBox.Show("Producto eliminado correctamente.");
                            CargarProductos();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el producto.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para eliminar.");
            }

        }
        private void CargarProductos()
        {
            TiendaDonChucho tienda = new TiendaDonChucho();

            DataTable productos = tienda.ObtenerProductos();

            if (productos != null && productos.Rows.Count > 0)
            {
                dataGridViewPro.DataSource = productos;


            }
            else
            {
                MessageBox.Show("No se encontraron productos o hubo un error al obtenerlos.");
            }


        }

        private void ProcedimientoAlmacenado1_Load(object sender, EventArgs e)
        {
            dataGridViewPro.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPro.MultiSelect = false;



        }

        private void label1_Click(object sender, EventArgs e)
        {
            ProcedimientoAlmacenado1 form = new ProcedimientoAlmacenado1();
            form.Close();

            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewPro.SelectedRows.Count > 0)
            {
                try
                {
                    // Extraer los valores seleccionados
                    int IdProducto = Convert.ToInt32(dataGridViewPro.SelectedRows[0].Cells["Id"].Value);
                    string NombreProducto = dataGridViewPro.SelectedRows[0].Cells["Descripcion"].Value.ToString();
                                   // Abrir Form1 y pasar los valores
                    TipoProducto productoSeleccionado = new TipoProducto(IdProducto, NombreProducto);
          ProcedimientoAlmacenado2 formEdicion = new  ProcedimientoAlmacenado2(productoSeleccionado);
         
                    formEdicion.ShowDialog();
                    formEdicion.Dispose();


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
        //
        private void dataGridViewPro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TiendaDonChucho tienda = new TiendaDonChucho();
            DataTable productos = tienda.ObtenerProductos();
            if (productos != null)
            {
                dataGridViewPro.DataSource = productos;
            }
            else
            {
                MessageBox.Show("No se pudieron obtener los productos de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}