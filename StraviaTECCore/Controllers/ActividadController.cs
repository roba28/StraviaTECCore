using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {



        //---------------------------------------------------------------------
        //Metodo utilizado para crear un nuevo usuario 

        [HttpPost]

        public IActionResult adduser(Actividad actividad)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    Usuarios usuario = new Usuarios();
                    usuario.UsuarioId = actividad.UsuarioId;
                    usuario.Nombre = actividad.Nombre;
                    usuario.Apellido1 = actividad.Apellido1;
                    usuario.Apellido2 = actividad.Apellido2;
                    usuario.Nacionalidad = actividad.Nacionalidad;
                    usuario.FechaNacimiento = actividad.FechaNacimiento;
                    usuario.CuentaBancaria = actividad.CuentaBancaria;
                    usuario.Edad = actividad.Edad;
                    usuario.Usuario = actividad.Usuario;
                    usuario.Contrasena = actividad.Contrasena;
                    usuario.Rol = actividad.Rol;

                    db.Usuarios.Add(usuario);
                    db.SaveChanges();

                    return Ok();
                }
                catch
                {
                    return NotFound();
                }


            }

        }

    }
}
