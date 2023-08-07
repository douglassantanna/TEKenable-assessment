using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data;
public class NewsletterDataContext : DbContext
{
    public NewsletterDataContext(DbContextOptions<NewsletterDataContext> options)
    : base(options)
    {
    }
    public DbSet<Contact> Contacts { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Contact>()
            .Property(c => c.Email)
            .IsRequired();

        modelBuilder.Entity<Contact>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<Contact>()
            .Property(c => c.ReasonForSignUp)
            .HasMaxLength(255);
    }

}
