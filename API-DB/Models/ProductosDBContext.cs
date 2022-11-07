using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_DB.Models
{
    public partial class ProductosDBContext : DbContext
    {
        public ProductosDBContext()
        {
        }

        public ProductosDBContext(DbContextOptions<ProductosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductosDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.CatDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Cat_Desc");

                entity.Property(e => e.CatNom)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Cat_Nom");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.ToTable("Producto");

                entity.Property(e => e.ProdId).HasColumnName("Prod_Id");

                entity.Property(e => e.CatFk).HasColumnName("Cat_Fk");

                entity.Property(e => e.ProdDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Prod_Desc");

                entity.Property(e => e.ProdNom)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Prod_Nom");

               /* entity.HasOne(d => d.CatFkNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CatFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Producto_Categoria");*/
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
