using MediatR;

namespace MediatorCliente.Application.Notifications
{
    public class ClienteExcluidoNotification : INotification
    {
        
        public int Id { get; set; }
        public bool IsEfetivado { get; set; }
    }
}
