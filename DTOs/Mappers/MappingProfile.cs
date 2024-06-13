using AutoMapper;
using WassamaraManagement.Domain;

namespace WassamaraManagement.DTOs.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Person, PersonDto>().ReverseMap();
        } 

    }
}
