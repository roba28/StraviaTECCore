using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Patrocinadores
    {
        public Patrocinadores()
        {
            Patrocinadoresporcarrera = new HashSet<Patrocinadoresporcarrera>();
            Patrocinadoresporretos = new HashSet<Patrocinadoresporretos>();
        }

        public int CarreraId { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }

        public GestionCarreras Carrera { get; set; }
        public ICollection<Patrocinadoresporcarrera> Patrocinadoresporcarrera { get; set; }
        public ICollection<Patrocinadoresporretos> Patrocinadoresporretos { get; set; }
    }
}
