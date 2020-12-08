using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;

/**
 * Esta Clase  que se encarga de gestionar  registrar y modificar las  los amigos de los usuarios retgistrados registrados
 * @version 1.2, 21/11/2020
 * @author Ronny barahona, Jonathan García,Roger Mora
 */
namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigosController : ControllerBase
    {


        /** 
        * Recibe de la  aplicación web   mediante  el modelo de  un amigos, un objeto de los dato un usuario que registra como Amigos del usuario
        * 
        * @param Objeto de tipo Amigo  que  almacena  los datos del nuevo amigo
        * 
            
         */
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
                catch(Exception e)
                {
                    throw new Exception(e.ToString());
                    return BadRequest(e) ;
                }
            }
        }




        /** 
       * Recibe de la  aplicación web   mediante  el modelo de  un amigos, un objeto de los dato un usuario que registra como Amigos del usuario
       * 
       * @param Objeto de tipo Amigo  que  almacena  los datos del nuevo amigo
       * 
           
        */



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
                    throw new Exception(e.ToString());
                }


            }

        }

     /** 
     * Se encarga en enviar  a la pagina we los amigos del usuario.
     * @return listado de amigos 
     *  
      */

        [HttpGet]
        public IActionResult get()
        {
            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {

                    var search = db.Amigos.OrderByDescending(d => d.Id).ToList();

                    return Ok(search);
                }
                catch (Exception e)
                {
                    throw new Exception(e.ToString());
                    
                }


            }

        }


        /**
         * recibe de la pagina web el id del  amigo al que desea eliminar de la base de datos.
         *@param int id identidicador del amigo que voy a eliminar 
         */
            

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