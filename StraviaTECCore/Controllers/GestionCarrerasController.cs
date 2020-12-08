using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StraviaTECCore.Models;
using System.Web.Http.Cors;



/**
 *La función de esta clase es es insertar, actualizar eliminar y controlarLas insercioens de carreras de los usuarios
 * @version 1.2, 21/11/2020
 * @author Ronny barahona, Jonathan García, Roger Mora
 */
namespace StraviaTECCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestionCarrerasController : ControllerBase
    {
        /**
         * Metodo que  retorna   todas la carreras registradas
         * @return Listado de carreras  que se han resgistrado web la pagina web
         */
        [HttpGet]
        public IActionResult getCarreras()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {


                    var list = db.GestionCarreras.OrderByDescending(d => d.CarreraId).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }

        /**
          * Este método post se encarga de realizar una inserción de una  carrera
          * @param Listado de carreras  que se han resgistrado web la pagina web
          */
        [HttpPost]

        public IActionResult addCarrera(GestionCarreras nuevaCarrera)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {// inicializa contructor con el  objeto de tipo carrera
                    GestionCarreras gc = new GestionCarreras(nuevaCarrera.CarreraId, nuevaCarrera.OrganizadorId, nuevaCarrera.Costo, nuevaCarrera.FechaCarrera,
                        nuevaCarrera.Nombre, nuevaCarrera.InicioRecorrido, nuevaCarrera.FinRecorrido, nuevaCarrera.CarreraId, nuevaCarrera.Tipoactividad,
                        nuevaCarrera.Isprivado, nuevaCarrera.Cuentabancaria, nuevaCarrera.Categoria, nuevaCarrera.Organizador, nuevaCarrera.Gruposprivadosporcarrera,
                        nuevaCarrera.InscripDepCarrera, nuevaCarrera.Patrocinadores, nuevaCarrera.Patrocinadoresporcarrera);

                    db.GestionCarreras.Add(gc);
                    db.SaveChanges();

                    return Ok();
                }
                catch
                {
                    return NotFound();
                }


            }

        }
        /**
         * Este metodo se encarga de  realizar actualizaciones a las carreras que se registraron en la pagina weg, independientemente
         * de si esta es privada o reto
         * @param Recibe la carrera a la cual se le atribuye la actualización corrobora si existe  y lo actualiza
         */
        [HttpPut]
        public IActionResult Edituser(GestionCarreras carreraUpdate)
        {
            int id = carreraUpdate.CarreraId;

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
                        GestionCarreras gc = new GestionCarreras(carreraUpdate.CarreraId, carreraUpdate.OrganizadorId, carreraUpdate.Costo, carreraUpdate.FechaCarrera,
                        carreraUpdate.Nombre, carreraUpdate.InicioRecorrido, carreraUpdate.FinRecorrido, carreraUpdate.CarreraId, carreraUpdate.Tipoactividad,
                        carreraUpdate.Isprivado, carreraUpdate.Cuentabancaria, carreraUpdate.Categoria, carreraUpdate.Organizador, carreraUpdate.Gruposprivadosporcarrera,
                        carreraUpdate.InscripDepCarrera, carreraUpdate.Patrocinadores, carreraUpdate.Patrocinadoresporcarrera);

                        db.GestionCarreras.Add(gc);
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
        /**
         * Se procede a borrar un  evento, recibiendo  como parametro el ID del evento, para poder ser borrado en la base de datos.
         * 
         * @param int id  idenficador de la carrera  que hay que eliminar  de la base de  datos.
         */

        //_______________________________________
        [HttpDelete("del/{id}")]
        public ActionResult deletCarrera(int id)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {

                try
                {

                    if (db.GestionCarreras.Find(id) == null)
                    {

                        return NotFound();


                    }

                    else
                    {
                        var list = db.GestionCarreras.Find(id);
                        db.GestionCarreras.Remove(list);
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

        /*
         * Metodo  que  busca la carrera  por el nombre  y la retorna  de la base de datos en casod e encontrarla 
         * @param  un dato de tipo String  que se va a comparar con los datos de la base de datos y lo va a retornar 
         */

        [HttpGet("get/{name}")]
        public IActionResult getRacebyname(string name)
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.GestionCarreras.Where(d => d.Nombre.Contains(name)).ToList();
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