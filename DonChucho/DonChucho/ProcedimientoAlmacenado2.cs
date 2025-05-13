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
    public partial class ProcedimientoAlmacenado2 : Form
    {
        private TipoProducto formularioPro;
        public ProcedimientoAlmacenado2(TipoProducto tipoProducto)
        {
            InitializeComponent();
            formularioPro = tipoProducto;


        }



        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(TxtId.Text);
                string descripcion = TxtDescripcion.Text.Trim();

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    MessageBox.Show("La descripción no puede estar vacía.");
                    return;
                }

                TiendaDonChucho tienda = new TiendaDonChucho();
                bool resultado;

                if (id == 0) // Insertar
                {
                    resultado = tienda.InsertarTipoProductoPro(id, descripcion);

                    if (resultado)
                    {
                        MessageBox.Show("Tipo de producto insertado correctamente.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo insertar el tipo de producto.");
                    }
                }
                else // Actualizar
                {
                    resultado = tienda.ActualizarTipoProductoPro(id, descripcion);

                    if (resultado)
                    {
                        MessageBox.Show("Tipo de producto actualizado correctamente.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el tipo de producto.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ProcedimientoAlmacenado2_Load(object sender, EventArgs e)
        {

            // aqui se cargra solo dos cajas 
            TiendaDonChucho tienda = new TiendaDonChucho();

            DataTable tipos = tienda.ObtenerTiposProductoDesdeProducto();


            if (tipos != null && tipos.Rows.Count > 0)
            {


                TxtId.Text = formularioPro.id.ToString();
                TxtDescripcion.Text = formularioPro.Descripcion.ToString();


            }
            else
            {
                MessageBox.Show("No se pudieron cargar los tipos de producto.");
            }
            if (formularioPro.id > 0)
            {
                TxtId.Text = formularioPro.id.ToString();
                TxtDescripcion.Text = formularioPro.Descripcion;
            }
            else
            {
                TxtId.Text = "0"; // nuevo
                TxtDescripcion.Text = "";
            }
        }

        private void TxtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
