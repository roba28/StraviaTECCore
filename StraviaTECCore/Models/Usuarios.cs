using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Actividad = new HashSet<Actividad>();
            AmigosUsuarioSeguidoNavigation = new HashSet<Amigos>();
            AmigosUsuarioSeguidorNavigation = new HashSet<Amigos>();
            GestionCarreras = new HashSet<GestionCarreras>();
            GestionGrupos = new HashSet<GestionGrupos>();
            Gestionretos = new HashSet<Gestionretos>();
            InscripDepCarrera = new HashSet<InscripDepCarrera>();
            Inscripdepreto = new HashSet<Inscripdepreto>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string CuentaBancaria { get; set; }
        public int? Edad { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }
        public byte[] Foto { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Actividad> Actividad { get; set; }
        public ICollection<Amigos> AmigosUsuarioSeguidoNavigation { get; set; }
        public ICollection<Amigos> AmigosUsuarioSeguidorNavigation { get; set; }
        public ICollection<GestionCarreras> GestionCarreras { get; set; }
        public ICollection<GestionGrupos> GestionGrupos { get; set; }
        public ICollection<Gestionretos> Gestionretos { get; set; }
        public ICollection<InscripDepCarrera> InscripDepCarrera { get; set; }
        public ICollection<Inscripdepreto> Inscripdepreto { get; set; }
    }
}
