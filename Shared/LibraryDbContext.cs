using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Shared;

public sealed class LibraryDbContext : DbContext
{
    public LibraryDbContext() : base()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Genre entity
        modelBuilder.Entity<Genre>()
            .HasKey(g => g.Id);
        modelBuilder.Entity<Genre>()
            .Property(g => g.Name)
            .IsRequired();
        modelBuilder.Entity<Genre>()
            .HasIndex(g => g.Name)
            .IsUnique();
        
        // Location entity
        modelBuilder.Entity<Location>()
            .HasKey(l => l.Id);
        modelBuilder.Entity<Location>()
            .Property(l => l.Country)
            .IsRequired();
        modelBuilder.Entity<Location>()
            .Property(l => l.City)
            .IsRequired();
        modelBuilder.Entity<Location>()
            .HasAlternateKey(l => new { l.Country, l.City });
        
        // Author entity
        modelBuilder.Entity<Author>()
            .HasKey(a => a.Id);
        modelBuilder.Entity<Author>()
            .HasOne(a => a.BirthLocation)
            .WithMany(l => l.BornAuthors)
            .HasForeignKey(a => a.BirthLocationId);
        modelBuilder.Entity<Author>()
            .HasOne(a => a.LiveLocation)
            .WithMany(l => l.LivingAuthors)
            .HasForeignKey(a => a.LiveLocationId);
        
        // Book entity
        modelBuilder.Entity<Book>()
            .HasKey(b => b.Id);
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books);
        modelBuilder.Entity<Book>()
            .HasMany(b => b.Genres)
            .WithMany(g => g.Books);

    }
}