using OrderSystemV1.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystemV1.Domain.Interfaces
{
    public interface IClientRepository
    {
        Task SaveClientAsync(Client client);
        Task<List<Client>> GetAllAsync();
        Task<Client> GetByIdAsync(Guid id);
    }
}
