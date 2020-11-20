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
    public class PatrocinadoresController : ControllerBase
    {


        //Utilizado para obtener todos los patrocinadores 
        [HttpGet]
        public IActionResult get()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Patrocinadores.OrderByDescending(d => d.Id).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }


        //Utilizado para ingresar patrocinadores a un reto especifico 
        [HttpPost]
        public IActionResult post(Patrocinadores pa)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    Patrocinadores p = new Patrocinadores();

                    p.Id = pa.Id;
                    p.Nombre = pa.Nombre;
                    db.Patrocinadores.Add(p);
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
