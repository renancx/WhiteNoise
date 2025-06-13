using System;
using System.Collections.Generic;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Leito : EntityBase
    {
        public string? Descricao { get; set; }

        public TipoLeitoEnum Tipo { get; set; }

        public StatusLeitoEnum Status { get; set; }

        public Guid? DepartamentoId { get; set; }

        public virtual Departamento? Departamento { get; set; }

        public virtual ICollection<Internacao>? Internacoes { get; set; }
    }
}
