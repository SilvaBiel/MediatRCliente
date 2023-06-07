﻿using MediatR;

namespace MediatorCliente.Application.Notifications
{
    public class ClienteAlteradoNotification : INotification
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsEfetivado { get; set; }
    }
}
