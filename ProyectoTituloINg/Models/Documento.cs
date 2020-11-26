using System;
using System.Collections.Generic;

namespace ProyectoTituloINg.Models
{
    public partial class Documento
    {
        public int IdDocumento { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdCliente { get; set; }
        public int? IdProducto { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTipoDocumento { get; set; }
        public int? Habilitado { get; set; }

        public virtual Clientes IdClienteNavigation { get; set; }
        public virtual TipoDocumentos IdTipoDocumentoNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}
