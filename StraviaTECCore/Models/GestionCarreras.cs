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
            Patrocinadoresporcarrera = new HashSet<Patrocinadoresporcarrera>();
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
        public ICollection<Patrocinadoresporcarrera> Patrocinadoresporcarrera { get; set; }
    }
}
