using MediatR;

namespace MediatorCliente.Application.Notifications
{
    public class ClienteCriadoNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
