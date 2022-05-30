using MediatR;
using OrderSystemV1.Application.Productss.Responses;

namespace OrderSystemV1.Application.Productss.Requests
{
    public class ProductRequest : IRequest<ProductResponse>
    {
        public string Name { get;  set; }
        public decimal Price { get;  set; }
    }
}
