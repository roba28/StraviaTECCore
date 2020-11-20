using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StraviaTECCore.Models
{
    public partial class Straviatec_DBContext : DbContext
    {
        public Straviatec_DBContext()
        {
        }

        public Straviatec_DBContext(DbContextOptions<Straviatec_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Actividadesporreto> Actividadesporreto { get; set; }
        public virtual DbSet<Amigos> Amigos { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Contactenos> Contactenos { get; set; }
        public virtual DbSet<Gestionactividad> Gestionactividad { get; set; }
        public virtual DbSet<GestionCarreras> GestionCarreras { get; set; }
        public virtual DbSet<GestionGrupos> GestionGrupos { get; set; }
        public virtual DbSet<Gestionretos> Gestionretos { get; set; }
        public virtual DbSet<Gruposprivadosporcarrera> Gruposprivadosporcarrera { get; set; }
        public virtual DbSet<Gruposprivadosporreto> Gruposprivadosporreto { get; set; }
        public virtual DbSet<InscripDepCarrera> InscripDepCarrera { get; set; }
        public virtual DbSet<Inscripdepreto> Inscripdepreto { get; set; }
        public virtual DbSet<Patrocinadores> Patrocinadores { get; set; }
        public virtual DbSet<Patrocinadoresporcarrera> Patrocinadoresporcarrera { get; set; }
        public virtual DbSet<Patrocinadoresporretos> Patrocinadoresporretos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("host=localhost;database=Straviatec_DB;user id=postgres; port=5432; password=palomo1995");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.ToTable("actividad");

                entity.ForNpgsqlHasComment("En esta tabla se guardaran todas las actividades individuales que realiza cada deportista ");

                entity.Property(e => e.ActividadId).HasColumnName("actividadID");

                entity.Property(e => e.Distancia).HasColumnName("distancia");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Finrecorrido).HasColumnName("finrecorrido");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.InicioRecorrido).HasColumnName("inicioRecorrido");

                entity.Property(e => e.Iscompletitudcarrera).HasColumnName("iscompletitudcarrera");

                entity.Property(e => e.Iscompletitudreto).HasColumnName("iscompletitudreto");

                entity.Property(e => e.Kilometros).HasColumnName("kilometros");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("usuarioID");
            });

            modelBuilder.Entity<Actividadesporreto>(entity =>
            {
                entity.ToTable("actividadesporreto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Actividadid).HasColumnName("actividadid");

                entity.Property(e => e.Retoid).HasColumnName("retoid");

                entity.HasOne(d => d.Actividad)
                    .WithMany(p => p.Actividadesporreto)
                    .HasForeignKey(d => d.Actividadid)
                    .HasConstraintName("actividadID");

                entity.HasOne(d => d.Reto)
                    .WithMany(p => p.Actividadesporreto)
                    .HasForeignKey(d => d.Retoid)
                    .HasConstraintName("retoid");
            });

            modelBuilder.Entity<Amigos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UsuarioSeguido).HasColumnName("usuarioSeguido");

                entity.HasOne(d => d.UsuarioSeguidoNavigation)
                    .WithMany(p => p.AmigosUsuarioSeguidoNavigation)
                    .HasForeignKey(d => d.UsuarioSeguido)
                    .HasConstraintName("seguido");

                entity.HasOne(d => d.UsuarioSeguidorNavigation)
                    .WithMany(p => p.AmigosUsuarioSeguidorNavigation)
                    .HasForeignKey(d => d.UsuarioSeguidor)
                    .HasConstraintName("seguidor");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<Contactenos>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellidos).HasColumnName("apellidos");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Razon).HasColumnName("razon");

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<Gestionactividad>(entity =>
            {
                entity.HasKey(e => e.ActividadId);

                entity.ToTable("gestionactividad");

                entity.Property(e => e.ActividadId).HasColumnName("actividadID");

                entity.Property(e => e.Clasificacion).HasColumnName("clasificacion");

                entity.Property(e => e.Duracion).HasColumnName("duracion");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Kilometros).HasColumnName("kilometros");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            modelBuilder.Entity<GestionCarreras>(entity =>
            {
                entity.HasKey(e => e.CarreraId);

                entity.ToTable("gestionCarreras");

                entity.Property(e => e.CarreraId).HasColumnName("carreraID");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.Cuentabancaria).HasColumnName("cuentabancaria");

                entity.Property(e => e.FechaCarrera)
                    .HasColumnName("fechaCarrera")
                    .HasColumnType("date");

                entity.Property(e => e.FinRecorrido).HasColumnName("finRecorrido");

                entity.Property(e => e.InicioRecorrido).HasColumnName("inicioRecorrido");

                entity.Property(e => e.Isprivado).HasColumnName("isprivado");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.OrganizadorId).HasColumnName("organizadorID");

                entity.Property(e => e.Tipoactividad).HasColumnName("tipoactividad");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.GestionCarreras)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("categoriaID");

                entity.HasOne(d => d.Organizador)
                    .WithMany(p => p.GestionCarreras)
                    .HasForeignKey(d => d.OrganizadorId)
                    .HasConstraintName("organizadorID");
            });

            modelBuilder.Entity<GestionGrupos>(entity =>
            {
                entity.HasKey(e => e.Idgrupo);

                entity.ToTable("gestionGrupos");

                entity.Property(e => e.Idgrupo).HasColumnName("IDGrupo");

                entity.Property(e => e.Idorganizador).HasColumnName("IDorganizador");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.HasOne(d => d.IdorganizadorNavigation)
                    .WithMany(p => p.GestionGrupos)
                    .HasForeignKey(d => d.Idorganizador)
                    .HasConstraintName("IDorganizador");
            });

            modelBuilder.Entity<Gestionretos>(entity =>
            {
                entity.HasKey(e => e.Retoid);

                entity.ToTable("gestionretos");

                entity.Property(e => e.Retoid).HasColumnName("retoid");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");

                entity.Property(e => e.Isaltitud).HasColumnName("isaltitud");

                entity.Property(e => e.Isfondo).HasColumnName("isfondo");

                entity.Property(e => e.Isprivado).HasColumnName("isprivado");

                entity.Property(e => e.Kmrecorridos).HasColumnName("kmrecorridos");

                entity.Property(e => e.Metrosascendidos).HasColumnName("metrosascendidos");

                entity.Property(e => e.Nombre).HasColumnName("nombre ");

                entity.Property(e => e.OrganizadorId).HasColumnName("organizadorID");

                entity.Property(e => e.Periodo)
                    .HasColumnName("periodo")
                    .HasColumnType("date");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Gestionretos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("categoriaID");

                entity.HasOne(d => d.Organizador)
                    .WithMany(p => p.Gestionretos)
                    .HasForeignKey(d => d.OrganizadorId)
                    .HasConstraintName("organizadorID");
            });

            modelBuilder.Entity<Gruposprivadosporcarrera>(entity =>
            {
                entity.ToTable("gruposprivadosporcarrera");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carreraid).HasColumnName("carreraid");

                entity.Property(e => e.Gestiongruposid).HasColumnName("gestiongruposid");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Gruposprivadosporcarrera)
                    .HasForeignKey(d => d.Carreraid)
                    .HasConstraintName("carreraid");

                entity.HasOne(d => d.Gestiongrupos)
                    .WithMany(p => p.Gruposprivadosporcarrera)
                    .HasForeignKey(d => d.Gestiongruposid)
                    .HasConstraintName("gestiongruposid");
            });

            modelBuilder.Entity<Gruposprivadosporreto>(entity =>
            {
                entity.ToTable("gruposprivadosporreto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Grupoid).HasColumnName("grupoid");

                entity.Property(e => e.Retoid).HasColumnName("retoid");

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Gruposprivadosporreto)
                    .HasForeignKey(d => d.Grupoid)
                    .HasConstraintName("grupoid");

                entity.HasOne(d => d.Reto)
                    .WithMany(p => p.Gruposprivadosporreto)
                    .HasForeignKey(d => d.Retoid)
                    .HasConstraintName("retoid");
            });

            modelBuilder.Entity<InscripDepCarrera>(entity =>
            {
                entity.ToTable("inscripDepCarrera");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carreraid).HasColumnName("carreraid");

                entity.Property(e => e.Usurioid).HasColumnName("usurioid");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.InscripDepCarrera)
                    .HasForeignKey(d => d.Carreraid)
                    .HasConstraintName("carreraid");

                entity.HasOne(d => d.Usurio)
                    .WithMany(p => p.InscripDepCarrera)
                    .HasForeignKey(d => d.Usurioid)
                    .HasConstraintName("usuarioid");
            });

            modelBuilder.Entity<Inscripdepreto>(entity =>
            {
                entity.ToTable("inscripdepreto");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Retoid).HasColumnName("retoid");

                entity.Property(e => e.Usuarioid).HasColumnName("usuarioid");

                entity.HasOne(d => d.Reto)
                    .WithMany(p => p.Inscripdepreto)
                    .HasForeignKey(d => d.Retoid)
                    .HasConstraintName("retoid");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Inscripdepreto)
                    .HasForeignKey(d => d.Usuarioid)
                    .HasConstraintName("usuarioid");
            });

            modelBuilder.Entity<Patrocinadores>(entity =>
            {
                entity.ToTable("patrocinadores");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<Patrocinadoresporcarrera>(entity =>
            {
                entity.ToTable("patrocinadoresporcarrera");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Carreraid).HasColumnName("carreraid");

                entity.Property(e => e.Patrocinadorid).HasColumnName("patrocinadorid");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Patrocinadoresporcarrera)
                    .HasForeignKey(d => d.Carreraid)
                    .HasConstraintName("carreraid");

                entity.HasOne(d => d.Patrocinador)
                    .WithMany(p => p.Patrocinadoresporcarrera)
                    .HasForeignKey(d => d.Patrocinadorid)
                    .HasConstraintName("patrpcinadorid");
            });

            modelBuilder.Entity<Patrocinadoresporretos>(entity =>
            {
                entity.ToTable("patrocinadoresporretos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gestionretoid).HasColumnName("gestionretoid");

                entity.Property(e => e.Patrocinadorid).HasColumnName("patrocinadorid");

                entity.HasOne(d => d.Gestionreto)
                    .WithMany(p => p.Patrocinadoresporretos)
                    .HasForeignKey(d => d.Gestionretoid)
                    .HasConstraintName("gestionretoid");

                entity.HasOne(d => d.Patrocinador)
                    .WithMany(p => p.Patrocinadoresporretos)
                    .HasForeignKey(d => d.Patrocinadorid)
                    .HasConstraintName("patrocinadorid");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.ToTable("usuarios");

                entity.ForNpgsqlHasComment("Tabla que guardara todos los usuarios registrados en la aplicación web, ya sean de tipo deportista u organizador ");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioID");

                entity.Property(e => e.Apellido1).HasColumnName("apellido1");

                entity.Property(e => e.Apellido2).HasColumnName("apellido2");

                entity.Property(e => e.Contrasena).HasColumnName("contrasena");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdAt")
                    .HasColumnType("date");

                entity.Property(e => e.CuentaBancaria).HasColumnName("cuentaBancaria");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fechaNacimiento")
                    .HasColumnType("date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Foto).HasColumnName("foto");

                entity.Property(e => e.Nacionalidad).HasColumnName("nacionalidad");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Rol).HasColumnName("rol");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedAt")
                    .HasColumnType("date");

                entity.Property(e => e.Usuario).HasColumnName("usuario");
            });
        }
    }
}
