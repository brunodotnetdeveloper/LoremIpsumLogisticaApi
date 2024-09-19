using AutoMapper;
using LoremIpsumLogistica.Application.Services.Interfaces;
using LoremIpsumLogistica.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoremIpsumLogistica.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController(IClientsService clientsService) : ControllerBase
    {
        private readonly IClientsService _clientsService = clientsService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientViewModel>>> GetAll()
        {
            var clients = await _clientsService.GetAll();
            
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientViewModel>> GetById(int id)
        {
            var client = await _clientsService.GetById(id);

            if (client == null)
                return NotFound();
            
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientViewModel>> Create([FromBody] CreateClientViewModel clientViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("O Cliente não pode ser nulo.");

            var createdClient = await _clientsService.Create(clientViewModel);

            return CreatedAtAction(nameof(GetById), new { id = createdClient.Id }, createdClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClientViewModel clientViewModel)
        {
            if (id != clientViewModel.Id)
                return BadRequest("ID do cliente não bate.");

            var existingClient = await _clientsService.GetById(id);

            if (existingClient == null)
                return NotFound();

            await _clientsService.Update(clientViewModel);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _clientsService.GetById(id);

            if (client == null)
                return NotFound();

            await _clientsService.Delete(id);

            return NoContent();
        }


        [HttpDelete("{clientId}/address/{addressId}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int clientId, [FromRoute] int addressId)
        {
            await _clientsService.DeleteAddress(clientId, addressId);

            return NoContent();
        }

        [HttpGet("{clientId}/addresses")]
        public async Task<ActionResult<IEnumerable<AddressViewModel>>> GetClientAddresses(int clientId)
        {
            var addresses = await _clientsService.GetClientAddresses(clientId);

            return Ok(addresses);
        }

        [HttpPost("{clientId}/addresses")]
        public async Task<ActionResult> AddAddressToClient(int clientId, [FromBody] AddressViewModel addressViewModel)
        {
            if (addressViewModel == null)
                return BadRequest("O endereço não pode ser nulo.");

            await _clientsService.AddAddressToClient(clientId, addressViewModel);

            return NoContent();
        }

        [HttpPut("{clientId}/address/{addressId}")]
        public async Task<ActionResult> UpdateAddress(int clientId, int addressId, [FromBody] AddressViewModel addressViewModel)
        {
            if (addressViewModel == null)
                return BadRequest("O endereço não pode ser nulo.");

            await _clientsService.UpdateAddress(clientId, addressId, addressViewModel);

            return NoContent();
        }
    }
}
