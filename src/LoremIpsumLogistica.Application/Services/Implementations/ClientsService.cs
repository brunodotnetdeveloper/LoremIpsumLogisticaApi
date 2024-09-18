using AutoMapper;
using LoremIpsumLogistica.Application.Services.Interfaces;
using LoremIpsumLogistica.Application.ViewModels;
using LoremIpsumLogistica.Core.Entities;
using LoremIpsumLogistica.Core.Interfaces;

namespace LoremIpsumLogistica.Application.Services.Implementations
{
    public class ClientsService(IClientsRepository clientsRepository, IAddressesRepository addressesRepository, IMapper mapper) : IClientsService
    {
        private readonly IClientsRepository _clientsRepository = clientsRepository;
        private readonly IAddressesRepository _addressesRepository = addressesRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<ClientViewModel>> GetAll()
        {
            var clients = await _clientsRepository.GetAll();

            return _mapper.Map<IEnumerable<ClientViewModel>>(clients);
        }

        public async Task<ClientViewModel> Create(CreateClientViewModel clientViewModel)
        {
            var client = _mapper.Map<Client>(clientViewModel);

            await _clientsRepository.Create(client);

            return _mapper.Map<ClientViewModel>(client);
        }

        public async Task<ClientViewModel> GetById(int id)
        {
            var client = await _clientsRepository.GetById(id);

            return _mapper.Map<ClientViewModel>(client);
        }

        public async Task Update(ClientViewModel clientViewModel)
        {
            var client = await _clientsRepository.GetById(clientViewModel.Id);

            client.Active = clientViewModel.Active;
            client.Name = clientViewModel.Name;
            client.BirthDate = clientViewModel.BirthDate;

            await _clientsRepository.Update(client);
        }

        public async Task Delete(int id)
        {
            var client = await _clientsRepository.GetById(id);

            if (client != null)
            {
                var addresses = await _addressesRepository.GetByClient(id);

                foreach (var address in addresses)
                {
                    await _addressesRepository.LogicalDeletion(address);
                }

                await _clientsRepository.LogicalDeletion(client);
            }
        }

        public async Task<IEnumerable<AddressViewModel>> GetClientAddresses(int clientId)
        {
            var address = await _addressesRepository.GetByClient(clientId);

            return _mapper.Map<IEnumerable<AddressViewModel>>(address);
        }

        public async Task AddAddressToClient(int clientId, AddressViewModel addressViewModel)
        {

            var address = _mapper.Map<Address>(addressViewModel);

            await _addressesRepository.Create(address);
        }
    }
}