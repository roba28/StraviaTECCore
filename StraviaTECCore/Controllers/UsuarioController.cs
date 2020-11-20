using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;

namespace StraviaTECCore.Controllers

    // creacion de la ruta con la que el  webservice se expondra para ser consumido 
    //Dependiendo del metodo de consumo se dirigira a cada una de las funciones.
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {


        // Metodo utilizado para obtener toodos los usuarios de la base de datos 
        [HttpGet]
        public IActionResult getuser() {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                  

                    var list = db.Usuarios.OrderByDescending(d => d.UsuarioId).ToList();
                    return Ok(list);
                }
                catch (Exception e) {
                    return NotFound(e);
                }
            }
        }

        //---------------------------------------------------------------------------------
        // Metodo utilizado para obtener un usuario en particular 

        [HttpGet("find/{id}")]
        public IActionResult getoneuser(int id)
        {
            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Usuarios.Find(id);
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }


            }

        }





        //-----------------------------------------------------------------------------
        //Metodo utilizado para eliminar un usuario en particular

        [HttpDelete("del/{id}")]
        public ActionResult deleteuser(int id)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {

                try
                {

                    if (db.Usuarios.Find(id) == null)
                    {

                        return NotFound();


                    }

                    else
                    {
                        var list = db.Usuarios.Find(id);
                        db.Usuarios.Remove(list);
                        db.SaveChanges();

                        return Ok();
                    }
                }
                catch (Exception e) {
                    return NotFound(e);
                }

            }

        }


   



        //---------------------------------------------------------------------
        //Metodo utilizado para crear un nuevo usuario 

        [HttpPost]

        public IActionResult adduser(Usuarios user) {

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    Usuarios usuario = new Usuarios();
                    usuario.UsuarioId = user.UsuarioId;
                    usuario.Nombre = user.Nombre;
                    usuario.Apellido1 = user.Apellido1;
                    usuario.Apellido2 = user.Apellido2;
                    usuario.Nacionalidad = user.Nacionalidad;
                    usuario.FechaNacimiento = user.FechaNacimiento;
                    usuario.CuentaBancaria = user.CuentaBancaria;
                    usuario.Edad = user.Edad;
                    usuario.Usuario = user.Usuario;
                    usuario.Contrasena = user.Contrasena;
                    usuario.Rol = user.Rol;

                    db.Usuarios.Add(usuario);
                    db.SaveChanges();

                    return Ok();
                }
                catch {
                    return NotFound();
                }


            }

        }




        //---------------------------------------------------------------------
        //Metodo utilizado para actualizar un  usuario 
        [HttpPut]
        public IActionResult Edituser(Usuarios user)
        {
            int id = user.UsuarioId;

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {
                    if (db.Usuarios.Find(id) == null)
                    {
                        return NotFound();

                    }
                    else
                    {
                        Usuarios us = db.Usuarios.Find(id);
                        us.UsuarioId = user.UsuarioId;
                        us.Nombre = user.Nombre;
                        us.Apellido1 = user.Apellido1;
                        us.Apellido2 = user.Apellido2;
                        us.Nacionalidad = user.Nacionalidad;
                        us.FechaNacimiento = user.FechaNacimiento;
                        us.CuentaBancaria = user.CuentaBancaria;
                        us.Edad = user.Edad;
                        us.Usuario = user.Usuario;
                        us.Contrasena = user.Contrasena;
                        us.Rol = user.Rol;
                        db.Usuarios.Update(us);
                        db.SaveChanges();

                        return Ok();
                    }
                }
                catch (Exception e) {
                    return NotFound(e);
                }


                    }


            }


        }

    }

