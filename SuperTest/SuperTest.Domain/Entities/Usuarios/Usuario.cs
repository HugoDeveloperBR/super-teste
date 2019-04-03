using SuperTest.Domain.ValueObject.Usuarios;
using System;

namespace SuperTest.Domain.Entities.Usuarios
{
    public class Usuario : BaseEntity
    {
        protected Usuario() { }

        public Usuario(string nome, string cpf, string email, string senha)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            CPF = new CPF(cpf);
            Conta = new Conta(senha);
            CriadoEm = DateTime.Now;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public CPF CPF { get; private set; }
        public Conta Conta { get; private set; }
        public DateTime CriadoEm { get; private set; }

    }
}
