﻿using Flunt.Notifications;
using Flunt.Validations;
using SuperTest.Domain.Commands.Usuarios;
using SuperTest.Domain.ValueObject.Usuarios;

namespace SuperTest.Domain.Validations.Usuarios
{
    public sealed class CadastrarNovoUsuarioValidation : Notifiable, IValidatable
    {
        private readonly CadastrarNovoUsuarioCommand command;

        public CadastrarNovoUsuarioValidation(CadastrarNovoUsuarioCommand command)
        {
            this.command = command;
        }

        public void Validate()
        {
            ValidarCPF();
            ValidarNome();
            ValidarEmail();
            ValidarSenha();
        }

        private void ValidarCPF()
        {
            var cpf = new CPF(command.CPF);

            if (!cpf.Validar())
                AddNotification(nameof(command.CPF), "CPF inválido");
        }

        private void ValidarNome()
        {
            if (string.IsNullOrEmpty(command.Nome) || string.IsNullOrWhiteSpace(command.Nome))
                AddNotification(nameof(command.Nome), "Nome não pode ser vazio");
        }

        private void ValidarEmail()
        {

        }

        private void ValidarSenha()
        {

        }
    }
}
