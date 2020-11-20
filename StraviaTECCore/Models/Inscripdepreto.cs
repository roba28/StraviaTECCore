using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Inscripdepreto
    {
        public int Id { get; set; }
        public int Usuarioid { get; set; }
        public int Retoid { get; set; }

        public Gestionretos Reto { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
