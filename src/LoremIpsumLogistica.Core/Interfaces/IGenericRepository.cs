using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LoremIpsumLogistica.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task LogicalDeletion(T entity);
        DbSet<T> DbSet();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
