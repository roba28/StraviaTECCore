using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StraviaTECCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



/**
 * Esta  es una clase  que se encarga de gestionar las incripciones de  los usuarios a las carreras, 
 * @version 1.2, 21/11/2020
 * @author Ronny barahona, Jonathan García, Roger Mora
 */

namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripDepCarreraController : ControllerBase
    {

        /**
         * Utilizado para obtener todos los retos de un deportista 
         * @return lista de inscripciones por  carrera que se han resgistrado
         */
        [HttpGet]
        public IActionResult get()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.InscripDepCarrera.OrderByDescending(d => d.Id).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }


        /**
         * Metodo  utilizado para  ingresar  un inscripción de un deportista  a una carrera
         * @param InscripDepCarrera pa recibe informacion de la carrera, el tipo, si es un reto o carrera, si es publico y privado
         */
        [HttpPost]
        public IActionResult post(InscripDepCarrera pa)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    InscripDepCarrera p = new InscripDepCarrera();

                    p.Id = pa.Id;
                    p.Carreraid = pa.Carreraid;
                    p.Usurioid = pa.Usurioid;
                    db.InscripDepCarrera.Add(p);
                    db.SaveChanges();

                    return Ok();
                }
                catch
                {
                    return NotFound();
                }


            }


        }


        /**
         * Se borra   inscripción de un usuario a una carrera
         * @param  int id  idenficador  del usuari que va a cancerlar la inscripción
         */

        [HttpDelete("del/{id}")]
        public ActionResult delete(int id)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {

                try
                {

                    if (db.InscripDepCarrera.Find(id) == null)
                    {

                        return NotFound();


                    }

                    else
                    {
                        var list = db.InscripDepCarrera.Find(id);
                        db.InscripDepCarrera.Remove(list);
                        db.SaveChanges();

                        return Ok();
                    }
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }

            }
        }


    }

}

