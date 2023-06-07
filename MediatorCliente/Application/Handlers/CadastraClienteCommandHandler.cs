using MediatorCliente.Application.Commands;
using MediatorCliente.Application.Models;
using MediatorCliente.Application.Notifications;
using MediatR;
using System;

namespace MediatorCliente.Application.Handlers
{
    public class CadastraClienteCommandHandler : IRequestHandler<CadastraClienteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Cliente> _repository;
        public CadastraClienteCommandHandler(IMediator mediator, IRepository<Cliente> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }
        public async Task<string> Handle(CadastraClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente { ClienteName = request.ClienteName, ClienteCPF = request.ClienteCPF, ClienteCep = request.ClienteCep, 
                                        ClienteEmail = request.ClienteEmail, ClienteLastName = request.ClienteLastName, ClientePhone = request.ClientePhone};

            try
            {
                await _repository.Add(cliente);

                await _mediator.Publish(new ClienteCriadoNotification { Id = cliente.ClienteId, Nome = cliente.ClienteName, Email = cliente.ClienteEmail});

                return await Task.FromResult("Cliente criado com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ErrorNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da criação");
            }

        }
    }
}
