using System;
using System.Collections.Generic;

namespace ProyectoTituloINg.Models
{
    public partial class Documentos
    {
        public long IdDocumento { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdCliente { get; set; }
        public int IdEstadoVenta { get; set; }
        public int IdProducto { get; set; }
        public int IdUsuario { get; set; }
        public long? IdTipoDoc { get; set; }

        public virtual TipoDocumentos IdTipoDocNavigation { get; set; }
    }
}
