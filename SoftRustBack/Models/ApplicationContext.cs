using Microsoft.EntityFrameworkCore;

namespace SoftRustBack.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Topic> Topics { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=SoftRustDatabase;Username=postgres;Password=310913_zZz");
        }
    }
}