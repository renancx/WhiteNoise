using System;
using WhiteNoise.Domain.Entities.Base;

namespace WhiteNoise.Domain.Entities
{
    public class Departamento : EntityBase
    {
        public string? Descricao { get; set; }

        public Guid? LeitoId { get; set; }

        public virtual Leito Leito { get; set; }
        
        public Guid? ProfissionalId { get; set; }
        
        public virtual Profissional? Profissional { get; set; }
    }
}