using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoTituloINg.Clases;
using ProyectoTituloINg.Models;

namespace ProyectoTituloINg.Controllers
{
    public class TipoClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/TipoCliente/listarTipoClientes")]
        public List<TipoClienteCLS> listarTipoClientes()
        {

            List<TipoClienteCLS> listarTipoCliente= new List<TipoClienteCLS>();

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                listarTipoCliente = (from tipoCliente in db.TipoClientes
                                     
                                     select new TipoClienteCLS
                                     {
                                         idTipoCliente = tipoCliente.IdTipoCliente,
                                         nombreTipoCliente = tipoCliente.NombreTipoCliente


                                     }).ToList();

                return listarTipoCliente;
            }

        }

    }
}
