 using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class InscripDepCarrera
    {
        public int Id { get; set; }
        public int Usurioid { get; set; }
        public int Carreraid { get; set; }

        public GestionCarreras Carrera { get; set; }
        public Usuarios Usurio { get; set; }
    }
}
