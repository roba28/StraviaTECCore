using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class GestionCarreras
    {
        public GestionCarreras()
        {
            Patrocinadores = new HashSet<Patrocinadores>();
        }

        public GestionCarreras(int carreraId, int organizadorId, double? costo, DateTime? fechaCarrera, string nombre, DateTime? inicioRecorrido, DateTime? finRecorrido, int categoriaId, Categoria categoria, Usuarios organizador, Gestionactividad gestionactividad, ICollection<Patrocinadores> patrocinadores)
        {
            CarreraId = carreraId;
            OrganizadorId = organizadorId;
            Costo = costo;
            FechaCarrera = fechaCarrera;
            Nombre = nombre;
            InicioRecorrido = inicioRecorrido;
            FinRecorrido = finRecorrido;
            CategoriaId = categoriaId;
            Categoria = categoria;
            Organizador = organizador;
            Gestionactividad = gestionactividad;
            Patrocinadores = patrocinadores;
        }

        public int CarreraId { get; set; }
        public int OrganizadorId { get; set; }
        public double? Costo { get; set; }
        public DateTime? FechaCarrera { get; set; }
        public string Nombre { get; set; }
        public DateTime? InicioRecorrido { get; set; }
        public DateTime? FinRecorrido { get; set; }
        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }
        public Usuarios Organizador { get; set; }
        public Gestionactividad Gestionactividad { get; set; }
        public ICollection<Patrocinadores> Patrocinadores { get; set; }
    }
}
