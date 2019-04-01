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

            if (!cpf.Validar())
                AddNotification(nameof(command.CPF), "CPF inválido");
        }

        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(command.Nome) || string.IsNullOrWhiteSpace(command.Nome))
                AddNotification(nameof(command.Nome), "Nome não pode ser vazio");
        }

        private void ValidarEmail()
        {
            if (!StringHelper.EmailEhValido(command.Email))
                AddNotification(nameof(command.Email), "Email inválido");
        }

        private void ValidarSenha()
        {
            if (string.IsNullOrEmpty(command.Senha) || string.IsNullOrWhiteSpace(command.Senha))
                AddNotification(nameof(command.Senha), "Senha não pode ser vazia");

            if (command.Senha.Length < 6)
                AddNotification(nameof(command.Senha), "Senha deve ter no minimo 6 caracteres");
        }
    }
}
