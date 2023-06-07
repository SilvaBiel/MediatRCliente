using MediatR;

namespace MediatorCliente.Application.Notifications
{
    public class ErrorNotification : INotification
    {
        public string Excecao { get; set; } = string.Empty;
        public string PilhaErro { get; set; } = string.Empty;
    }
}
