using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Helpers;
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
            Assert.Equal(Resource.NOME_REQUIRED, validation.Notifications.FirstOrDefault().Message);
        }

        [Trait("Validation", "Cadastrar Novo Usuário")]
        [Theory(DisplayName = "Usuário não pode ter CPF inválido")]
        [InlineData("Peter Parker", "email@provider.com", null, "abcd1234")]
        [InlineData("Peter Parker", "email@provider.com", "11111111111", "abcd1234")]
        [InlineData("Arnold Schwarzenegger", "email@provider.com", "48789658841", "abcd1234")]
        public void Validation_CadastarNovoUsuario_UsuarioNaoPodeTerCPFInvalido(string name, string email, string cpf, string senha)
        {
            var command = new CadastrarNovoUsuarioCommand(name, email, cpf, senha);
            var validation = new CadastrarNovoUsuarioValidation(command);

            validation.Validate();

            Assert.True(validation.Invalid);
            Assert.Equal(Resource.CPF_INVALID, validation.Notifications.FirstOrDefault().Message);
        }

        [Trait("Validation", "Cadastrar Novo Usuário")]
        [Theory(DisplayName = "Usuário não pode ter Email inválido")]
        [InlineData("Jackie Chan", "", "84364164062", "abcd1234")]
        [InlineData("Peter Parker", "provider.com", "84364164062", "abcd1234")]
        [InlineData("Arnold Schwarzenegger", "@provider.com", "60779344022", "abcd1234")]
        public void Validation_CadastarNovoUsuario_UsuarioNaoPodeTerEmailInvalido(string name, string email, string cpf, string senha)
        {
            var command = new CadastrarNovoUsuarioCommand(name, email, cpf, senha);
            var validation = new CadastrarNovoUsuarioValidation(command);

            validation.Validate();

            Assert.True(validation.Invalid);
            Assert.Equal(Resource.EMAIL_INVALID, validation.Notifications.FirstOrDefault().Message);
        }       

        [Trait("Validation", "Cadastrar Novo Usuário")]
        [Theory(DisplayName ="Usuário não pode ter menos que 6 caractes e nem espaços em branco")]
        [InlineData("Jackie Chan", "email@provider.com", "84364164062", null)]
        [InlineData("Peter Parker", "email@provider.com", "84364164062", "      ")]
        [InlineData("Arnold Schwarzenegger", "email@provider.com", "60779344022", "abcd1")]
        public void Validation_CadastarNovoUsuario_UsuarioNaoPodeTerSenhaComMenosDe6CaracteresENemEspecosEmBranco(string name, string email, string cpf, string senha)
        {
            var command = new CadastrarNovoUsuarioCommand(name, email, cpf, senha);
            var validation = new CadastrarNovoUsuarioValidation(command);

            validation.Validate();

            Assert.True(validation.Invalid);
            Assert.Equal(string.Format(Resource.SENHA_MIN_CHARACTERS, 6), validation.Notifications.FirstOrDefault().Message);
        }

    }
}
