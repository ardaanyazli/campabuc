using CamPabuc.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace CamPabuc.Infrastructure.Persistence;

public class CamPabucContext : DbContext
{
    public CamPabucContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<ContactInfo> ContactInfos => Set<ContactInfo>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shoe>(s =>
        {
            s.HasKey(s => s.Id);
            s.Property(s => s.Gender)
                .HasConversion<int>();
            s.HasOne<ShoeCategory>()
                .WithMany(c => c.Shoes)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);
            s.HasOne<Manufacturer>()
                .WithMany(m => m.Shoes)
                .HasForeignKey(s => s.ManufacturerId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Manufacturer>(m =>
        {
            m.HasKey(m => m.Id);
            m.HasMany(s => s.Shoes);
        });

        modelBuilder.Entity<ShoeCategory>(c =>
        {
            c.HasKey(c => c.Id);
            c.HasMany(s => s.Shoes);
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
