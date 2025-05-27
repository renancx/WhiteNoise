using System;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Alergia : EntityBase
    {
        public string Nome { get; set; }

        public TipoAlergiaEnum Tipo { get; set; }

        public Guid? ProntuarioId { get; set; }

        public virtual Prontuario? Prontuario { get; set; }
    }
}
