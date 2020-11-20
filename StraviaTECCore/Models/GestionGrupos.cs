using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class GestionGrupos
    {
        public GestionGrupos()
        {
            Gruposprivadosporcarrera = new HashSet<Gruposprivadosporcarrera>();
            Gruposprivadosporreto = new HashSet<Gruposprivadosporreto>();
        }

        public GestionGrupos(int idgrupo, string nombre, int idorganizador, Usuarios idorganizadorNavigation, ICollection<Gruposprivadosporcarrera> gruposprivadosporcarrera, ICollection<Gruposprivadosporreto> gruposprivadosporreto)
        {
            Idgrupo = idgrupo;
            Nombre = nombre;
            Idorganizador = idorganizador;
            IdorganizadorNavigation = idorganizadorNavigation;
            Gruposprivadosporcarrera = gruposprivadosporcarrera;
            Gruposprivadosporreto = gruposprivadosporreto;
        }

        public int Idgrupo { get; set; }
        public string Nombre { get; set; }
        public int Idorganizador { get; set; }

        public Usuarios IdorganizadorNavigation { get; set; }
        public ICollection<Gruposprivadosporcarrera> Gruposprivadosporcarrera { get; set; }
        public ICollection<Gruposprivadosporreto> Gruposprivadosporreto { get; set; }
    }
}
