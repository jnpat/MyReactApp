using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyReactApp.Server.Models;

public partial class ShopDbContext : DbContext
{
    public ShopDbContext()
    {
    }

    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Collection> Collections { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductTag> ProductTags { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\;Database=Shop_DB;Trusted_Connection=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brand__3213E83FE0090D00");

            entity.ToTable("Brand");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.UserIdentifier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_identifier");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3213E83FF0EBFC3C");

            entity.ToTable("Category");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Collection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Collecti__3213E83F09F3A0E5");

            entity.ToTable("Collection");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Image__3213E83F118A35B8");

            entity.ToTable("Image");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Alt)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("alt");
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Large)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("large");
            entity.Property(e => e.Medium)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("medium");
            entity.Property(e => e.MediumLarge)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("medium_large");
            entity.Property(e => e.MediumSmall)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("medium_small");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Original)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("original");
            entity.Property(e => e.Small)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("small");
            entity.Property(e => e.SmallThumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("small_thumbnail");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Price__3213E83F8DDA8B10");

            entity.ToTable("Price");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.DpAmount)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("dp_amount");
            entity.Property(e => e.DpCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("dp_currency");
            entity.Property(e => e.FpAmount)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("fp_amount");
            entity.Property(e => e.FpCurrency)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("fp_currency");
            entity.Property(e => e.OgAmount)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("og_amount");
            entity.Property(e => e.OgCurrency)
                .HasMaxLength(3)
                .HasColumnName("og_currency");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Prices)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Price__product_i__48CFD27E");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83FA4419F40");

            entity.ToTable("Product");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AllowMultipleConfig).HasColumnName("allow_multiple_config");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.Has3dAssets).HasColumnName("has_3d_assets");
            entity.Property(e => e.Layout)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("layout");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ReviewCount).HasColumnName("review_count");
            entity.Property(e => e.ReviewScore)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("review_score");
            entity.Property(e => e.Sold).HasColumnName("sold");
            entity.Property(e => e.ThumbnailImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail_image");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(255)
                .HasColumnName("url");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__brand_i__4F7CD00D");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductC__3213E83F968FB5B6");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCa__categ__4CA06362");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCa__produ__4BAC3F29");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductI__3213E83F5FEA12F2");

            entity.ToTable("ProductImage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Image).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ImageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIm__image__4AB81AF0");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIm__produ__49C3F6B7");
        });

        modelBuilder.Entity<ProductTag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductT__3213E83FA3EA209E");

            entity.ToTable("ProductTag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.TagId).HasColumnName("tag_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductTa__produ__4D94879B");

            entity.HasOne(d => d.Tag).WithMany(p => p.ProductTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductTa__tag_i__4E88ABD4");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tag__3213E83F75EE6606");

            entity.ToTable("Tag");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CollectionId).HasColumnName("collection_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.ParentName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("parent_name");
            entity.Property(e => e.ThumbnailImage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail_image");
            entity.Property(e => e.UserIdentifier)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("user_identifier");

            entity.HasOne(d => d.Collection).WithMany(p => p.Tags)
                .HasForeignKey(d => d.CollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tag__collection___5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
