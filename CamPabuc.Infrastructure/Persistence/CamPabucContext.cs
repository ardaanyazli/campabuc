using CamPabuc.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Persistence;

public class CamPabucContext : DbContext
{
    public CamPabucContext(DbContextOptions options) : base(options)
    {

    }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<ShoeCategory> ShoeCategories { get; set; }
    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<ContactInfo> ContactInfos => Set<ContactInfo>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>(m =>
        {
            m.HasKey(m => m.Id);
            m.HasMany(m => m.Shoes)
                .WithOne(s => s.Manufacturer)
                .HasForeignKey(s => s.ManufacturerId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ShoeCategory>(m =>
        {
            m.HasKey(m => m.Id);
            m.HasMany(m => m.Shoes)
                .WithOne(s => s.ShoeCategory)
                .HasForeignKey(s => s.ShoeCategoryId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Shoe>(s =>
                {
                    s.HasKey(s => s.Id);
                    s.Property(s => s.Gender)
                   .HasConversion<byte>();
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
    }

}
