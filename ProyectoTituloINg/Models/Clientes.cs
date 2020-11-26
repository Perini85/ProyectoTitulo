using System;
using System.Collections.Generic;

namespace ProyectoTituloINg.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Documento = new HashSet<Documento>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidosCliente { get; set; }
        public string RutCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string Numero { get; set; }
        public string Correo { get; set; }
        public int? IdTipoCliente { get; set; }
        public int? Habilitado { get; set; }
        public int? IdComuna { get; set; }

        public virtual Comuna IdComunaNavigation { get; set; }
        public virtual TipoClientes IdTipoClienteNavigation { get; set; }
        public virtual ICollection<Documento> Documento { get; set; }
    }
}
