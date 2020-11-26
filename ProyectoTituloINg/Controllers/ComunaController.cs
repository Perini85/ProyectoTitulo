using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProyectoTituloINg.Clases;
using ProyectoTituloINg.Models;

namespace ProyectoTituloINg.Controllers
{
    public class ComunaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Comuna/listarComunas")]
        public List<ComunaCLS> listarComunas()
        {

            List<ComunaCLS> listarComuna = new List<ComunaCLS>();

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                listarComuna = (from comuna in db.Comuna

                                     select new ComunaCLS
                                     {
                                        idComuna = comuna.IdComuna,
                                        descripcion = comuna.Descripcion

                                     }).ToList();

                return listarComuna;
            }

        }
    }
}
