using SuperTest.ApplicationService;
using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.Services;
using SuperTest.Domain.Validations.Usuarios;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SuperTest.UnitTest.Usuarios
{
    public class UsuarioTests
    {
        [Fact(DisplayName ="")]
        [Trait("","")]
        public void Validation_CadastarNovoUsuario_UsuarioNaoPodeTerNomeVazio()
        {
            var command = new CadastrarNovoUsuarioCommand("", "email@provider.com", "40225701804", "125453");
            var validation = new CadastrarNovoUsuarioValidation(command);

            validation.Validate();

            Assert.True(validation.Invalid);
            Assert.Equal(1, validation.Notifications.Count);
            Assert.Equal("Nome não pode ser vazio", validation.Notifications.FirstOrDefault().Message);

            command = new CadastrarNovoUsuarioCommand("Hugo Moura", "email@provider.com", "40225701804", "125453");
            validation = new CadastrarNovoUsuarioValidation(command);
            validation.Validate();

            Assert.True(validation.Valid);
        }
    }
}
