using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Gestionretos
    {
        public Gestionretos(int retoId, int organizadorId, int categoriaId, string nombre, DateTime? periodo, Categoria categoria, Usuarios organizador)
        {
            RetoId = retoId;
            OrganizadorId = organizadorId;
            CategoriaId = categoriaId;
            Nombre = nombre;
            Periodo = periodo;
            Categoria = categoria;
            Organizador = organizador;
        }

        public int RetoId { get; set; }
        public int OrganizadorId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public DateTime? Periodo { get; set; }

        public Categoria Categoria { get; set; }
        public Usuarios Organizador { get; set; }
    }
}
