using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Entities.Usuarios;
using SuperTest.Domain.Services;

namespace SuperTest.ApplicationService
{
    public class UsuarioAppService : AppServiceBase, IUsuarioService
    {
        public void CadastrarUsuario(CadastrarNovoUsuarioCommand command)
        {
            if (!command.IsValid())
            {
                base.Notifications = command.Notifications;
                return;
            }                

            Usuario usuario = new Usuario(command.Nome, command.CPF, command.Email, command.Senha);
        }
    }
}
