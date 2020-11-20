using Microsoft.AspNetCore.Http;
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
    public class PatrocinadoresporretosController : ControllerBase
    {


        //Utilizado para obtener todos los patrocinadores de un reto en especifico 
        [HttpGet]
        public IActionResult get()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Patrocinadoresporretos.OrderByDescending(d => d.Id).ToList();
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
        public IActionResult post(Patrocinadoresporretos pa)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    Patrocinadoresporretos p = new Patrocinadoresporretos();

                    p.Id = pa.Id;
                    p.Gestionretoid = pa.Gestionretoid;
                    p.Patrocinadorid = pa.Patrocinadorid;
                    db.Patrocinadoresporretos.Add(p);
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
