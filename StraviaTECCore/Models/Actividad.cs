using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Actividad
    {
        public int UsuarioId { get; set; }
        public DateTime Tiempo { get; set; }
        public double? Distancia { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime Hora { get; set; }
        public DateTime InicioRecorrido { get; set; }
        public DateTime? Finrecorrido { get; set; }
        public int ActividadId { get; set; }

        public Usuarios Usuario { get; set; }
    }
}
