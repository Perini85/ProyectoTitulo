using System;
using System.Collections.Generic;

namespace ProyectoTituloINg.Models
{
    public partial class TipoDocumentos
    {
        public TipoDocumentos()
        {
            Documento = new HashSet<Documento>();
        }

        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Documento> Documento { get; set; }
    }
}
