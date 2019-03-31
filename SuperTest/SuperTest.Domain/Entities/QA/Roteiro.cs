using System;
using System.Collections.Generic;

namespace SuperTest.Domain.Entities.QA
{
    public class Roteiro : BaseEntity
    {
        public Roteiro()
        {
            Objetivos = new List<Objetivo>();
            CriadoEm = DateTime.UtcNow;
        }

        public ICollection<Objetivo> Objetivos { get; private set; }
        public DateTime CriadoEm { get; set; }

    }
}
