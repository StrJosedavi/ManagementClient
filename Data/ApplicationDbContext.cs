using Microsoft.EntityFrameworkCore;
using WassamaraManagement.Domain;
using WassamaraManagement.Domain.Enums;

namespace WassamaraManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<UserAdmin> UsersAdmin { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<UserAdmin>().ToTable("UserAdmin");
        }
    }

}
