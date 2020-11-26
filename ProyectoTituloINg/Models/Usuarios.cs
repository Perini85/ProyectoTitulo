using System;
using System.Collections.Generic;

namespace ProyectoTituloINg.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Documento = new HashSet<Documento>();
        }

        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string RutUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Imagen { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? Habilitado { get; set; }
        public string Pass { get; set; }
        public string NombresUsuario { get; set; }

        public virtual TiposUsuarios IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Documento> Documento { get; set; }
    }
}
