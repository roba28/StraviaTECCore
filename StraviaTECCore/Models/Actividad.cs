﻿using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Actividad
    {
        

        public Actividad(int usuarioId, TimeSpan[] tiempo, double? distancia, DateTime? fecha, TimeSpan[] hora, DateTime? inicioRecorrido, DateTime? finrecorrido, int actividadId)
        {//inicializa contructor

            UsuarioId = usuarioId;
            Tiempo = tiempo;
            Distancia = distancia;
            Fecha = fecha;
            Hora = hora;
            InicioRecorrido = inicioRecorrido;
            Finrecorrido = finrecorrido;
            ActividadId = actividadId;
            //Usuario = usuario;
        }

        public int UsuarioId { get; set; }
        public double? Distancia { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime? InicioRecorrido { get; set; }
        public DateTime? Finrecorrido { get; set; }
        public DateTime? Hora { get; set; }
        public int ActividadId { get; set; }
        public decimal? Kilometros { get; set; }
        public decimal? Duracion { get; set; }
        public string Tipo { get; set; }
        public bool? Iscompletitudreto { get; set; }
        public bool? Iscompletitudcarrera { get; set; }

        public Usuarios Usuario { get; set; }
    }
}
