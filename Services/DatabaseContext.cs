using Microsoft.EntityFrameworkCore;
using PantaNet.Api.Models;

namespace PantaNet.Api.Services
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .ToContainer("Produtos");
        }
    }
}