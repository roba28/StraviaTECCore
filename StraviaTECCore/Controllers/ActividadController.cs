
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;

/**
 * Esta  es una clase  que se encarga de gestionar  registrar y modificar las actividades de los usuarios registrados
 * @version 1.2, 21/11/2020
 * @author Ronny barahona, Jonathan García, Roger Mora
 */

namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {


     /** 
     * Recibe de la  aplicación web   mediante  el modelo de  una actividad
     * @param Actividad actividad un objetio que almacenqa todos los datpos referentes a una actividad
     * Este metodo toma los dato  un usuario  que  registra una actividad desde la web   
      */

        [HttpPost]

        public IActionResult adduser(Models.Actividad actividad)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {// se inicializa el  objeto actividad


                    Actividad actividad1 = new Actividad();
                    db.Actividad.Add(actividad1);
                    db.SaveChanges();
                    

                    return Ok();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                    return NotFound();
                }
            }
        }

  /** 
* Se encarta de enviar las actividades  insertadas en la base  de datos 
* @return lista de actividades
* 
  */

        [HttpGet]
        public IActionResult get()
        {
            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {

                    var search = db.Actividad.OrderByDescending(d => d.ActividadId).ToList();

                    return Ok(search);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }


            }

        }

    }
}