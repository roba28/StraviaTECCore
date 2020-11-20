using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StraviaTECCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripdepretoController : ControllerBase
    {

        //Utilizado para obtener todos los retos de un deportista 
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


        //Utilizado para ingresar retos  de un deportista 
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
