using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            GestionCarreras = new HashSet<GestionCarreras>();
            Gestionretos = new HashSet<Gestionretos>();
        }

        public int CategoriaId { get; set; }
        public string Tipo { get; set; }

        public ICollection<GestionCarreras> GestionCarreras { get; set; }
        public ICollection<Gestionretos> Gestionretos { get; set; }
    }
}
