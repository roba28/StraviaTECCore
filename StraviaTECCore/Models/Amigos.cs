using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Amigos
    {
        public int UsuarioSeguidor { get; set; }
        public int UsuarioSeguido { get; set; }
        public int Id { get; set; }

        public Usuarios UsuarioSeguidoNavigation { get; set; }
        public Usuarios UsuarioSeguidorNavigation { get; set; }
    }
}
