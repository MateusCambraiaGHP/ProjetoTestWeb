using Microsoft.EntityFrameworkCore;
using ProjetoTest.Interfaces;
using ProjetoTest.Models;

namespace ProjetoTest.Data
{
    public class ApplicationMySqlDbContext : DbContext, IApplicationMySqlDbContext
    {
        public IConfiguration _configuration { get; set; }

        public ApplicationMySqlDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_configuration.GetConnectionString("DefaultConnection"),
                ServerVersion.AutoDetect(_configuration.GetConnectionString("DefaultConnection")));
        }

        public DbSet<Material> Material { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        public int Save()
        {
            return SaveChanges();
        }

    }
}
