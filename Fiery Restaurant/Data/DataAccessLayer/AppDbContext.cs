using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=User;Integrated Security=True;Pooling=False");
		}

		public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50);
            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(200);
        }
    }
}