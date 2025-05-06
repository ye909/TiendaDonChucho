using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DonChucho
{
    public partial class Form1 : Form
    {
        private TuFormulario formularioPrincipal;

        public Form1(TuFormulario formulario, int id, string nombre, int tipoProducto)
        {
            InitializeComponent();
            formularioPrincipal = formulario;

            TxtId.Text = id.ToString();
            TxtNombre.Text = nombre;
            comboBoxTipoProducto.SelectedValue = tipoProducto;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            TiendaDonChucho tienda = new TiendaDonChucho();

            int id, idTipoProducto;

            if (!int.TryParse(TxtId.Text, out id))
            {
                MessageBox.Show("Ingrese un número válido para el ID.");
                return;
            }

            if (comboBoxTipoProducto.SelectedItem == null ||
                !int.TryParse(comboBoxTipoProducto.SelectedValue?.ToString(), out idTipoProducto))
            {
                MessageBox.Show("Seleccione un IdTipoProducto válido.");
                return;
            }

            string nombre = TxtNombre.Text.Trim();
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Ingrese un nombre válido.");
                return;
            }

            int filasAfectadas = tienda.EditarProducto(id, nombre, idTipoProducto);

            if (filasAfectadas > 0)
            {
                MessageBox.Show("Producto actualizado correctamente.");
                this.Hide();


                //formularioPrincipal.CargarProductos(); // Actualiza DataGridView
                //formularioPrincipal.Show();
             
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el producto.");
            }

            TxtId.Clear();
            TxtNombre.Clear();
            comboBoxTipoProducto.SelectedIndex = -1;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            TiendaDonChucho tienda = new TiendaDonChucho();
       
            DataTable tipos = tienda.ObtenerProductos();
            if (tipos != null && tipos.Rows.Count > 0)
            {
                comboBoxTipoProducto.DataSource = tipos;
                comboBoxTipoProducto.DisplayMember = "Nombre";
                comboBoxTipoProducto.ValueMember = "IdTipoProducto";


                //TxtId.Text = Convert.ToString(dataGridViewProductos.CurrentRow.Cells["Id"].Value);
                //TxtNombre.Text = Convert.ToString(dataGridViewProductos.CurrentRow.Cells["Nombre"].Value)
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los tipos de producto.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

           
        

   
    }
}
