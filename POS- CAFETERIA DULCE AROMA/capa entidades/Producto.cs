using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__CAFETERIA_DULCE_AROMA.capa_entidades
{
    //hacemos publica la clase
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

     public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool estado { get; set; }


    }
}
