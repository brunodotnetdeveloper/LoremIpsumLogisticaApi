using LoremIpsumLogistica.Core.Entities;
using LoremIpsumLogistica.Core.Interfaces;
using LoremIpsumLogistica.Infrastructure.Context;

namespace LoremIpsumLogistica.Infrastructure.Repositories
{
    public class ClientsRepository(LoremIpsumLogisticaDbContext context) : GenericRepository<Client>(context), IClientsRepository { }
}
