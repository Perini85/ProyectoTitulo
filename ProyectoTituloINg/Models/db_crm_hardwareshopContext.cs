using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoTituloINg.Models
{
    public partial class db_crm_hardwareshopContext : DbContext
    {
        public db_crm_hardwareshopContext()
        {
        }

        public db_crm_hardwareshopContext(DbContextOptions<db_crm_hardwareshopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Comuna> Comuna { get; set; }
        public virtual DbSet<Documento> Documento { get; set; }
        public virtual DbSet<TipoClientes> TipoClientes { get; set; }
        public virtual DbSet<TipoDocumentos> TipoDocumentos { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-52314DBS\\SQLEXPRESS;Database=db_crm_hardware-shop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__clientes__677F38F55F1174C5");

                entity.ToTable("clientes", "db_crm_hardware_shop");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.ApellidosCliente)
                    .HasColumnName("apellidos_cliente")
                    .HasMaxLength(100);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(25);

                entity.Property(e => e.DireccionCliente)
                    .HasColumnName("direccion_cliente")
                    .HasMaxLength(100);

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.IdComuna).HasColumnName("id_comuna");

                entity.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");

                entity.Property(e => e.NombreCliente)
                    .HasColumnName("nombre_cliente")
                    .HasMaxLength(100);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasMaxLength(11);

                entity.Property(e => e.RutCliente)
                    .HasColumnName("rut_cliente")
                    .HasMaxLength(11);

                entity.HasOne(d => d.IdComunaNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdComuna)
                    .HasConstraintName("FK__clientes__id_com__151B244E");

                entity.HasOne(d => d.IdTipoClienteNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdTipoCliente)
                    .HasConstraintName("FK__clientes__id_tip__7B5B524B");
            });

            modelBuilder.Entity<Comuna>(entity =>
            {
                entity.HasKey(e => e.IdComuna)
                    .HasName("PK__comuna__B9653FA04AE605FA");

                entity.ToTable("comuna", "db_crm_hardware_shop");

                entity.Property(e => e.IdComuna).HasColumnName("id_comuna");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.IdDocumento)
                    .HasName("PK__document__5D2EE7E5BA87A3BD");

                entity.ToTable("documento", "db_crm_hardware_shop");

                entity.Property(e => e.IdDocumento).HasColumnName("id_documento");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdProducto).HasColumnName("id_producto");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__documento__id_cl__0C85DE4D");

                entity.HasOne(d => d.IdTipoDocumentoNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdTipoDocumento)
                    .HasConstraintName("FK__documento__id_ti__0B91BA14");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Documento)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__documento__id_us__0D7A0286");
            });

            modelBuilder.Entity<TipoClientes>(entity =>
            {
                entity.HasKey(e => e.IdTipoCliente)
                    .HasName("PK__tipo_cli__69D671C5DCA5DF99");

                entity.ToTable("tipo_clientes", "db_crm_hardware_shop");

                entity.Property(e => e.IdTipoCliente).HasColumnName("id_tipo_cliente");

                entity.Property(e => e.NombreTipoCliente)
                    .HasColumnName("nombre_tipo_cliente")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TipoDocumentos>(entity =>
            {
                entity.HasKey(e => e.IdTipoDocumento)
                    .HasName("PK__tipo_doc__9F38507C17AC9185");

                entity.ToTable("tipo_documentos", "db_crm_hardware_shop");

                entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK_tipos_usuarios_id_tipo_usuario");

                entity.ToTable("tipos_usuarios", "db_crm_hardware_shop");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.NombreTipoUsuario)
                    .HasColumnName("nombre_tipo_usuario")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuarios__4E3E04AD98DABC33");

                entity.ToTable("usuarios", "db_crm_hardware_shop");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.Property(e => e.ApellidosUsuario)
                    .HasColumnName("apellidos_usuario")
                    .HasMaxLength(100);

                entity.Property(e => e.Correo)
                    .HasColumnName("correo")
                    .HasMaxLength(25);

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("fecha_nacimiento")
                    .HasColumnType("date");

                entity.Property(e => e.Habilitado).HasColumnName("habilitado");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("id_tipo_usuario");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.NombreUsuario)
                    .HasColumnName("nombre_usuario")
                    .HasMaxLength(100);

                entity.Property(e => e.NombresUsuario)
                    .HasColumnName("nombres_usuario")
                    .HasMaxLength(50);

                entity.Property(e => e.Pass)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.RutUsuario)
                    .HasColumnName("rut_usuario")
                    .HasMaxLength(10);

                entity.Property(e => e.Telefono)
                    .HasColumnName("telefono")
                    .HasMaxLength(9);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuarios__id_tip__02084FDA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
