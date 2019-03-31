using System;

namespace SuperTest.Domain.Validations.Usuarios
{
    public class CadastrarNovoUsuarioValidation : Validation
    {
        private Result ValidarNome()
        {
            return Result.Fail("");
        }

        private Result ValidarEmail()
        {
            return Result.Fail("");
        }

        public override Result IsValid()
        {
            return Result.Combine(ValidarNome(), ValidarEmail());
        }
    }
}
