using WassamaraManagement.Repository.Interfaces;

namespace WassamaraManagement.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }
        Task<int> SaveChangesAsync();
    }
}
