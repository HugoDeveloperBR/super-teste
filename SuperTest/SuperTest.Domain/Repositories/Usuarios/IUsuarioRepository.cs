using SuperTest.Domain.Entities.Usuarios;

namespace SuperTest.Domain.Repositories.Usuarios
{
    public interface IUsuarioRepository
    {
        void AdicionarUsuario(Usuario usuario);
        Usuario ObterUsuarioPorEmail(string email);
    }
}
