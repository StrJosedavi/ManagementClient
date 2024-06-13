using WassamaraManagement.Domain;

namespace WassamaraManagement.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetById(int id);
        Task Add(Person person);
        Task Update(int id, Person person);
        Task Delete(int id);
    }
}
