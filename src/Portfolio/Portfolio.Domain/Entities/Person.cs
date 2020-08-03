using System.Diagnostics.CodeAnalysis;

namespace Portfolio.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
