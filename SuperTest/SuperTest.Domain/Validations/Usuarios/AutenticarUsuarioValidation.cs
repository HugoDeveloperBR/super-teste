using Flunt.Notifications;
using Flunt.Validations;
using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Helpers;

namespace SuperTest.Domain.Validations.Usuarios
{
    public class AutenticarUsuarioValidation : Notifiable, IValidatable
    {
        private readonly AutenticarUsuarioCommand command;

        public AutenticarUsuarioValidation(AutenticarUsuarioCommand command)
        {
            this.command = command;
        }

        public void Validate()
        {
            ValidarEmail();
            ValidarSenha();
        }

        private void ValidarEmail()
        {
            if (!AssertConcern.EmailEhValido(command.Email))
                AddNotification(nameof(command.Email), Resource.EMAIL_INVALID);
        }

        private void ValidarSenha()
        {
            if (string.IsNullOrEmpty(command.Senha) || !StringHelper.TextoTemMinCaracteres(command.Senha, 6, false))
                AddNotification(nameof(command.Senha), string.Format(Resource.SENHA_MIN_CHARACTERS, "6"));
        }
    }
}
