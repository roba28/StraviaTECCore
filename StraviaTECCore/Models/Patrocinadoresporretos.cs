using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Patrocinadoresporretos
    {
        public int Id { get; set; }
        public int Gestionretoid { get; set; }
        public int Patrocinadorid { get; set; }

        public Gestionretos Gestionreto { get; set; }
        public Patrocinadores Patrocinador { get; set; }
    }
}
