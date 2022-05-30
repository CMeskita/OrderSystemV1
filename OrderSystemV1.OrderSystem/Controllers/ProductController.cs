using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderSystemV1.Application.Productss.Requests;
using OrderSystemV1.Domain.Entity;
using OrderSystemV1.Domain.Interfaces;
using System.Threading.Tasks;

namespace OrderSystemV1.OrderSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IProductRepository _repository;
        public ProductController(IMediator mediator, IProductRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var product = await _repository.GetAllAsync();
            return View(product);           
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> AddProduct(ProductRequest product)
        {
            await _mediator.Send(product);
            return RedirectToAction("Index", "Product");
        }
    }
}
