﻿using Microsoft.AspNetCore.Http;
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
    public class GestionCarrerasController : ControllerBase
    {

// retirna  todas la carreras registradas
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

        // crear una carrera
        [HttpPost]

        public IActionResult addCarrera(GestionCarreras nuevaCarrera)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {
                    GestionCarreras gc = new GestionCarreras(nuevaCarrera.CarreraId, nuevaCarrera.OrganizadorId, nuevaCarrera.Costo, nuevaCarrera.FechaCarrera,
                        nuevaCarrera.Nombre, nuevaCarrera.InicioRecorrido, nuevaCarrera.FinRecorrido, nuevaCarrera.CarreraId, nuevaCarrera.Tipoactividad,
                        nuevaCarrera.Isprivado, nuevaCarrera.Cuentabancaria, nuevaCarrera.Categoria, nuevaCarrera.Organizador, nuevaCarrera.Gruposprivadosporcarrera,
                        nuevaCarrera.InscripDepCarrera,nuevaCarrera.Patrocinadores, nuevaCarrera.Patrocinadoresporcarrera  );

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

        // obtiene  carrera por el nombre 

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




