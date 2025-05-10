using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Core.Entities;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cancha> Canchas { get; set; }

        public virtual DbSet<Reserva> Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=FAB-LAPTOP\\SQLEXPRESS;Database=ReservaCanchasDB;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cancha>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Canchas__3214EC07BC770AC5");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Reservas__3214EC07D0F5DD81");

                entity.Property(e => e.ClienteNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.HasOne(d => d.Cancha).WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.CanchaId)
                    .HasConstraintName("FK__Reservas__Cancha__398D8EEE");
            });
        }
    }
}
