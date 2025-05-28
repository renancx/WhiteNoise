using System;
using System.Collections.Generic;
using WhiteNoise.Domain.Entities.Base;

namespace WhiteNoise.Domain.Entities
{
    public class Departamento : EntityBase
    {
        public string? Descricao { get; set; }

        public virtual ICollection<Leito> Leitos { get; set; } = new List<Leito>();

        public virtual ICollection<Profissional> Profissionais { get; set; } = new List<Profissional>();
    }
}