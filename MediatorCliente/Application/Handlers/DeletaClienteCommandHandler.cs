using MediatorCliente.Application.Commands;
using MediatorCliente.Application.Models;
using MediatorCliente.Application.Notifications;
using MediatorCliente.Repositories;
using MediatR;

namespace MediatorCliente.Application.Handlers
{
    public class DeletaClienteCommandHandler : IRequestHandler <DeletaClienteCommand, String>
    {
        private readonly IMediator _mediator;
        private readonly IRepository<Cliente> _repository;
        public DeletaClienteCommandHandler(IMediator mediator, IRepository<Cliente> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }

        public async Task<string> Handle(DeletaClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.Delete(request.ClienteId);

                await _mediator.Publish(new ClienteExcluidoNotification { Id = request.ClienteId, IsEfetivado = true });

                return await Task.FromResult("Pessoa excluída com sucesso");
            }
            catch (Exception ex)
            {
                await _mediator.Publish(new ClienteExcluidoNotification { Id = request.ClienteId, IsEfetivado = false });
                await _mediator.Publish(new ErrorNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }

        }
    }
}
