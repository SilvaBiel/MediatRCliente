using MediatorCliente.Application.Commands;
using MediatorCliente.Application.Models;
using MediatorCliente.Application.Notifications;
using MediatorCliente.Context;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MediatorCliente.Application.Handlers
{
    public class AlteraClienteCommandHandler : IRequestHandler<AlteraClienteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Cliente> _repository;
        public AlteraClienteCommandHandler(IMediator mediator, IRepository<Cliente> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(AlteraClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente
            {
                ClienteId = request.ClienteId,
                ClienteName = request.ClienteName,
                ClienteCPF = request.ClienteCPF,
                ClienteCep = request.ClienteCep,
                ClienteEmail = request.ClienteEmail,
                ClienteLastName = request.ClienteLastName,
                ClientePhone = request.ClientePhone
            };

            try
            {
                await _repository.Edit(cliente);

                await _mediator.Publish(new ClienteAlteradoNotification { Id = cliente.ClienteId, Nome = cliente.ClienteName, Email = cliente.ClienteEmail, IsEfetivado = true });

                return await Task.FromResult("Pessoa alterada com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ClienteAlteradoNotification { Id = cliente.ClienteId, Nome = cliente.ClienteName, Email = cliente.ClienteEmail, IsEfetivado = true });
                await _mediator.Publish(new ErrorNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da alteração");
            }

        }
    }
}
