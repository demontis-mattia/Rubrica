using Microsoft.EntityFrameworkCore;

namespace Rubrica.Models
{
    public class RubricaDbContext : DbContext
    {
        public RubricaDbContext(DbContextOptions<RubricaDbContext> options) : base(options)
        {
        }

        public DbSet<Contatto> Contatti { get; set; }
        public DbSet<Città> Città { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
