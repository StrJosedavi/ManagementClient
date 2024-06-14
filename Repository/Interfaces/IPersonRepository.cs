using WassamaraManagement.Domain;

namespace WassamaraManagement.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetById(long id);
        Task<List<Person>> GetAll(string? cpf, string? cnpj);
        Task Add(Person person);
        Task Update(Person personExist, Person person);
        Task Delete(Person person);
    }
}
