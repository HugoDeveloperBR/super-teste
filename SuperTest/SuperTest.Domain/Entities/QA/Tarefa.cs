using System;

namespace SuperTest.Domain.Entities.QA
{
    public class Tarefa : BaseEntity
    {
        protected Tarefa() { }

        public string Descricao { get; private set; }
        public string DefinicaoDeSucesso { get; private set; }
        public bool Atende { get; private set; }
        public DateTime CriadoEm { get; set; }
    }
}
