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
    public class InscripDepCarreraController : ControllerBase
    {

        //Utilizado para obtener todos los retos de un deportista 
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


        //Utilizado para ingresar retos  de un deportista 
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

