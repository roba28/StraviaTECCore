using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Gestionactividad
    {
        public Gestionactividad()
        {
            Actividadesporreto = new HashSet<Actividadesporreto>();
        }

        public string Tipo { get; set; }
        public string Clasificacion { get; set; }
        public int ActividadId { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Duracion { get; set; }
        public decimal? Kilometros { get; set; }

        public ICollection<Actividadesporreto> Actividadesporreto { get; set; }
    }
}
