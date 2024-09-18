using LoremIpsumLogistica.Core.Entities;

namespace LoremIpsumLogistica.Core.Interfaces
{
    public interface IAddressesRepository : IGenericRepository<Address>
    {
        Task<IEnumerable<Address>> GetByClient(int clientId);
    }
}
