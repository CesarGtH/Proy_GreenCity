using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Proy_GreenCity.DOMAIN.Core.Entities;

namespace Proy_GreenCity.DOMAIN.Infraestructure.Data;

public partial class GreenCityContext : DbContext
{
    public GreenCityContext()
    {
    }

    public GreenCityContext(DbContextOptions<GreenCityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comentarios> Comentarios { get; set; }

    public virtual DbSet<EstadoReportes> EstadoReportes { get; set; }

    public virtual DbSet<Notificaciones> Notificaciones { get; set; }

    public virtual DbSet<Reportes> Reportes { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=GreenCity;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comentarios>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Contenido)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("contenido");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ReporteId).HasColumnName("reporte_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<EstadoReportes>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Estado_Reportes");

            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ReporteId).HasColumnName("reporte_id");
        });

        modelBuilder.Entity<Notificaciones>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Mensaje)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mensaje");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<Reportes>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Categoria)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("categoria");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("titulo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ubicacion");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3213E83FF1AFC777");

            entity.HasIndex(e => e.Nombre, "UQ__Roles__72AFBCC6A6786270").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Contrasena)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("contrasena");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
