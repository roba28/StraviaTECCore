
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;


namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {



        // este metodo toma los dato  un usuario  que  registra una actividad desde la web

        [HttpPost]

        public IActionResult adduser(Models.Actividad actividad)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {// se inicializa el  objeto actividad

                   Actividad actividad1= new Actividad(actividad.UsuarioId, actividad.Distancia,actividad.            )
                    db.Actividad.Add(actividad1);
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