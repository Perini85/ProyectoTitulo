using System;
using System.Collections.Generic;

namespace ProyectoTituloINg.Models
{
    public partial class TipoClientes
    {
        public TipoClientes()
        {
            Clientes = new HashSet<Clientes>();
        }

        public int IdTipoCliente { get; set; }
        public string NombreTipoCliente { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
