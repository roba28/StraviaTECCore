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
    public class GestionGruposController : ControllerBase
    {
        // devuelve los grupos  a los cuales se pueden unnir enla carreras
        [HttpGet]
        public IActionResult getGrupos()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {


                    var list = db.GestionGrupos.OrderByDescending(d => d.Idgrupo).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }

        // crear una carrera
        [HttpPost]

        public IActionResult addGrupo(GestionGrupos grupo)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {
                    GestionGrupos esGrup = new GestionGrupos(grupo.Idgrupo, grupo.Nombre, grupo.Idgrupo, grupo.IdorganizadorNavigation, grupo.Gruposprivadosporcarrera, grupo.Gruposprivadosporreto);
                    db.GestionGrupos.Add(esGrup);
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
        public IActionResult Edituser(GestionGrupos grupo)
        {
            int id = grupo.Idgrupo;

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
                       GestionGrupos esGrup = new GestionGrupos(grupo.Idgrupo, grupo.Nombre, grupo.Idgrupo, grupo.IdorganizadorNavigation, grupo.Gruposprivadosporcarrera, grupo.Gruposprivadosporreto);
                    db.GestionGrupos.Add(esGrup);
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
        public ActionResult deletCarrera(int id)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {

                try
                {

                    if (db.GestionGrupos.Find(id) == null)
                    {

                        return NotFound();


                    }

                    else
                    {
                        var list = db.GestionGrupos.Find(id);
                        db.GestionGrupos.Remove(list);
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
        public IActionResult getRacebyname(string name)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.GestionGrupos.Where(d => d.Nombre.Contains(name)).ToList();
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
