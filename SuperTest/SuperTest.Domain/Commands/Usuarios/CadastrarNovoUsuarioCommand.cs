using SuperTest.Domain.Entities.Usuarios;
using SuperTest.Domain.Validations.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperTest.Domain.Commands.Usuarios
{
    public class CadastrarNovoUsuarioCommand : Command
    {
        public CadastrarNovoUsuarioCommand(string nome, string email, string cpf)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
        }

        public string Nome{ get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }

        public override bool IsValid()
        {
            var validationResult = new CadastrarNovoUsuarioValidation().IsValid();

            return ValidationResult.IsSuccess;
        }
    }
}
