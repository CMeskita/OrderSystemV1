using MediatR;
using Microsoft.AspNetCore.Mvc;
using OrderSystemV1.Application.Clientss.Requests;
using OrderSystemV1.Domain.Entity;
using OrderSystemV1.Domain.Interfaces;
using OrderSystemV1.Infra.Repository;
using OrderSystemV1.Infra.SqlDbContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderSystemV1.OrderSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IClientRepository _repository;
        public ClientController(IMediator mediator, IClientRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var client = await _repository.GetAllAsync();
            return View(client);
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> AddClient(ClientRequest client)
        {
            await _mediator.Send(client);
            return RedirectToAction("Index", "Client");
        }
    }
}
