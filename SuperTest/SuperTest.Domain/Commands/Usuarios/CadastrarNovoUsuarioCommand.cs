using SuperTest.Domain.Validations.Usuarios;

namespace SuperTest.Domain.Commands.Usuarios
{
    public sealed class CadastrarNovoUsuarioCommand : Command
    {
        public CadastrarNovoUsuarioCommand(string nome, string email, string cpf, string senha)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            Senha = senha;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public string Senha { get; private set; }


        public override bool IsValid()
        {
            var command = new CadastrarNovoUsuarioValidation(this);
            command.Validate();

            foreach (var notification in command.Notifications)
                Notifications.Add(notification.Message);            

            return command.Valid;
        }
    }
}
