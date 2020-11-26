using Microsoft.AspNetCore.Mvc;
using ProyectoTituloINg.Clases;
using ProyectoTituloINg.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoTituloINg.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/cliente/listarClientes")]
        public IEnumerable<ClienteCLS> listarClientes()
        {

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                List<ClienteCLS> listaCliente = (from cliente in db.Clientes
                                                 where cliente.Habilitado == 1
                                                 select new ClienteCLS
                                                 {
                                                     idCliente = cliente.IdCliente,
                                                     rutCliente = cliente.RutCliente,
                                                     nombreCompleto = cliente.NombreCliente + " " + cliente.ApellidosCliente,
                                                     direccionCliente = cliente.DireccionCliente,
                                                     correo = cliente.Correo,
                                                     numero = cliente.Numero,
                                                     idcomuna = (int)cliente.IdComuna


                                                 }).ToList();

                return listaCliente;

            }
        }

        [HttpGet]
        [Route("api/cliente/filtrarClientes/{nombreCompleto?}")]
        public IEnumerable<ClienteCLS> filtrarClientes(string nombreCompleto = "")
        {

            List<ClienteCLS> listaCliente;
            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                if (nombreCompleto == "")
                {
                    listaCliente = (from cliente in db.Clientes
                                    where cliente.Habilitado == 1
                                    select new ClienteCLS
                                    {
                                        idCliente = cliente.IdCliente,
                                        rutCliente = cliente.RutCliente,
                                        nombreCompleto = cliente.NombreCliente + " " + cliente.ApellidosCliente,
                                        direccionCliente = cliente.DireccionCliente,
                                        correo = cliente.Correo,
                                        numero = cliente.Numero,
                                        idcomuna = (int)cliente.IdComuna,

                                    }).ToList();

                }
                else
                {
                    listaCliente = (from cliente in db.Clientes
                                    where cliente.Habilitado == 1
                                    && (cliente.NombreCliente + " " + cliente.ApellidosCliente).ToLower().Contains(nombreCompleto.ToLower())
                                    select new ClienteCLS
                                    {
                                        idCliente = cliente.IdCliente,
                                        nombreCompleto = cliente.NombreCliente + " " + cliente.ApellidosCliente,
                                        direccionCliente = cliente.DireccionCliente,
                                        correo = cliente.Correo,
                                        numero = cliente.Numero,
                                        idcomuna = (int)cliente.IdComuna

                                    }).ToList();

                }
                return listaCliente;

            }

        }




    [HttpPost]
     [Route("api/cliente/guardar")]
      public ActionResult  guardar ([FromBody]  Clientes cliente)
      {
            try
            {
                using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
                {
                    cliente.Habilitado = 1;
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return Ok();

                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        [HttpPost]
        [Route("api/cliente/guardarCliente")]
        public int guardarCliente([FromBody] ClienteCLS oClienteCLS)
        {


            int resp = 0;
            try
            {
                using(db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
                {

                    if (oClienteCLS.idCliente == 0)
                    {
                        Clientes oCliente = new Clientes();
                        

                           
                            oCliente.IdCliente = oClienteCLS.idCliente;
                            oCliente.RutCliente = oClienteCLS.rutCliente;
                            oCliente.NombreCliente = oClienteCLS.nombreCliente;
                            oCliente.ApellidosCliente = oClienteCLS.apellidosCliente;
                            oCliente.Correo = oClienteCLS.correo;
                            oCliente.DireccionCliente = oClienteCLS.direccionCliente;
                            oCliente.Numero = oClienteCLS.numero;
                        oCliente.IdTipoCliente = oClienteCLS.idtipoCliente;
                        oCliente.IdComuna = oClienteCLS.idcomuna;
                        oCliente.Habilitado = 1;
                            db.Clientes.Add(oCliente);
                            db.SaveChanges();
                            resp = 1;
                        
                        
                    } else
                    {
                        Clientes oCliente = db.Clientes.Where(c => c.IdCliente == oClienteCLS.idCliente).First();
                        oCliente.RutCliente = oClienteCLS.rutCliente;
                        oCliente.NombreCliente = oClienteCLS.nombreCliente;
                        oCliente.ApellidosCliente = oClienteCLS.apellidosCliente;
                        oCliente.Correo = oClienteCLS.correo;
                        oCliente.DireccionCliente = oClienteCLS.direccionCliente;
                        oCliente.Numero = oClienteCLS.numero;
                        //oCliente.IdTipoCliente = oClienteCLS.idtipoCliente;

                        oCliente.IdComuna = oClienteCLS.idcomuna;
                        db.SaveChanges();
                        resp = 1;
                    }


                }



            }catch(Exception)
            {
                resp = 0;
            }
            return resp;
        }


        [HttpGet]
        [Route("api/cliente/recuperarCliente/{idCliente}")]
        public ClienteCLS recuperarCliente(long idCliente)
        {

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                ClienteCLS oClienteCLS = (from cliente in db.Clientes
                                          where cliente.Habilitado == 1
                                          && cliente.IdCliente == idCliente
                                          select new ClienteCLS
                                          {
                                              idCliente = (int)cliente.IdCliente,
                                              rutCliente = cliente.RutCliente,
                                              nombreCliente = cliente.NombreCliente,
                                              apellidosCliente = cliente.ApellidosCliente,
                                              direccionCliente = cliente.DireccionCliente,
                                              correo = cliente.Correo,
                                              numero = cliente.Numero,
                                              idcomuna = (int)cliente.IdComuna

                                          }).First();

                return oClienteCLS;

            }
        }


        [HttpGet]
        [Route("api/cliente/eliminarCliente/{idCliente}")]
        public int eliminarCliente(long idCliente)
        {

            int resp = 0;
            try
            {

                using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
                {
                    Clientes oCliente = db.Clientes.Where(c => c.IdCliente == idCliente).First();
                    oCliente.Habilitado = 0;
                    db.SaveChanges();

                    resp = 1;
                }



            }
            catch (Exception)
            {


                resp = 0;

            }

            return resp;
        }

        [HttpGet]
        [Route("api/cliente/validarCorreo/{idCliente}/{correo}")]

        public int validarCorreo(long idCliente, string correo)
        {

            int resp = 0;
            try
            {

                using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
                {

                    if (idCliente == 0)
                    {
                        resp = db.Clientes.Where(c => c.Correo.ToLower() == correo.ToLower()).Count();


                    }
                    else
                    {

                        resp = db.Clientes.Where(c => c.Correo.ToLower() == correo.ToLower() && c.IdCliente != idCliente).Count();

                    }


                }


            }
            catch (Exception)
            {

                resp = 0;
            }

            return resp;

        }


        [HttpGet]
        [Route("api/cliente/listarComboCliente")]

        public IEnumerable<ClienteCLS> listarComboCliente()
        {




            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                IEnumerable<ClienteCLS> listarCliente = (from cliente in db.Clientes
                                                         where cliente.Habilitado == 1
                                                         select new ClienteCLS
                                                         {
                                                             idCliente = cliente.IdCliente,
                                                             nombreCompleto = cliente.NombreCliente + " " + cliente.ApellidosCliente


                                                         }).ToList();

                return listarCliente;

            }


        }




    }
}
