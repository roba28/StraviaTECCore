using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
                    Actividad actividad1 = new Actividad(nuevoAmigo.UsuarioId, nuevoAmigo.Tiempo, nuevoAmigo.Distancia, nuevoAmigo.Fecha, nuevoAmigo.Hora, nuevoAmigo.InicioRecorrido, nuevoAmigo.Finrecorrido, nuevoAmigo.ActividadId);//, actividad.Usuario);   
                                                                                                                                                                                                                                // se inserta en la base de datos.


                    db.Actividad.Add(actividad1);
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