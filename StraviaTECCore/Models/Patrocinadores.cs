﻿using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Patrocinadores
    {
        public Patrocinadores(int carreraId, string nombre, int id, GestionCarreras carrera)
        {
            CarreraId = carreraId;
            Nombre = nombre;
            Id = id;
            Carrera = carrera;
        }

        public int CarreraId { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }

        public GestionCarreras Carrera { get; set; }
    }
}
