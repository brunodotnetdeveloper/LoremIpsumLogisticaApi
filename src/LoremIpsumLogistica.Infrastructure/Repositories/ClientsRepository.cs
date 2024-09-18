using LoremIpsumLogistica.Core.Entities;
using LoremIpsumLogistica.Core.Interfaces;
using LoremIpsumLogistica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LoremIpsumLogistica.Infrastructure.Repositories
{
    public class ClientsRepository(LoremIpsumLogisticaDbContext context) : GenericRepository<Client>(context), IClientsRepository
    {
        public override async Task<Client> GetById(int id)
        {
            return await _dbSet.Include(x => x.Addresses)
                               .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
