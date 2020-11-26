using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTituloINg.Clases
{
    public class UsuarioCLS
    {

        public int idUsuario { get; set; }
        public string nombreUsuario { get; set; }

        public string nombresUsuario { get; set; }

        public string pass { get; set; }
        public string rutUsuario { get; set; }
        public string apellidosUsuario { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string imagen { get; set; }
        public DateTime? fechaNacimiento { get; set; }
        public int  idtipoUsuario { get; set; }
        public int? habilitado { get; set; }

        public string nombreTipoUsuario { get; set; }
    }
}
