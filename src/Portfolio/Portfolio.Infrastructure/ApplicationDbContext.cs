using Microsoft.EntityFrameworkCore;
using Portfolio.Application.Common.Interfaces;
using Portfolio.Domain.Entities;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public async Task<long> SaveChangesAsync(CancellationToken cancellationToken)
        {
            long result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }
    }
}
