using CamPabuc.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Persistence;

public class CamPabucContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<ShoeCategory> ShoeCategories { get; set; }
    public DbSet<ShoeModel> ShoeModels { get; set; }
    public DbSet<ShoeVariant> ShoeVariants { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<POItem> POItems { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<SaleItem> SaleItems { get; set; }
    public DbSet<StockAdjustment> StockAdjustments { get; set; }
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<ContactInfo> ContactInfos => Set<ContactInfo>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>(m =>
        {
            m.HasKey(m => m.Id);
            m.HasMany(m => m.ShoeModels)
                .WithOne(s => s.Manufacturer)
                .HasForeignKey(s => s.ManufacturerId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ShoeCategory>(m =>
        {
            m.HasKey(m => m.Id);
            m.HasMany(m => m.ShoeModels)
                .WithOne(s => s.ShoeCategory)
                .HasForeignKey(s => s.ShoeCategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ShoeModel>(s =>
        {
            s.HasKey(s => s.Id);
            s.HasMany(s => s.Variants)
                .WithOne(v => v.ShoeModel)
                .HasForeignKey(v => v.ShoeModelId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ShoeVariant>(v =>
        {
            v.HasKey(v => v.Id);
        });

        modelBuilder.Entity<PurchaseOrder>(po =>
        {
            po.HasKey(po => po.Id);
            po.HasMany(po => po.Items)
                .WithOne(i => i.PurchaseOrder)
                .HasForeignKey(i => i.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<POItem>(i =>
        {
            i.HasKey(i => i.Id);
            i.HasOne(i => i.ShoeVariant)
                .WithMany()
                .HasForeignKey(i => i.ShoeVariantId);
        });

        modelBuilder.Entity<Sale>(s =>
        {
            s.HasKey(s => s.Id);
            s.HasMany(s => s.Items)
                .WithOne(i => i.Sale)
                .HasForeignKey(i => i.SaleId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SaleItem>(i =>
        {
            i.HasKey(i => i.Id);
            i.HasOne(i => i.ShoeVariant)
                .WithMany()
                .HasForeignKey(i => i.ShoeVariantId);
        });

        modelBuilder.Entity<StockAdjustment>(sa =>
        {
            sa.HasKey(sa => sa.Id);
            sa.HasOne(sa => sa.ShoeVariant)
                .WithMany()
                .HasForeignKey(sa => sa.ShoeVariantId);
        });

        modelBuilder.Entity<Contact>(c =>
        {
            c.HasKey(c => c.Id);
            c.HasMany(c => c.ContactInfos)
            .WithOne(ci => ci.Contact)
            .HasForeignKey(ci => ci.ContactId)
            .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ContactInfo>(ci =>
        {
            ci.HasKey(ci => ci.Id);
            ci.Property(ci => ci.InfoType)
            .HasConversion<int>();
            ci.HasIndex(ci => ci.ContactId)
            .HasDatabaseName("IX_ContactInfo_ContactId");
        });

        base.OnModelCreating(modelBuilder);

        // Seed data
        modelBuilder.Entity<Manufacturer>().HasData(
            new Manufacturer { Id = 1, Name = "Nike", Phone = "555-0100", Address = "1 Bowerman Dr, Beaverton, OR", CreatedAt = DateOnly.FromDateTime(DateTime.Now), UpdatedAt = DateOnly.FromDateTime(DateTime.Now), IsActive = true },
            new Manufacturer { Id = 2, Name = "Adidas", Phone = "555-0200", Address = "Adi-Dassler-Straße 1, Herzogenaurach", CreatedAt = DateOnly.FromDateTime(DateTime.Now), UpdatedAt = DateOnly.FromDateTime(DateTime.Now), IsActive = true },
            new Manufacturer { Id = 3, Name = "Puma", Phone = "555-0300", Address = "Puma Way 1, Herzogenaurach", CreatedAt = DateOnly.FromDateTime(DateTime.Now), UpdatedAt = DateOnly.FromDateTime(DateTime.Now), IsActive = true }
        );

        modelBuilder.Entity<ShoeCategory>().HasData(
            new ShoeCategory { Id = 1, Name = "Running", CreatedAt = DateOnly.FromDateTime(DateTime.Now), UpdatedAt = DateOnly.FromDateTime(DateTime.Now), IsActive = true },
            new ShoeCategory { Id = 2, Name = "Casual", CreatedAt = DateOnly.FromDateTime(DateTime.Now), UpdatedAt = DateOnly.FromDateTime(DateTime.Now), IsActive = true },
            new ShoeCategory { Id = 3, Name = "Formal", CreatedAt = DateOnly.FromDateTime(DateTime.Now), UpdatedAt = DateOnly.FromDateTime(DateTime.Now), IsActive = true }
        );
    }

}
