using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class GestionGrupos
    {
        public GestionGrupos(int idgrupo, string nombre, int idorganizador, Usuarios idorganizadorNavigation)
        {
            Idgrupo = idgrupo;
            Nombre = nombre;
            Idorganizador = idorganizador;
            IdorganizadorNavigation = idorganizadorNavigation;
        }

        public int Idgrupo { get; set; }
        public string Nombre { get; set; }
        public int Idorganizador { get; set; }

        public Usuarios IdorganizadorNavigation { get; set; }
    }
}
