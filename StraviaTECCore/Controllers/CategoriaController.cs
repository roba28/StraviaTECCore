using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;

/**
 * Esta Clase  que se encarga de registo de Catagor5ias de los diferente eventos
 * @version 1.2, 21/11/2020
 * @author Ronny barahona, Jonathan García, Roger Mora
 */

namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        /** 
         * se encarga de devolver las categorías   insertadas en la aplicación 
         * @retun Listado de categorías 
          */

        [HttpGet]
        public IActionResult getCategorias()
        {
            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {

                    var list = db.Categoria.OrderByDescending(d => d.CategoriaId).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }


        /** 
        * Recibe de la  aplicación web   mediante  el modelo de  Categorías, un objeto de los dato  de categoría  y lo inserta en la base de datos
        * @param Objeto de tipo Categoría  que  almacena  los datos del nuevo amigo
        * 
            
         */
        [HttpPost]
        public IActionResult addCategoria(Categoria categoria)
        {
            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    Categoria cat = new Categoria();
  

                    db.Categoria.Add(cat);
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
