using MediatR;

namespace MediatorCliente.Application.Commands
{
    public class AlteraClienteCommand : IRequest<string>
    {
        public int ClienteId { get; set; }
        public string ClienteName { get; set; } = string.Empty;
        public string ClienteLastName { get; set; } = string.Empty;
        public long ClientePhone { get; set; }
        public string ClienteEmail { get; set; } = string.Empty;
        public string ClienteCep { get; set; } = string.Empty;
        public long ClienteCPF { get; set; }
    }
}
