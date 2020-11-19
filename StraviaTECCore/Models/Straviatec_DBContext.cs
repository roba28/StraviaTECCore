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
        public virtual DbSet<Amigos> Amigos { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Contactenos> Contactenos { get; set; }
        public virtual DbSet<Gestionactividad> Gestionactividad { get; set; }
        public virtual DbSet<GestionCarreras> GestionCarreras { get; set; }
        public virtual DbSet<GestionGrupos> GestionGrupos { get; set; }
        public virtual DbSet<Gestionretos> Gestionretos { get; set; }
        public virtual DbSet<Patrocinadores> Patrocinadores { get; set; }
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

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Finrecorrido)
                    .HasColumnName("finrecorrido")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Hora)
                    .HasColumnName("hora")
                    .HasColumnType("time without time zone[]");

                entity.Property(e => e.InicioRecorrido)
                    .HasColumnName("inicioRecorrido")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Tiempo)
                    .HasColumnName("tiempo")
                    .HasColumnType("time without time zone[]");

                entity.Property(e => e.UsuarioId).HasColumnName("usuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("usuarioID");
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
                entity.HasKey(e => e.GestionId);

                entity.ToTable("gestionactividad");

                entity.Property(e => e.GestionId).HasColumnName("gestionID");

                entity.Property(e => e.Clasificacion).HasColumnName("clasificacion");

                entity.Property(e => e.Tipo).HasColumnName("tipo");

                entity.HasOne(d => d.Gestion)
                    .WithOne(p => p.Gestionactividad)
                    .HasForeignKey<Gestionactividad>(d => d.GestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CarreraID");
            });

            modelBuilder.Entity<GestionCarreras>(entity =>
            {
                entity.HasKey(e => e.CarreraId);

                entity.ToTable("gestionCarreras");

                entity.Property(e => e.CarreraId).HasColumnName("carreraID");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");

                entity.Property(e => e.Costo).HasColumnName("costo");

                entity.Property(e => e.FechaCarrera)
                    .HasColumnName("fechaCarrera")
                    .HasColumnType("date");

                entity.Property(e => e.FinRecorrido)
                    .HasColumnName("finRecorrido")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.InicioRecorrido)
                    .HasColumnName("inicioRecorrido")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.OrganizadorId).HasColumnName("organizadorID");

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
                entity.HasKey(e => e.RetoId);

                entity.ToTable("gestionretos");

                entity.Property(e => e.RetoId).HasColumnName("retoID");

                entity.Property(e => e.CategoriaId).HasColumnName("categoriaID");

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

            modelBuilder.Entity<Patrocinadores>(entity =>
            {
                entity.ToTable("patrocinadores");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CarreraId).HasColumnName("carreraID");

                entity.HasOne(d => d.Carrera)
                    .WithMany(p => p.Patrocinadores)
                    .HasForeignKey(d => d.CarreraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carreraID");
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
