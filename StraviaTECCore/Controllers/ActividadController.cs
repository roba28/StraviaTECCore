<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;


=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
>>>>>>> Jonathan

namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {



<<<<<<< HEAD
       // este metodo toma los dato  un usuario  que  registra una actividad desde la web

        [HttpPost]

        public IActionResult adduser(Models.Actividad actividad)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {// se inicializa el  objeto actividad
                    Actividad actividad1 = new Actividad(actividad.UsuarioId, actividad.Tiempo, actividad.Distancia, actividad.Fecha, actividad.Hora, actividad.InicioRecorrido, actividad.Finrecorrido, actividad.ActividadId);//, actividad.Usuario);   
                    // se inserta en la base de datos 
                    db.Actividad.Add(actividad1);
=======
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
>>>>>>> Jonathan
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
