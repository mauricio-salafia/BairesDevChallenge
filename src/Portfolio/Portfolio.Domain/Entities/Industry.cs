using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Portfolio.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Industry
    {
        public long IndustryId { get; set; }
        public string IndustryName { get; set; }
        public bool Enable { get; set; } = true;
        public IList<Profile> Profiles { get; set; } = new List<Profile>();
    }
}
