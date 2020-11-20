using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Actividadesporreto
    {
        public int Id { get; set; }
        public int Retoid { get; set; }
        public int Actividadid { get; set; }

        public Gestionactividad Actividad { get; set; }
        public Gestionretos Reto { get; set; }
    }
}
