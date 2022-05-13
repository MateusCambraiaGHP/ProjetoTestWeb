using Microsoft.EntityFrameworkCore;
using ProjetoTest.Models;

namespace ProjetoTest.Interfaces
{
    public interface IApplicationMySqlDbContext
    {
        public DbSet<Material> Material { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public int Save();
    }
}
