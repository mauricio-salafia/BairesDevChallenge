using System.Diagnostics.CodeAnalysis;

namespace Portfolio.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Profile : Person
    {
        public long ProfileId { get; set; }
        public string CurrentRole { get; set; }
        public int? NumberOfRecommendations { get; set; }
        public int? NumberOfConnections { get; set; }
        public Country Country { get; set; }
        public long CountryId { get; set; }
        public Industry Industry { get; set; }
        public long IndustryId { get; set; }
    }
}
