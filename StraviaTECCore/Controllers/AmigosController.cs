using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigosController : ControllerBase
    {

        [HttpPost]

        public IActionResult addFriend(Models.Amigos nuevoAmigo)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {// se inicializa el  objeto actividad
                    Amigos nAmigo = new Amigos(nuevoAmigo.Id, nuevoAmigo.UsuarioSeguido, nuevoAmigo.UsuarioSeguidor);
                    db.SaveChanges();
                    return Ok("El usuario ahora es tu amigo");
                }
                catch
                {
                    return NotFound();
                }
            }
        }

        //obtener amigo

        [HttpGet("find/{id}")]
        public IActionResult getFriend(int id)
        {
            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Amigos.Find(id);

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