using LoremIpsumLogistica.Application.ViewModels;

namespace LoremIpsumLogistica.Application.Services.Interfaces
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientViewModel>> GetAll();
        Task<ClientViewModel> GetById(int id);
        Task<ClientViewModel> Create(CreateClientViewModel clientViewModel);
        Task Update(ClientViewModel clientViewModel);
        Task Delete(int id);
        Task<IEnumerable<AddressViewModel>> GetClientAddresses(int clientId);
        Task AddAddressToClient(int clientId, AddressViewModel addressViewModel);

        Task UpdateAddress(int clientId, int addressId, AddressViewModel addressViewModel);

        Task DeleteAddress(int clientId, int addressId);
    }
}
