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

        public async Task Delete(Person person)
        {
            _context.Persons.Remove(person);
        }

        public async Task<List<Person>> GetAll(string? cpf, string? cnpj)
        {
            var query = _context.Persons.AsQueryable();

            if (!string.IsNullOrEmpty(cpf))
            {
                query = query.Where(p => p.CPF == cpf);
            }
            if (!string.IsNullOrEmpty(cnpj))
            {
                query = query.Where(p => p.CNPJ == cnpj);
            }

            query = query.OrderBy(p => p.Id);

            var persons = await query.ToListAsync();

            return persons;
        }

        public async Task<Person> GetById(long id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task Update(Person personExist, Person person)
        {
            _context.Entry(personExist).CurrentValues.SetValues(person);
        }
    }
}
