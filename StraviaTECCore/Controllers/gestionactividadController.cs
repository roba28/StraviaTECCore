using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;


/**
 * Su función es insertar y controlar las actividades en los eventos respectivos 
 *
 * @version 1.2, 21/11/2020
 * @author Ronny barahona, Jonathan García, Roger Mora
 */
namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gestionactividadController : ControllerBase
    {

        /** 
    
         * @param Objeto de tipo Amigo  que  almacena  los datos del nuevo amigo
         * 
             
          */
        [HttpGet]
        public IActionResult getgestionactividad()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Gestionactividad.OrderByDescending(d => d.ActividadId).ToList();
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
