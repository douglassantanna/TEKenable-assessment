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
}
