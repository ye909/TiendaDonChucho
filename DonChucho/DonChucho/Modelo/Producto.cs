using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonChucho.ModeloDB
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdTipoProducto { get; set; }
        public static int Id { get; internal set; }

        public Producto(int IdProducto, string NombreProducto, int IdTipoProducto)
        {
            this.IdProducto =IdProducto;
            this.NombreProducto = NombreProducto;
            this.IdTipoProducto = IdTipoProducto;

        }

        public Producto()
        {
        }
    }
}
