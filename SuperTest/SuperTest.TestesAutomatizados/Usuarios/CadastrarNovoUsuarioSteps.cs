using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Validations.Usuarios;
using System;
using TechTalk.SpecFlow;
using Xunit;

namespace SuperTest.TestesAutomatizados.Usuarios
{
    [Binding]
    public class CadastrarNovoUsuarioSteps
    {
        private CadastrarNovoUsuarioCommand _command;
        private CadastrarNovoUsuarioValidation _validation;

        public CadastrarNovoUsuarioSteps()
        {
            _command = new CadastrarNovoUsuarioCommand("", "email@provider.com", "40225701804", "abc123");
            _validation = new CadastrarNovoUsuarioValidation(_command);
        }

        [Given(@"Um nome em com espacos em branco")]
        public void GivenUmNomeEmComEspacosEmBranco()
        {
            Assert.Equal("", _command.Nome);
        }
        
        [Given(@"Um email valido")]
        public void GivenUmEmailValido()
        {
            Assert.Equal("email@provider.com", _command.Email);
        }
        
        [Given(@"Um CPF valido")]
        public void GivenUmCPFValido()
        {
            Assert.Equal("40225701804", _command.CPF);
        }
        
        [Given(@"Uma senha com mais de (.*) caracteres")]
        public void GivenUmaSenhaComMaisDeCaracteres(int p0)
        {
            Assert.True(_command.Senha.Length >= 6);
        }
        
        [When(@"Chamo o metodo CadastrarUsuario")]
        public void WhenChamoOMetodoCadastrarUsuario()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Recebo a mensagem ""(.*)""")]
        public void ThenReceboAMensagem(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
