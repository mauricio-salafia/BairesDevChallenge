using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Portfolio.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Country
    {
        public long CountryId { get; set; }
        public string CountryName { get; set; }
        public bool Enable { get; set; } = true;
        public IList<Profile> Profiles { get; set; } = new List<Profile>();
    }
}
