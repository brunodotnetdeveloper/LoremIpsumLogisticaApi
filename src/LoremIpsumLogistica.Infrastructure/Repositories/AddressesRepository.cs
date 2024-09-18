using LoremIpsumLogistica.Core.Entities;
using LoremIpsumLogistica.Core.Interfaces;
using LoremIpsumLogistica.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace LoremIpsumLogistica.Infrastructure.Repositories
{
    public class AddressesRepository(LoremIpsumLogisticaDbContext context) : GenericRepository<Address>(context), IAddressesRepository
    {
        public async Task<IEnumerable<Address>> GetByClient(int clientId)
        {
            return await _dbSet.Where(x => x.ClientId == clientId).ToListAsync();
        }
    }
}
