using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Gestionretos
    {
        public int RetoId { get; set; }
        public int OrganizadorId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public DateTime? Periodo { get; set; }

        public Categoria Categoria { get; set; }
        public Usuarios Organizador { get; set; }
    }
}
