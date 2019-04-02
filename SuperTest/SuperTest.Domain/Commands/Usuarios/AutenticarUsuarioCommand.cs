using SuperTest.Domain.Validations.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTest.Domain.Commands.Usuarios
{
    public class AutenticarUsuarioCommand : Command
    {
        public AutenticarUsuarioCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public override bool IsValid()
        {
            var command = new AutenticarUsuarioValidation(this);
            command.Validate();

            foreach (var notification in command.Notifications)
                Notifications.Add(notification.Message);

            return command.Valid;
        }
    }
}
