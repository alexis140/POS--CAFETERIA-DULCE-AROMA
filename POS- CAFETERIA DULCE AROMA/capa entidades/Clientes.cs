using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS__CAFETERIA_DULCE_AROMA.capa_entidades
{
    internal class Clientes
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public bool Estado { get; set; }

        public Clientes() { }

        public Clientes(int Codigo, string nombre, string Telefono, string Direccion, string email, bool estado)
        {
            this.Codigo = Codigo;
            this.Nombre = nombre;
            this.Telefono = Telefono;
            this.Direccion = Direccion;
            this.Correo = email;
            this.Estado = estado;
        }
    }
}
