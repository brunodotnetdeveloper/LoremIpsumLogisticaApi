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
            try
            {
                // Validação do cliente
                if (string.IsNullOrEmpty(clientViewModel.Name))
                    throw new ArgumentException("O nome do cliente é obrigatório.");

                if (clientViewModel.BirthDate == default)
                    throw new ArgumentException("A data de nascimento é obrigatória.");

                var client = _mapper.Map<Client>(clientViewModel);

                await _clientsRepository.Create(client);

                return _mapper.Map<ClientViewModel>(client);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public async Task<ClientViewModel> GetById(int id)
        {
            var client = await _clientsRepository.GetById(id);

            return _mapper.Map<ClientViewModel>(client);
        }

        public async Task Update(ClientViewModel clientViewModel)
        {
            // Busca o cliente pelo ID no banco de dados
            var client = await _clientsRepository.GetById(clientViewModel.Id);

            if (client != null)
            {
                // Atualiza as propriedades do cliente
                _mapper.Map(clientViewModel, client);

                // Verifica se há endereços enviados no ViewModel
                if (clientViewModel.Addresses != null && clientViewModel.Addresses.Any())
                {
                    // Obter os endereços atuais do cliente no banco de dados
                    var existingAddresses = await _addressesRepository.GetByClient(client.Id);

                    // Adicionar novos endereços
                    foreach (var addressViewModel in clientViewModel.Addresses)
                    {
                        // Verifica se o endereço já existe no banco de dados
                        var existingAddress = existingAddresses.FirstOrDefault(a => a.Id == addressViewModel.Id);

                        if (existingAddress == null)
                        {
                            // Se o endereço não existir, adicionar um novo
                            var newAddress = _mapper.Map<Address>(addressViewModel);
                            newAddress.ClientId = client.Id;
                            await _addressesRepository.Create(newAddress);
                        }
                        else
                        {
                            // Se o endereço existir, atualizá-lo
                            _mapper.Map(addressViewModel, existingAddress);
                            await _addressesRepository.Update(existingAddress);
                        }
                    }

                    // Remover endereços que não estão mais no ViewModel
                    var addressIdsInViewModel = clientViewModel.Addresses.Select(a => a.Id).ToList();
                    var addressesToRemove = existingAddresses.Where(a => !addressIdsInViewModel.Contains(a.Id)).ToList();

                    foreach (var address in addressesToRemove)
                    {
                        // Lógica de remoção (pode ser exclusão lógica ou física, conforme necessário)
                        await _addressesRepository.Delete(address);
                    }
                }

                // Atualiza o cliente no banco de dados
                await _clientsRepository.Update(client);
            }
            else
            {
                throw new Exception("Cliente não encontrado.");
            }
        }


        public async Task Delete(int id)
        {
            var client = await _clientsRepository.GetById(id);

            if (client != null)
            {
                var addresses = await _addressesRepository.GetByClient(id);

                foreach (var address in addresses)
                {
                    await _addressesRepository.Delete(address);
                }

                await _clientsRepository.Delete(client);
            }
        }

        public async Task<IEnumerable<AddressViewModel>> GetClientAddresses(int clientId)
        {
            var addresses = await _addressesRepository.GetByClient(clientId);

            return _mapper.Map<IEnumerable<AddressViewModel>>(addresses);
        }

        public async Task AddAddressToClient(int clientId, AddressViewModel addressViewModel)
        {
            // Verifica se o cliente existe
            var client = await _clientsRepository.GetById(clientId);

            if (client == null)
                throw new KeyNotFoundException($"Cliente com ID {clientId} não encontrado.");

            var address = _mapper.Map<Address>(addressViewModel);

            address.ClientId = clientId; // Associa o endereço ao cliente

            await _addressesRepository.Create(address);
        }

        public async Task DeleteAddress(int clientId, int addressId)
        {
            var client = await _clientsRepository.GetById(clientId);

            if (client == null)
                throw new KeyNotFoundException($"Cliente com ID {clientId} não encontrado.");

            var address = await _addressesRepository.GetById(addressId);

            if (address == null)
                throw new KeyNotFoundException($"Endereço com ID {addressId} não encontrado");

            if (!client.Addresses.Contains(address))
                throw new Exception("Esse endereço não pertence ao cliente informado");

            await _addressesRepository.Delete(address);
        }
    }
}
