using System;
using WhiteNoise.Domain.Entities.Base;

namespace WhiteNoise.Domain.Entities
{
    public class Prontuario : EntityBase
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public string Observacao { get; set; }

        public Guid? PacienteId { get; set; }

        public virtual Paciente? Paciente { get; set; }
    }
}
