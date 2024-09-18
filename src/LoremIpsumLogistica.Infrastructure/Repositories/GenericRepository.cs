using LoremIpsumLogistica.Core.Entities;
using LoremIpsumLogistica.Core.Interfaces;
using LoremIpsumLogistica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LoremIpsumLogistica.Infrastructure.Repositories
{
    // Implementação genérica do repositório para operações CRUD em entidades.
    public class GenericRepository<T>(LoremIpsumLogisticaDbContext context) : IGenericRepository<T> where T : BaseEntity
    {
        // Contexto do banco de dados.
        protected readonly LoremIpsumLogisticaDbContext _context = context;

        // Conjunto de entidades genéricas.
        internal DbSet<T> _dbSet = context.Set<T>();

        // Obtém todas as entidades do tipo T.
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.Where(x => x.Active)
                               .ToListAsync();
        }

        // Obtém uma entidade do tipo T por ID.
        public virtual async Task<T> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        // Cria uma nova entidade do tipo T.
        public virtual async Task<T> Create(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            await _dbSet.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        // Atualiza uma entidade do tipo T.
        public virtual async Task Update(T entity)
        {
            entity.ModifiedAt = DateTime.UtcNow;

            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        // Remove uma entidade do tipo T.
        public virtual async Task Delete(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            _context.Entry(entity).State = EntityState.Deleted;

            _dbSet.Remove(entity);

            await _context.SaveChangesAsync();
        }

        // Retorna o conjunto de entidades do tipo T.
        public virtual DbSet<T> DbSet()
        {
            return _dbSet;
        }

        /// <summary>
        /// Inicia uma transação assíncrona.
        /// </summary>
        /// <returns>Um objeto `IDbContextTransaction` para gerenciar a transação.</returns>
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            // Inicia uma transação e retorna o objeto de transação
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
