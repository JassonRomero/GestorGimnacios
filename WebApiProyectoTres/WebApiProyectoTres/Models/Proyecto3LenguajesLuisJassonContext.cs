using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiProyectoTres.Models
{
    public partial class Proyecto3LenguajesLuisJassonContext : DbContext
    {

        public Proyecto3LenguajesLuisJassonContext(DbContextOptions<Proyecto3LenguajesLuisJassonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Negocio> Negocio { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Negocio>(entity =>
            {
                entity.HasKey(e => e.IdNegocio)
                    .HasName("PK__negocio__01F7B74228215711");

                entity.ToTable("negocio");

                entity.HasIndex(e => e.NombreNegocio)
                    .HasName("UQ__negocio__01DE965EF8B620A8")
                    .IsUnique();

                entity.Property(e => e.IdNegocio).HasColumnName("id_negocio");

                entity.Property(e => e.CapacidadMaxima).HasColumnName("capacidad_maxima");

                entity.Property(e => e.Contrasena)
                    .IsRequired()
                    .HasColumnName("contrasena")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnName("correo")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioA).HasColumnName("horarioA");

                entity.Property(e => e.HorarioC).HasColumnName("horarioC");

                /*entity.Property(e => e.Imagen1)
                    .HasColumnName("imagen1")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen2)
                    .HasColumnName("imagen2")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen3)
                    .HasColumnName("imagen3")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen4)
                    .HasColumnName("imagen4")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen5)
                    .HasColumnName("imagen5")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasMaxLength(200)
                    .IsUnicode(false);*/

                entity.Property(e => e.NombreNegocio)
                    .IsRequired()
                    .HasColumnName("nombre_negocio")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PorcentajePermitido).HasColumnName("porcentaje_permitido");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasColumnName("ubicacion")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
