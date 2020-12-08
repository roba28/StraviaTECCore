using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class GestionCarreras
    {
        public GestionCarreras()
        {
            Gruposprivadosporcarrera = new HashSet<Gruposprivadosporcarrera>();
            InscripDepCarrera = new HashSet<InscripDepCarrera>();
            Patrocinadores = new HashSet<Patrocinadores>();
            Patrocinadoresporcarrera = new HashSet<Patrocinadoresporcarrera>();
        }

        public GestionCarreras(int carreraId, int organizadorId, decimal? costo, DateTime? fechaCarrera, string nombre, DateTime? inicioRecorrido, DateTime? finRecorrido, int categoriaId, string tipoactividad, bool? isprivado, string cuentabancaria, Categoria categoria, Usuarios organizador, ICollection<Gruposprivadosporcarrera> gruposprivadosporcarrera, ICollection<InscripDepCarrera> inscripDepCarrera, ICollection<Patrocinadores> patrocinadores, ICollection<Patrocinadoresporcarrera> patrocinadoresporcarrera)
        {
            CarreraId = carreraId;
            OrganizadorId = organizadorId;
            Costo = costo;
            FechaCarrera = fechaCarrera;
            Nombre = nombre;
            InicioRecorrido = inicioRecorrido;
            FinRecorrido = finRecorrido;
            CategoriaId = categoriaId;
            Tipoactividad = tipoactividad;
            Isprivado = isprivado;
            Cuentabancaria = cuentabancaria;
            Categoria = categoria;
            Organizador = organizador;
            Gruposprivadosporcarrera = gruposprivadosporcarrera;
            InscripDepCarrera = inscripDepCarrera;
            Patrocinadores = patrocinadores;
            Patrocinadoresporcarrera = patrocinadoresporcarrera;
        }

        public int CarreraId { get; set; }
        public int OrganizadorId { get; set; }
        public decimal? Costo { get; set; }
        public DateTime? FechaCarrera { get; set; }
        public string Nombre { get; set; }
        public DateTime? InicioRecorrido { get; set; }
        public DateTime? FinRecorrido { get; set; }
        public int CategoriaId { get; set; }
        public string Tipoactividad { get; set; }
        public bool? Isprivado { get; set; }
        public string Cuentabancaria { get; set; }

        public Categoria Categoria { get; set; }
        public Usuarios Organizador { get; set; }
        public ICollection<Gruposprivadosporcarrera> Gruposprivadosporcarrera { get; set; }
        public ICollection<InscripDepCarrera> InscripDepCarrera { get; set; }
        public ICollection<Patrocinadores> Patrocinadores { get; set; }
        public ICollection<Patrocinadoresporcarrera> Patrocinadoresporcarrera { get; set; }
    }
}