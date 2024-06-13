using Microsoft.EntityFrameworkCore;
using WassamaraManagement.Data;
using WassamaraManagement.Domain;
using WassamaraManagement.Repository.Interfaces;

namespace WassamaraManagement.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task Add(Person person)
        {
            await _context.Persons.AddAsync(person);
        }

        public async Task Delete(int id)
        {
            await _context.Persons.ExecuteDeleteAsync<Person>();
        }

        public async Task<Person> GetById(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task Update(int id, Person person)
        {
            _context.Entry(id).CurrentValues.SetValues(person);
             await _context.SaveChangesAsync();
        }
    }
}
