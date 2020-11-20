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
    public class GruposprivadosporcarreraController : ControllerBase
    {

        // Metodo utilizado para obtener toodos los grupos que pueden acceder a los diferentes retos 
        [HttpGet]
        public IActionResult get()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Gruposprivadosporcarrera.OrderByDescending(d => d.Id).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }


        [HttpGet("get/{name}")]
        public IActionResult getuserbyname(string name)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Gruposprivadosporcarrera.Where(d => d.Carrera.Nombre.Contains(name)).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }





        //-----------------------------------------------------------------------------
        //// Metodo utilizado para eliminar toodos los grupos que pueden acceder a los diferentes retos 

        [HttpDelete("del/{id}")]
        public ActionResult delete(int id)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {

                try
                {

                    if (db.Gruposprivadosporcarrera.Find(id) == null)
                    {

                        return NotFound();


                    }

                    else
                    {
                        var list = db.Gruposprivadosporcarrera.Find(id);
                        db.Gruposprivadosporcarrera.Remove(list);
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



        //---------------------------------------------------------------------
        //// Metodo utilizado para crear toodos los grupos que pueden acceder a los diferentes retos 

        [HttpPost]

        public IActionResult add(Gruposprivadosporcarrera grupo)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    Gruposprivadosporcarrera grup = new Gruposprivadosporcarrera();

                    grup.Id = grupo.Id;
                    grup.Carreraid = grupo.Carreraid;
                    grup.Gestiongruposid = grupo.Gestiongruposid;


                    db.Gruposprivadosporcarrera.Add(grup);
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
