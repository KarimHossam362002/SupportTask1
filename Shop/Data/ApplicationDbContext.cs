using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Blog> blogs { get; set; }

        /* if i want edit or create by custom*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*add before run while creating database , initially added to database*/
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Nike" },
                new Company { Id = 2, Name = "Adidas" }
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Romantic" },
                new Category { Id = 2, Name = "Action" }
                );
            /*   modelBuilder.Entity<Product>()
               .HasOne(p => p.company)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CompanyId);
           }*/
        }
    }
}

