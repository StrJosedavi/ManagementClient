using WassamaraManagement.DTOs;

namespace WassamaraManagement.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDto> GetById(int id);
        Task<PersonDto> Create(PersonDto clienteDto);
        Task Update(int id, PersonDto clienteDto);
        Task Delete(int id);
    }
}
