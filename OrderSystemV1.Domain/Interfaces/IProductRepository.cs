using OrderSystemV1.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystemV1.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task SaveProductAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
       
    }
}
