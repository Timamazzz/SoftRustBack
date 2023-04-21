using Microsoft.EntityFrameworkCore;

namespace SoftRustBack.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;

        protected override void
        OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasQueryFilter(p => !p.SoftDeleted);
        }
    }
}