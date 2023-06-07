using MediatorCliente.Application.Notifications;
using MediatR;

namespace MediatorCliente.Application.EventHandlers
{
    public class EventHandler :
                                INotificationHandler<ClienteAlteradoNotification>,
                                INotificationHandler<ClienteCriadoNotification>,
                                INotificationHandler<ClienteExcluidoNotification>,
                                INotificationHandler<ErrorNotification>
    {
        public Task Handle(ClienteCriadoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"CRIACAO: '{notification.Id} - {notification.Nome} - {notification.Email}'");
            });
        }

        public Task Handle(ClienteAlteradoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ALTERACAO: '{notification.Id} - {notification.Nome} - {notification.Email} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(ClienteExcluidoNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"EXCLUSAO: '{notification.Id} - {notification.IsEfetivado}'");
            });
        }

        public Task Handle(ErrorNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"ERRO: '{notification.Excecao} \n {notification.PilhaErro}'");
            });
        }
    }
}
