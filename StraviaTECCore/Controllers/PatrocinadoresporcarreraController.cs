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
    public class PatrocinadoresporcarreraController : ControllerBase
    {


        //Utilizado para obtener todos los patrocinadores de un reto en especifico 
        [HttpGet]
        public IActionResult get()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Patrocinadoresporcarrera.OrderByDescending(d => d.Id).ToList();
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
        public IActionResult post(Patrocinadoresporcarrera pa)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    Patrocinadoresporcarrera p = new Patrocinadoresporcarrera();

                    p.Id = pa.Id;
                    p.Carreraid = pa.Carreraid;
                    p.Patrocinadorid = pa.Patrocinadorid;
                    db.Patrocinadoresporcarrera.Add(p);
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
