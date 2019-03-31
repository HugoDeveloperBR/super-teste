using System;
using System.Collections.Generic;

namespace SuperTest.Domain.Entities.QA
{
    public class Objetivo : BaseEntity
    {
        protected Objetivo() { }

        public Objetivo(string especificacao)
        {
            Id = Guid.NewGuid();
            Tarefas = new List<Tarefa>();
        }

        public string Especificacao { get; set; }
        public string Hipotese { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; }        

        public static class ObjetivoFactory
        {
            public static Objetivo NovoObjetivo(string especificacao, string hipotese)
            {
                var objetivo = new Objetivo
                {
                    Id = Guid.NewGuid(),
                    Especificacao = especificacao,
                    Hipotese = hipotese
                };

                return objetivo;
            }
        }
    }
}
