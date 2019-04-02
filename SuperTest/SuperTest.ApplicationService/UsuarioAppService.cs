using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Entities.Usuarios;
using SuperTest.Domain.Repositories.Usuarios;
using SuperTest.Domain.Services;

namespace SuperTest.ApplicationService
{
    public class UsuarioAppService : AppServiceBase, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public bool AutenticarUsuario(AutenticarUsuarioCommand command)
        {
            if(!command.IsValid())
            {
                base.Notifications = command.Notifications;
                return false; ;
            }

            return true;
        }

        public void CadastrarUsuario(CadastrarNovoUsuarioCommand command)
        {
            if (!command.IsValid())
            {
                base.Notifications = command.Notifications;
                return;
            }

            var usuario = _usuarioRepository.ObterUsuarioPorEmail(command.Email);

            if (usuario != null)
            {
                AddNotification("Email já cadastrado");
                return;
            }

            usuario = new Usuario(command.Nome, command.CPF, command.Email, command.Senha);

            _usuarioRepository.AdicionarUsuario(usuario);
        }
    }
}
