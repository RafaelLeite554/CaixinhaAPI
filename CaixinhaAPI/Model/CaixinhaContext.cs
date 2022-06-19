using Microsoft.EntityFrameworkCore;

namespace CaixinhaAPI.Model
{
    public class CaixinhaContext : DbContext
    {
        public CaixinhaContext(DbContextOptions<CaixinhaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Ideia> Ideias { get; set; }
    }
}
