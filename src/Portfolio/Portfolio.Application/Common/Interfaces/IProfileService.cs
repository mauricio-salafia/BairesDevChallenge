using System.Threading.Tasks;
using Portfolio.Domain.Entities;
using Portfolio.Application.Common.Models;
using System.Collections.Generic;

namespace Portfolio.Application.Common.Interfaces
{
    public interface IProfileService
    {
        Task<(Result, int)> AddSingleProfile(Profile profile);
        Task<Result> AddProfiles(List<Profile> profiles);
    }
}
