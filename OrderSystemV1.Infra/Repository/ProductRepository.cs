using OrderSystemV1.Domain.Entity;
using OrderSystemV1.Domain.Interfaces;
using OrderSystemV1.Infra.SqlDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystemV1.Infra.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlContext _context;

        public ProductRepository(SqlContext context)
        {
            _context = context;
        }

        //Salva o objeto produto
        public async Task SaveProductAsync(Product product)
        {
            await _context.AddAsync(product);

        }
    
        //lista Todos os produtos Cadastrados
        public async Task<List<Product>> GetAllAsync()
        {
            return await Task.FromResult(_context.Products.ToList());
        }
        //lista o produto pelo id - produto filtrado
        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(_context.Products.Find(id));
        }

    }
}
