using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using ProyectoTituloINg.Clases;
using ProyectoTituloINg.Models;

namespace ProyectoTituloINg.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Usuario/listarTipoUsuario")]
        public IEnumerable<TipoUsuarioCLS> listarTipoUsuario()
        {

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                List<TipoUsuarioCLS> listaTipoUsuario = (from tiposUsuarios in db.TiposUsuarios
                                                         select new TipoUsuarioCLS
                                                         {
                                                             idtipoUsuariO = tiposUsuarios.IdTipoUsuario,
                                                             nombreTipoUsuario = tiposUsuarios.NombreTipoUsuario

                                                         }).ToList();

                return listaTipoUsuario;
            }

        }


        [HttpGet]
        [Route("api/Usuario/listarUsuario")]
        public IEnumerable<UsuarioCLS> listarUsuario()
        {

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                List<UsuarioCLS> listaUsuario = (from usuario in db.Usuarios
                                                 join tipousuario in db.TiposUsuarios
                                                 on usuario.IdTipoUsuario equals tipousuario.IdTipoUsuario
                                                 where usuario.Habilitado == 1
                                                 select new UsuarioCLS
                                                 {
                                                     idUsuario = usuario.IdUsuario,
                                                     nombreUsuario = usuario.NombreUsuario,
                                                     nombresUsuario = usuario.NombresUsuario,

                                                     rutUsuario = usuario.RutUsuario,
                                                     apellidosUsuario = usuario.ApellidosUsuario,
                                                     correo = usuario.Correo,
                                                     telefono = usuario.Telefono,
                                                     fechaNacimiento = usuario.FechaNacimiento,
                                                     imagen = usuario.Imagen
                                                 }

                                                    ).ToList();
                return listaUsuario;

            }
        }



        [HttpGet]
        [Route("api/Usuario/filtrarUsuarioPorTipo/{idTipo?}")]
        public IEnumerable<UsuarioCLS> filtrarUsuarioPorTipo(int idTipo = 0)
        {

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                List<UsuarioCLS> listaUsuario = (from usuario in db.Usuarios
                                                 join tipousuario in db.TiposUsuarios
                                                 on usuario.IdTipoUsuario equals tipousuario.IdTipoUsuario
                                                 where usuario.Habilitado == 1
                                                 && usuario.IdTipoUsuario == idTipo
                                                 select new UsuarioCLS
                                                 {
                                                     idUsuario = usuario.IdUsuario,
                                                     nombreUsuario = usuario.NombreUsuario,
                                                     nombresUsuario = usuario.NombresUsuario,
                                                     rutUsuario = usuario.RutUsuario,
                                                     apellidosUsuario = usuario.ApellidosUsuario,
                                                     correo = usuario.Correo,
                                                     telefono = usuario.Telefono,
                                                     fechaNacimiento = usuario.FechaNacimiento,
                                                     imagen = usuario.Imagen,

                                                     nombreTipoUsuario = tipousuario.NombreTipoUsuario

                                                 }).ToList();
                return listaUsuario;


            }
        }

        [HttpGet]
        [Route("api/Usuario/recuperarUsuario/{idUsuario}")]
        public UsuarioCLS recuperarUsuario(int idUsuario)
        {

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
            {

                UsuarioCLS oUsuarioCLS = new UsuarioCLS();

                var oUsuario = db.Usuarios.Where(u => u.IdUsuario == idUsuario).First();


                oUsuarioCLS.idUsuario = oUsuario.IdUsuario;
                oUsuarioCLS.rutUsuario = oUsuario.RutUsuario;
                oUsuarioCLS.nombreUsuario = oUsuario.NombreUsuario;
                oUsuarioCLS.nombresUsuario = oUsuario.NombresUsuario;
                oUsuarioCLS.apellidosUsuario = oUsuario.ApellidosUsuario;
                oUsuarioCLS.correo = oUsuario.Correo;
                oUsuarioCLS.telefono = oUsuario.Telefono;
                oUsuarioCLS.imagen = oUsuario.Imagen;
                
                //oUsuarioCLS.fechaNacimiento = oUsuario.FechaNacimiento;
                oUsuarioCLS.idtipoUsuario = (int)oUsuario.IdTipoUsuario;
                

                return oUsuarioCLS;

            }


        }

        [HttpGet]
        [Route("api/Usuario/validarUsuario/{idUsuario}/{nombre}")]

        public int validarUsuario(int idUsuario, string nombre)
        {

            int resp = 0;
            try
            {
                using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
                {
                    if(idUsuario == 0)
                    {

                        resp = db.Usuarios.Where(u => u.NombreUsuario.ToLower() == nombre.ToLower()).Count();

                    } else
                    {

                        resp = db.Usuarios.Where(u => u.NombreUsuario.ToLower() == nombre.ToLower() &&
                                                  u.IdUsuario != idUsuario).Count();

                    }


                }


            }
            catch(Exception )
            {

                resp = 0;
            }

            return resp;


        }


        [HttpPost]
        [Route("api/Usuario/guardarDatos")]

        public int guardarDatos([FromBody] UsuarioCLS usuarioCLS)
        {

            int resp = 0;

            try
            {

                using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
                {

                    using (var transaccion = new TransactionScope())
                    {
                        if (usuarioCLS.idUsuario == 0)
                        {
                            Usuarios usuario = new Usuarios();

                            usuario.NombreUsuario = usuarioCLS.nombreUsuario;

                            //SHA256Managed sha = new SHA256Managed();
                            //string clave = usuarioCLS.pass;
                            //byte[] dataNoCifrada = Encoding.Default.GetBytes(clave);
                            //byte[] dataCifrada = sha.ComputeHash(dataNoCifrada);
                            //string claveCifrada = BitConverter.ToString(dataCifrada).Replace("-", "");


                            usuario.Pass = usuarioCLS.pass;
                            usuario.RutUsuario = usuarioCLS.rutUsuario;
                            usuario.NombreUsuario = usuarioCLS.nombreUsuario;
                            usuario.NombresUsuario = usuarioCLS.nombresUsuario;
                            usuario.ApellidosUsuario = usuarioCLS.apellidosUsuario;
                            usuario.Correo = usuarioCLS.correo;
                            usuario.Telefono = usuarioCLS.telefono;
                            usuario.FechaNacimiento = usuarioCLS.fechaNacimiento;
                            usuario.Imagen = usuarioCLS.imagen;
                            usuario.IdTipoUsuario = usuarioCLS.idtipoUsuario;
                            usuario.Habilitado = 1;
                            db.Usuarios.Add(usuario);
                            db.SaveChanges();
                            transaccion.Complete();
                            resp = 1;


                        } else
                        {
                         Usuarios usuario = db.Usuarios.Where(u => u.IdUsuario == usuarioCLS.idUsuario).First();
                           
                            usuario.RutUsuario = usuarioCLS.rutUsuario;
                            usuario.NombreUsuario = usuarioCLS.nombreUsuario;
                            usuario.NombresUsuario = usuarioCLS.nombresUsuario;
                            usuario.ApellidosUsuario = usuarioCLS.apellidosUsuario;
                            usuario.Correo = usuarioCLS.correo;
                            usuario.Telefono = usuarioCLS.telefono;
                            usuario.FechaNacimiento = usuarioCLS.fechaNacimiento;
                            usuario.Imagen = usuarioCLS.imagen;
                            usuario.IdTipoUsuario = usuarioCLS.idtipoUsuario;
                            db.SaveChanges();
                            transaccion.Complete();
                            resp = 1;

                        }

                    }






                }

            }
            catch (Exception )
            {
                resp = 0;

            }

            return resp;
        }


        [HttpGet]
        [Route("api/Usuario/eliminarUsuario/{idUsuario}")]
        public int eliminarUsuario(int idUsuario)
        {

            int resp = 0;

            try
            {

            using (db_crm_hardwareshopContext db = new db_crm_hardwareshopContext())
                {

                    Usuarios usuario = db.Usuarios.Where(u => u.IdUsuario == idUsuario).First();
                    usuario.Habilitado = 0;
                    db.SaveChanges();
                    resp = 1;

                }
            }
            catch (Exception )
            {
                resp = 0;

            }

            return resp;
        }



       




    }
}
