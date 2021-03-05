using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.Extensions.Configuration;

namespace TodoAPI.Models
{
    public partial class duoContext : DbContext
    {
        public duoContext()
        {
        }

        public duoContext(DbContextOptions<duoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anuncio> Anuncio { get; set; }
        public virtual DbSet<AnuncioImages> AnuncioImages { get; set; }
        public virtual DbSet<AnuncioTnq> AnuncioTnq { get; set; }
        public virtual DbSet<PerfilDuo> PerfilDuo { get; set; }
        public virtual DbSet<PerfilDuoTnq> PerfilDuoTnq { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsTnq> ProductsTnq { get; set; }
        public virtual DbSet<Registrado> Registrado { get; set; }
        public virtual DbSet<RegistradoTnq> RegistradoTnq { get; set; }
        public virtual DbSet<SessionDuo> SessionDuo { get; set; }
        public virtual DbSet<SessionDuotnq> SessionDuotnq { get; set; }
        public virtual DbSet<Works> Works { get; set; }
        public virtual DbSet<WorksTnq> WorksTnq { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("database"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.HasKey(e => e.RegAnuncioId);

                entity.Property(e => e.RegAnuncioAcercaDe)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RegAnuncioEstado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegAnuncioFecha).HasColumnType("datetime");

                entity.Property(e => e.RegAnuncioPalabraClave)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegRutaImagen1).IsUnicode(false);

                entity.Property(e => e.RegRutaImagen2).IsUnicode(false);

                entity.Property(e => e.RegRutaImagen3).IsUnicode(false);
                entity.Property(e => e.Titulo).IsUnicode(false);

            });

            modelBuilder.Entity<AnuncioImages>(entity =>
            {
                entity.HasKey(e => e.RegAnuncioImagenId);
                entity.Property(e => e.RegAnuncioId);
                entity.Property(e => e.RegId);

                entity.Property(e => e.RegRutaImagen).IsUnicode(false);
                
                entity.Property(e => e.RegAnuncioEstado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegAnuncioFecha).HasColumnType("datetime");

            });

            modelBuilder.Entity<AnuncioTnq>(entity =>
            {
                entity.HasKey(e => e.RegAnuncioIdTnq);

                entity.Property(e => e.RegAnuncioId);

                entity.ToTable("AnuncioTNQ");

                entity.Property(e => e.RegAnuncioAcercaDe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegAnuncioEstado)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegAnuncioFecha).HasColumnType("datetime");

                entity.Property(e => e.RegAnuncioPalabraClave)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

               

            });

            modelBuilder.Entity<PerfilDuo>(entity =>
            {
                entity.HasKey(e => e.RegPerfilId);

                entity.Property(e => e.RegAcercaDe).IsUnicode(false);

                entity.Property(e => e.RegApellidos).IsUnicode(false);

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegEmail).IsUnicode(false);

                entity.Property(e => e.RegFecha).HasColumnType("datetime");

                entity.Property(e => e.RegNombres).IsUnicode(false);

                entity.Property(e => e.RegNombresCompletos).IsUnicode(false);

                entity.Property(e => e.RegNumeroCelular).IsUnicode(false);

                entity.Property(e => e.RegProfesion).IsUnicode(false);

                entity.Property(e => e.RegRutaImagen).IsUnicode(false);

                entity.Property(e => e.RegStreamImagen).HasColumnType("image");
            });

            modelBuilder.Entity<PerfilDuoTnq>(entity =>
            {
                entity.HasKey(e => e.RegPerfilIdTnq);

                entity.ToTable("PerfilDuoTNQ");

                entity.Property(e => e.RegPerfilIdTnq).HasColumnName("RegPerfilIdTNQ");

                entity.Property(e => e.RegAcercaDe).IsUnicode(false);

                entity.Property(e => e.RegApellidos).IsUnicode(false);

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegEmail).IsUnicode(false);

                entity.Property(e => e.RegFecha).HasColumnType("datetime");

                entity.Property(e => e.RegNombres).IsUnicode(false);

                entity.Property(e => e.RegNombresCompletos).IsUnicode(false);

                entity.Property(e => e.RegNumeroCelular).IsUnicode(false);

                entity.Property(e => e.RegProfesion).IsUnicode(false);

                entity.Property(e => e.RegRutaImagen).IsUnicode(false);

                entity.Property(e => e.RegStreamImagen).HasColumnType("image");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.RegProductId);

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegDescripcionProducto).IsUnicode(false);

                entity.Property(e => e.RegFecha).HasColumnType("datetime");

                entity.Property(e => e.RegPreciProducto).IsUnicode(false);

                entity.Property(e => e.RegRutaImagen).IsUnicode(false);

                entity.Property(e => e.RegStreamImagen).HasColumnType("image");

                entity.Property(e => e.RegTituloProducto).IsUnicode(false);

                entity.Property(e => e.IsNew);
            });

            modelBuilder.Entity<ProductsTnq>(entity =>
            {
                entity.HasKey(e => e.RegProductIdTnq);

                entity.ToTable("ProductsTNQ");

                entity.Property(e => e.RegProductIdTnq).HasColumnName("RegProductIdTNQ");

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegDescripcionProducto).IsUnicode(false);

                entity.Property(e => e.RegFecha).HasColumnType("datetime");

                entity.Property(e => e.RegPreciProducto).IsUnicode(false);

                entity.Property(e => e.RegRutaImagen).IsUnicode(false);

                entity.Property(e => e.RegStreamImagen).HasColumnType("image");

                entity.Property(e => e.RegTituloProducto).IsUnicode(false);

                entity.Property(e => e.IsDel);
            });

            modelBuilder.Entity<Registrado>(entity =>
            {
                entity.HasKey(e => e.RegId);

                entity.Property(e => e.RegApellidos).IsUnicode(false);

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegContrasenia).IsUnicode(false);

                entity.Property(e => e.RegEmail).IsUnicode(false);

                entity.Property(e => e.RegFecha).HasColumnType("datetime");

                entity.Property(e => e.RegNombreCompleto).IsUnicode(false);

                entity.Property(e => e.RegNombres).IsUnicode(false);

                entity.Property(e => e.RegNumeroCelular).IsUnicode(false);
            });

            modelBuilder.Entity<RegistradoTnq>(entity =>
            {
                entity.HasKey(e => e.RegIdTnq);

                entity.ToTable("RegistradoTNQ");

                entity.Property(e => e.RegIdTnq).HasColumnName("RegIdTNQ");

                entity.Property(e => e.RegApellidos).IsUnicode(false);

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegContrasenia).IsUnicode(false);

                entity.Property(e => e.RegEmail).IsUnicode(false);

                entity.Property(e => e.RegFecha).HasColumnType("datetime");

                entity.Property(e => e.RegNombreCompleto).IsUnicode(false);

                entity.Property(e => e.RegNombres).IsUnicode(false);

                entity.Property(e => e.RegNumeroCelular).IsUnicode(false);
            });

            modelBuilder.Entity<SessionDuo>(entity =>
            {
                entity.HasKey(e => e.IdSessionDuo);

                entity.ToTable("SessionDUO");

                entity.Property(e => e.IdSessionDuo).HasColumnName("IdSessionDUO");

                entity.Property(e => e.FechaLog).HasColumnType("datetime");

                entity.Property(e => e.UsuarioDuo)
                    .HasColumnName("UsuarioDUO")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SessionDuotnq>(entity =>
            {
                entity.HasKey(e => e.IdSessionDuotnq);

                entity.ToTable("SessionDUOTNQ");

                entity.Property(e => e.IdSessionDuotnq).HasColumnName("IdSessionDUOTNQ");

                entity.Property(e => e.FechaLog).HasColumnType("datetime");

                entity.Property(e => e.IdSessionDuo).HasColumnName("IdSessionDUO");

                entity.Property(e => e.UsuarioDuo)
                    .HasColumnName("UsuarioDUO")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Works>(entity =>
            {
                entity.HasKey(e => e.RegWorksId);

                entity.ToTable("works");

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegDescripcion).IsUnicode(false);

                entity.Property(e => e.RegFecha).HasColumnType("datetime");

                entity.Property(e => e.RegRutaImagen).IsUnicode(false);

                entity.Property(e => e.RegStreamImagen).HasColumnType("image");

                entity.Property(e => e.IsNew);
            });

            modelBuilder.Entity<WorksTnq>(entity =>
            {
                entity.HasKey(e => e.RegWorksIdTnq);

                entity.ToTable("worksTNQ");

                entity.Property(e => e.RegWorksIdTnq).HasColumnName("RegWorksIdTNQ");

                entity.Property(e => e.RegCodigoUnico).IsUnicode(false);

                entity.Property(e => e.RegDescripcion).IsUnicode(false);

                entity.Property(e => e.RegFecha).HasColumnType("datetime");

                entity.Property(e => e.RegRutaImagen).IsUnicode(false);

                entity.Property(e => e.RegStreamImagen).HasColumnType("image");

                entity.Property(e => e.IsDel);
            });
        }
    }
}
