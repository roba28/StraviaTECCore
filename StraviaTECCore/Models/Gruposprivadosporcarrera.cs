using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Gruposprivadosporcarrera
    {
        public int Id { get; set; }
        public int Gestiongruposid { get; set; }
        public int Carreraid { get; set; }

        public GestionCarreras Carrera { get; set; }
        public GestionGrupos Gestiongrupos { get; set; }
    }
}
