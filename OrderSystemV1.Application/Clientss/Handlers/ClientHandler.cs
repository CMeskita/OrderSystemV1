using MediatR;
using OrderSystemV1.Application.Clientss.Requests;
using OrderSystemV1.Application.Clientss.Responses;
using OrderSystemV1.Domain.Entity;
using OrderSystemV1.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderSystemV1.Application.Clientss.Handlers
{
    public class ClientHandler : IRequestHandler<ClientRequest, ClientResponse>
    {
        private readonly IClientRepository _repository;
        private readonly IUnityOfWork Uow;

        public ClientHandler(IClientRepository repository, IUnityOfWork uow)
        {
            _repository = repository;
            Uow = uow;
        }

        public async Task<ClientResponse> Handle(ClientRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Client client = new Client(request.Name, request.Email, request.BirthDate);
                await _repository.SaveClientAsync(client);
                Uow.Commit();
                return new ClientResponse
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
