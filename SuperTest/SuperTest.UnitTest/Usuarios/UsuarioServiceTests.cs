using Moq;
using SuperTest.ApplicationService;
using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Entities.Usuarios;
using SuperTest.Domain.Repositories.Usuarios;
using System.Linq;
using Xunit;
using Shouldly;

namespace SuperTest.UnitTest.Usuarios
{
    public class UsuarioServiceTests
    {
        [Trait("Service", "Cadastrar Usuário")]
        [Fact(DisplayName ="Cada email de usuário deve ser único")]        
        public void UsuarioService_CadatrarUsuario_CadaEmailDeUsuarioDeveSerUnico()
        {
            var usuarioMock = new Usuario("Hugo", "email@provider.com", "40225701804", "123456");

            var repo = new Mock<IUsuarioRepository>();
            repo.Setup(r => r.ObterUsuarioPorEmail("email@provider.com")).Returns(usuarioMock);

            var service = new UsuarioAppService(repo.Object);
            service.CadastrarUsuario(new CadastrarNovoUsuarioCommand("Hugo", "email@provider.com", "40225701804", "123abc"));

            repo.Verify(r => r.AdicionarUsuario(usuarioMock), Times.Never);
            service.HasNotification.ShouldBeTrue();
            service.Notifications.FirstOrDefault().ShouldBe("Email já cadastrado");
        }
    }
}
