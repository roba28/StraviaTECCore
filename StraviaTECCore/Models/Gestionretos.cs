﻿using System;
using System.Collections.Generic;

namespace StraviaTECCore.Models
{
    public partial class Gestionretos
    {
        public Gestionretos()
        {
            Actividadesporreto = new HashSet<Actividadesporreto>();
            Gruposprivadosporreto = new HashSet<Gruposprivadosporreto>();
            Inscripdepreto = new HashSet<Inscripdepreto>();
            Patrocinadoresporretos = new HashSet<Patrocinadoresporretos>();
        }

        public Gestionretos(int organizadorId, int categoriaId, string nombre, DateTime? periodo,
            int retoid, decimal? kmrecorridos, decimal? metrosascendidos, bool? isfondo, bool? isaltitud, 
            bool? isprivado, Categoria categoria, Usuarios organizador)
        {
            OrganizadorId = organizadorId;
            CategoriaId = categoriaId;
            Nombre = nombre;
            Periodo = periodo;
            Retoid = retoid;
            Kmrecorridos = kmrecorridos;
            Metrosascendidos = metrosascendidos;
            Isfondo = isfondo;
            Isaltitud = isaltitud;
            Isprivado = isprivado;
            Categoria = categoria;
            Organizador = organizador;
        }

        public int OrganizadorId { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public DateTime? Periodo { get; set; }
        public int Retoid { get; set; }
        public decimal? Kmrecorridos { get; set; }
        public decimal? Metrosascendidos { get; set; }
        public bool? Isfondo { get; set; }
        public bool? Isaltitud { get; set; }
        public bool? Isprivado { get; set; }

        public Categoria Categoria { get; set; }
        public Usuarios Organizador { get; set; }
        public ICollection<Actividadesporreto> Actividadesporreto { get; set; }
        public ICollection<Gruposprivadosporreto> Gruposprivadosporreto { get; set; }
        public ICollection<Inscripdepreto> Inscripdepreto { get; set; }
        public ICollection<Patrocinadoresporretos> Patrocinadoresporretos { get; set; }
    }
}
