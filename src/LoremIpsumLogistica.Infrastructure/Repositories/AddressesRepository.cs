using LoremIpsumLogistica.Core.Entities;
using LoremIpsumLogistica.Core.Interfaces;
using LoremIpsumLogistica.Infrastructure.Context;

namespace LoremIpsumLogistica.Infrastructure.Repositories
{
    public class AddressesRepository(LoremIpsumLogisticaDbContext context) : GenericRepository<Address>(context), IAddressesRepository
    {
        public Task<IEnumerable<Address>> GetByClient(int clientId)
        {
            throw new NotImplementedException();
        }
    }
}
