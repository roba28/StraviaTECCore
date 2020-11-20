using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                {

                    if (nuevoAmigo == null ) {
                        return NotFound();
                    }
                    // var list = db.Usuarios.OrderByDescending(d => d.UsuarioId).ToList();

                   

                    Amigos nAmigo = new Amigos( nuevoAmigo.UsuarioSeguido, nuevoAmigo.UsuarioSeguidor, nuevoAmigo.i );
                    db.SaveChanges();
                    return Ok("se ha registrado");
                }
                catch
                {
                    return NotFound();
                }
            }
        }



        /// nuevo metodo de  añadir amigos 
        /// 


        //obtener amigo por el id

        [HttpGet("find/{id}")]
        public IActionResult getFriend(int usuario)
        {
            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    List <Usuarios> amigos = new List<Usuarios>();
                    var search = db.Amigos.AsNoTracking().Where(u => u.Id ==usuario).ToList();

                    foreach (var amigo in search)
                    {

                       
                        var amigoUser =  db.Usuarios.FirstOrDefaultAsync(p => p.UsuarioId == amigo.Id);

                        if (amigoUser == null) continue;

                        amigos.Add(amigoUser);
                    }

                    return Ok(amigos);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }


            }

        }

    }
}