using Flunt.Notifications;
using Flunt.Validations;
using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Helpers;
using SuperTest.Domain.ValueObject.Usuarios;

namespace SuperTest.Domain.Validations.Usuarios
{
    public sealed class CadastrarNovoUsuarioValidation : Notifiable, IValidatable
    {
        private readonly CadastrarNovoUsuarioCommand command;

        public CadastrarNovoUsuarioValidation(CadastrarNovoUsuarioCommand command)
        {
            this.command = command;
        }

        public void Validate()
        {
            ValidarCPF();
            ValidarNome();
            ValidarEmail();
            ValidarSenha();
        }

        private void ValidarCPF()
        {
            var cpf = new CPF(command.CPF);

            if (string.IsNullOrEmpty(command.CPF) || !cpf.Validar())
                AddNotification(nameof(command.CPF), Resource.CPF_INVALID);
        }

        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(command.Nome) || string.IsNullOrWhiteSpace(command.Nome))
                AddNotification(nameof(command.Nome), Resource.NOME_REQUIRED);
        }

        private void ValidarEmail()
        {
            if (string.IsNullOrEmpty(command.Email) || !StringHelper.EmailEhValido(command.Email))
                AddNotification(nameof(command.Email), Resource.EMAIL_INVALID);
        }

        private void ValidarSenha()
        {
            if (string.IsNullOrEmpty(command.Senha) || !StringHelper.TextoTemMinCaracteres(command.Senha, 6))
                AddNotification(nameof(command.Senha), string.Format(Resource.SENHA_MIN_CHARACTERS, "6"));
        }
    }
}
