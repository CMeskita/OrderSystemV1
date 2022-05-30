using MediatR;
using OrderSystemV1.Application.Clientss.Responses;
using System;

namespace OrderSystemV1.Application.Clientss.Requests
{
    public class ClientRequest : IRequest<ClientResponse>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
