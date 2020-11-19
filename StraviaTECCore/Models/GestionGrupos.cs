using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class GestionGrupos
    {
        public int Idgrupo { get; set; }
        public string Nombre { get; set; }
        public int Idorganizador { get; set; }

        public Usuarios IdorganizadorNavigation { get; set; }
    }
}
