using MediatR;

namespace MediatorCliente.Application.Commands
{
    public class DeletaClienteCommand : IRequest<string>
    {
        public int ClienteId { get; set; }
    }
}
