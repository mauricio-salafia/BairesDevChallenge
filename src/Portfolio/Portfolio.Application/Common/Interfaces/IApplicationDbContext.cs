using Microsoft.EntityFrameworkCore;
using Portfolio.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Common.Interfaces
{
    /// <summary>
    /// Database context
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<Country> Countries { get; set; }
        DbSet<Industry> Industries { get; set; }
        DbSet<Profile> Profiles { get; set; }
        Task<long> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
