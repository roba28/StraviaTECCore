using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StraviaTECCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/**
 * Esta  es una clase  que se encarga de gestionar las incripciones de  los usuarios a los  retos. 
 * @version 1.2, 21/11/2020
 * @author Ronny barahona, Jonathan García, Roger Mora
 */

namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripdepretoController : ControllerBase
    {

        /**
         * Utilizado para obtener todos los retos de un deportista 
         * @return  lista de retos inscritos 
         */
        [HttpGet]
        public IActionResult get()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Inscripdepreto.OrderByDescending(d => d.Id).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }


        /**Utilizado para ingresar retos  de un deportista
         * @param  Inscripdepreto pa se obtienen los objetos de las personas inscrita a un reto  y se insertan 
         *
         */
        [HttpPost]
        public IActionResult post(Inscripdepreto pa)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    Inscripdepreto p = new Inscripdepreto();

                    p.Id = pa.Id;
                    p.Usuarioid = pa.Usuarioid;
                    p.Retoid = pa.Retoid;
                    db.Inscripdepreto.Add(p);
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
        * Se borra   inscripción de un usuario a un reto
        * @param  int id  idenficador  del usuario que va a cancerlar la inscripción
        */



        [HttpDelete("del/{id}")]
        public ActionResult delete(int id)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {

                try
                {

                    if (db.Inscripdepreto.Find(id) == null)
                    {

                        return NotFound();


                    }

                    else
                    {
                        var list = db.Inscripdepreto.Find(id);
                        db.Inscripdepreto.Remove(list);
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
