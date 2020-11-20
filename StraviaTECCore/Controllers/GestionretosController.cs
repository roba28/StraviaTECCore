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
    public class ValuesController : ControllerBase
    {


        [HttpGet]
        public IActionResult getReto()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {


                    var list = db.Gestionretos.OrderByDescending(d => d.Retoid).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }

       
        [HttpPost]

        public IActionResult addCarrera(Gestionretos reto)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {
                   
                    
                    Gestionretos nuevoReto = new Gestionretos(reto.OrganizadorId, reto.CategoriaId, reto.Nombre, reto.Periodo, reto.Retoid, reto.Kmrecorridos, reto.Metrosascendidos,reto.Isfondo, reto.Isaltitud, reto.Isprivado, reto.Categoria, reto.Organizador);
                    db.Gestionretos.Add(nuevoReto);
                    db.SaveChanges();

                    return Ok();
                }
                catch
                {
                    return NotFound();
                }


            }

        }
        [HttpPut]
        public IActionResult EditReto(Gestionretos retoUpdate)
        {
            int id = retoUpdate.Retoid;

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {
                    if (db.Usuarios.Find(id) == null)
                    {
                        return NotFound();

                    }
                    else
                    {
                        Gestionretos nuevoReto = new Gestionretos(retoUpdate.OrganizadorId, retoUpdate.CategoriaId, retoUpdate.Nombre, retoUpdate.Periodo,
                            retoUpdate.Retoid, retoUpdate.Kmrecorridos, retoUpdate.Metrosascendidos, retoUpdate.Isfondo, retoUpdate.Isaltitud, retoUpdate.Isprivado, retoUpdate.Categoria, retoUpdate.Organizador);
                        db.Gestionretos.Add(nuevoReto);
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

        //_______________________________________
        [HttpDelete("del/{id}")]
        public ActionResult deletReto(int id)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {

                try
                {

                    if (db.Gestionretos.Find(id) == null)
                    {

                        return NotFound();


                    }

                    else
                    {
                        var list = db.Gestionretos.Find(id);
                        db.Gestionretos.Remove(list);
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

        // obtiene  carrera por el nombre 

        [HttpGet("get/{name}")]
        public IActionResult getRetoname(string name)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Gestionretos.Where(d => d.Nombre.Contains(name)).ToList();
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


    