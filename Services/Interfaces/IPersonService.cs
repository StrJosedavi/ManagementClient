using WassamaraManagement.Domain;
using WassamaraManagement.DTOs;

namespace WassamaraManagement.Services.Interfaces
{
    public interface IPersonService
    {
        Task<PersonDto> GetById(long id);
        Task<List<Person>> GetAll(string? cpf, string? cnpj);
        Task<PersonDto> Create(PersonDto personDto);
        Task Update(long id, PersonDto personDto);
        Task Delete(long id);
    }
}
