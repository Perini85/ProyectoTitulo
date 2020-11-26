using System;
using System.Collections.Generic;

namespace ProyectoTituloINg.Models
{
    public partial class Comuna
    {
        public Comuna()
        {
            Clientes = new HashSet<Clientes>();
        }

        public int IdComuna { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
