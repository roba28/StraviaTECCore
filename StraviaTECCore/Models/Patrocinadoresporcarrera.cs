using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Patrocinadoresporcarrera
    {
        public int Id { get; set; }
        public int Carreraid { get; set; }
        public int Patrocinadorid { get; set; }

        public GestionCarreras Carrera { get; set; }
        public Patrocinadores Patrocinador { get; set; }
    }
}
