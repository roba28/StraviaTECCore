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
        public IActionResult addFriend(Amigos nuevoAmigo)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    Amigos am = new Amigos();

                    am.Id = nuevoAmigo.Id;
                    am.UsuarioSeguido = nuevoAmigo.UsuarioSeguido;
                    am.UsuarioSeguidor = nuevoAmigo.UsuarioSeguidor;

                    db.Amigos.Add(am);

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
                  
                    var search = db.Amigos.Where(u => u.Id ==usuario).ToList();

                    return Ok(search);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }


            }

        }




        [HttpDelete("del/{id}")]
        public ActionResult deleteuser(int id)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {

                try
                {

                    if (db.Amigos.Find(id) == null)
                    {

                        return NotFound();


                    }

                    else
                    {
                        var list = db.Amigos.Find(id);
                        db.Amigos.Remove(list);
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