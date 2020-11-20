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

        public Categoria(int categoriaId, string tipo, string nombre)
        {
            CategoriaId = categoriaId;
            Tipo = tipo;
            Nombre = nombre;
        }

        public int CategoriaId { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }

        public ICollection<GestionCarreras> GestionCarreras { get; set; }
        public ICollection<Gestionretos> Gestionretos { get; set; }
    }
}
