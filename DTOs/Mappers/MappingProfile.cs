using AutoMapper;
using WassamaraManagement.Domain;

namespace WassamaraManagement.DTOs.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<PersonDto, Person>()
            .ForMember(dest => dest.CPF, opt => opt.MapFrom(src => src.NaturalPerson.CPF))
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.NaturalPerson.BirthDate))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.NaturalPerson.FullName))
            .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.PersonJuridical.CNPJ))
            .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.PersonJuridical.CompanyName))
            .ForMember(dest => dest.TradingName, opt => opt.MapFrom(src => src.PersonJuridical.TradingName)).ReverseMap();
        } 

    }
}
