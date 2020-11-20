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
    public class contactenosController : ControllerBase

    {

        [HttpGet]
        public IActionResult getuser()
        {


            using (Straviatec_DBContext db = new Straviatec_DBContext())
            {
                try
                {
                    var list = db.Contactenos.OrderByDescending(d => d.Nombre).ToList();
                    return Ok(list);
                }
                catch (Exception e)
                {
                    return NotFound(e);
                }
            }
        }

        [HttpPost]

        public IActionResult addcont(Contactenos con)
        {

            using (Straviatec_DBContext db = new Straviatec_DBContext())

            {
                try
                {

                    Contactenos contactenos = new Contactenos();
                   
                    contactenos.Nombre = con.Nombre;
                    contactenos.Apellidos = con.Apellidos;
                    contactenos.Email = con.Email;
                    contactenos.Razon = con.Razon;
                    contactenos.Id = con.Id;
                    contactenos.Telefono = con.Telefono;


                    db.Contactenos.Add(contactenos);
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