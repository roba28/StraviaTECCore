using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Gruposprivadosporreto
    {
        public int Id { get; set; }
        public int Grupoid { get; set; }
        public int Retoid { get; set; }

        public GestionGrupos Grupo { get; set; }
        public Gestionretos Reto { get; set; }
    }
}
