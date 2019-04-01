using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Validations.Usuarios;
using System.Linq;
using Xunit;

namespace SuperTest.UnitTest.Usuarios
{
    public class UsuarioTests
    {
        [Trait("Validation", "Cadastrar Novo Usuário")]
        [Theory(DisplayName = "Usuário não pode ter nome vazio")]
        [InlineData("", "email@provider.com", "95876974056", "abcd1234")]
        [InlineData("    ", "email@provider.com", "95876974056", "abcd1234")]
        public void Validation_CadastarNovoUsuario_UsuarioNaoPodeTerNomeVazio(string name, string email, string cpf, string senha)
        {
            var command = new CadastrarNovoUsuarioCommand(name, email, cpf, senha);
            var validation = new CadastrarNovoUsuarioValidation(command);

            validation.Validate();

            Assert.True(validation.Invalid);
            Assert.Equal("Nome não pode ser vazio", validation.Notifications.FirstOrDefault().Message);
        }

        [Trait("Validation", "Cadastrar Novo Usuário")]
        [Theory(DisplayName = "Usuário não pode ter CPF inválido")]
        [InlineData("Peter Parker", "email@provider.com", "11111111111", "abcd1234")]
        [InlineData("Arnold Schwarzenegger", "email@provider.com", "48789658841", "abcd1234")]
        public void Validation_CadastarNovoUsuario_UsuarioNaoPodeTerCPFInvalido(string name, string email, string cpf, string senha)
        {
            var command = new CadastrarNovoUsuarioCommand(name, email, cpf, senha);
            var validation = new CadastrarNovoUsuarioValidation(command);

            validation.Validate();

            Assert.True(validation.Invalid);
            Assert.Equal("CPF inválido", validation.Notifications.FirstOrDefault().Message);
        }
    }
}
