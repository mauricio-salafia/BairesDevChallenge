using AutoMapper;
using MediatR;
using Portfolio.Application.Common.Interfaces;
using Portfolio.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Portfolio.Application.Countries
{
    public class CreateCountryCommand : IRequest<long>
    {
        public long CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, long>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = _mapper.Map<Country>(request);
            _context.Countries.Add(country);
            await _context.SaveChangesAsync(cancellationToken);
            return country.CountryId;
        }
    }
}
