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
using DonChucho.ModeloDB;

namespace DonChucho
{
    public partial class Form1 : Form
    {
        private Producto ProductoEditar;
        public Form1( Producto producto )
        {
            InitializeComponent();
            ProductoEditar = producto;



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
                


                TuFormulario formularioPrincipal = new TuFormulario();
                formularioPrincipal.ShowDialog();
                this.Close();

           

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


            // esto es para optener los datos  en las  cajas de texto  del formulario que envia datso 
            TiendaDonChucho tienda = new TiendaDonChucho();
       
            DataTable tipos = tienda.ObtenerTiposProductoDesdeProducto();


            if (tipos != null && tipos.Rows.Count > 0)
            {
                comboBoxTipoProducto.DataSource = tipos;
                comboBoxTipoProducto.DisplayMember = "Descripcion";
                comboBoxTipoProducto.ValueMember = "Id";
                
                TxtId.Text = ProductoEditar.IdProducto.ToString();
                TxtNombre.Text = ProductoEditar.NombreProducto;
                comboBoxTipoProducto.SelectedValue = ProductoEditar.IdTipoProducto;

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

        private void comboBoxTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
