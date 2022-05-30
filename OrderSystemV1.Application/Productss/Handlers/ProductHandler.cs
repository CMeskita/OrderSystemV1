using MediatR;
using OrderSystemV1.Application.Productss.Requests;
using OrderSystemV1.Application.Productss.Responses;
using OrderSystemV1.Domain.Entity;
using OrderSystemV1.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderSystemV1.Application.Productss.Handlers
{
    public class ProductHandler : IRequestHandler<ProductRequest, ProductResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IUnityOfWork Uow;
        public ProductHandler(IProductRepository repository, IUnityOfWork uow)
        {
            _repository = repository;
            Uow = uow;
        }
        public async Task<ProductResponse> Handle(ProductRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = new Product(request.Name,request.Price);
                await _repository.SaveProductAsync(product);
                Uow.Commit();
                return new ProductResponse
                {
                    Message = "Sucessifuly",
                    StatusCode = 200

                };

            }
            catch (Exception)
            {
                Uow.Rollback();
                throw;
            }
        }
    }
}
