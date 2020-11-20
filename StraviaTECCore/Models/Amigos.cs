using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Amigos
    {
        public Amigos(int usuarioSeguidor, int usuarioSeguido, int id)
        {
          this. UsuarioSeguidor = usuarioSeguidor;
           this. UsuarioSeguido = usuarioSeguido;
            this.Id = id;
          


             
    }

        public int UsuarioSeguidor { get; set; }
        public int UsuarioSeguido { get; set; }
        public int Id { get; set; }
        

        public Usuarios UsuarioSeguidoNavigation { get; set; }
        public Usuarios UsuarioSeguidorNavigation { get; set; }
    }
}
