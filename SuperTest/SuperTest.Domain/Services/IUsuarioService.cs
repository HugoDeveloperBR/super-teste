using SuperTest.Domain.Commands.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTest.Domain.Services
{
    public interface IUsuarioService : IDisposable
    {
        void CadastrarUsuario(CadastrarNovoUsuarioCommand command);
    }
}
