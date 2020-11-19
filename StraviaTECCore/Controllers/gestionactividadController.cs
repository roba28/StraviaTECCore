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
    public class gestionactividadController : ControllerBase
    {

        [HttpGet]
        [HttpGet]
        public IActionResult getgestionactividad()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Gestionactividad.OrderByDescending(d => d.Gestion).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }


    }
}
