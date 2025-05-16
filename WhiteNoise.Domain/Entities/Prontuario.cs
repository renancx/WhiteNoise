using System;
using System.Collections.Generic;
using WhiteNoise.Domain.Entities.Base;

namespace WhiteNoise.Domain.Entities
{
    public class Prontuario : EntityBase
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public IEnumerable<Alergia> Alergias { get; set; }

        public string Observacao { get; set; }
    }
}
