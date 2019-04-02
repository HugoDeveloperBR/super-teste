using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Helpers;
using System;

namespace SuperTest.Domain.Services
{
    public interface IUsuarioService : INotification, IDisposable
    {
        void CadastrarUsuario(CadastrarNovoUsuarioCommand command);
        bool AutenticarUsuario(AutenticarUsuarioCommand command);
    }
}
