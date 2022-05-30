using OrderSystemV1.Domain.Entity;
using OrderSystemV1.Domain.Interfaces;
using OrderSystemV1.Infra.SqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystemV1.Infra.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly SqlContext _context;

        public ClientRepository(SqlContext context)
        {
            _context = context;
        }

        public ClientRepository()
        {
        }

        public async Task SaveClientAsync(Client client)
        {
            await _context.AddAsync(client);

        }

        //lista Todos os Clientes Cadastrados
        public async Task<List<Client>> GetAllAsync()
        {
            return await Task.FromResult(_context.Clients.ToList());
        }
        //lista o cliente pelo id - cliente filtrado
        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_context.Clients.Find(id));
        }
    }
}
