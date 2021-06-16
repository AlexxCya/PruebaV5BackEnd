using Microsoft.EntityFrameworkCore;
using System.Reflection;
using PruebaV5.Core.Entities;

namespace PruebaV5.Infrastructure.Data
{
    public partial class PruebaV5BDContext : DbContext
    {
        public PruebaV5BDContext()
        {
        }

        public PruebaV5BDContext(DbContextOptions<PruebaV5BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<Security> Security { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
