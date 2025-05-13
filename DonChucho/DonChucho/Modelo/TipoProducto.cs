using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonChucho.Modelo
{
    public class TipoProducto
    {

        public int id { get; set; }
        public string Descripcion { get; set; }

        public TipoProducto(int id, string Descripcion)
        {
            this.id = id;
            this.Descripcion = Descripcion;
        }

    }
}
