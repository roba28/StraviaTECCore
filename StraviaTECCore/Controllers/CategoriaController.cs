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
    public class CategoriaController : ControllerBase
    {
        // se encarga de devolver las categorías   insertadas en la aplicación
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


        //----------------------------------------------------------
        [HttpPost]
        public IActionResult addCategoria(Categoria categoria)
        {
            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    Categoria cat = new Categoria(categoria.CategoriaId, categoria.Tipo,categoria.Nombre);
  

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
