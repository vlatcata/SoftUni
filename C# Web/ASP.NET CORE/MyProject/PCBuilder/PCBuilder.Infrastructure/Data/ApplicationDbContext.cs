using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Infrastructure.Data.Identity;

namespace PCBuilder.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Computer> Computers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Component> Components { get; set; }

        public DbSet<Specification> Specifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}