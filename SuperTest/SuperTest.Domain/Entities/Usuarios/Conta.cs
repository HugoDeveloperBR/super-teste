using SuperTest.Domain.Helpers;
using System;

namespace SuperTest.Domain.Entities.Usuarios
{
    public class Conta : BaseEntity
    {
        protected Conta() { }

        public Conta(string senha)
        {
            Id = Guid.NewGuid();
            Senha = StringHelper.CriptografarTexto(senha);
            SenhaExpiraEm = DateTime.Now.AddDays(15);
            SenhaAtualizadaEm = DateTime.Now;
            StatusConta = StatusConta.Ativa;
        }

        public string Senha { get; set; }
        public DateTime SenhaExpiraEm { get; set; }
        public DateTime SenhaAtualizadaEm { get; set; }
        public StatusConta StatusConta { get; set; }
        //EF
        public Guid UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
