using Portfolio.Application.Countries;
using Portfolio.Domain.Entities;

namespace Portfolio.Application.Common.Mappings
{
    public class CountryProfile : AutoMapper.Profile
    {
        public CountryProfile()
        {
            CreateMap<CreateCountryCommand, Country>()
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.CountryName))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
