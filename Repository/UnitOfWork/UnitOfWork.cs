using WassamaraManagement.Data;
using WassamaraManagement.Repository.Interfaces;

namespace WassamaraManagement.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private PersonRepository _personRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IPersonRepository Persons
        {
            get { return _personRepository ??= new PersonRepository(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
