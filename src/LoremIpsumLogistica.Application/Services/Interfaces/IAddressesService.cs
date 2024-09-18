using LoremIpsumLogistica.Core.Entities;

namespace LoremIpsumLogistica.Application.Services.Interfaces
{
    public interface IAddressesService
    {
        Task<IEnumerable<Address>> GetAll();
        Task<Address> GetById(int id);
        Task<Address> Create(Address address);
        Task Update(Address address);
        Task Delete(int id);
    }
}
