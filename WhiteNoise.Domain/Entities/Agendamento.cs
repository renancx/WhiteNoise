using System;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Agendamento : EntityBase
    {
        public DateTime DataHora { get; set; }

        public TipoAgendamentoEnum Tipo { get; set; }

        public StatusAgendamentoEnum Status { get; set; }

        public string? Observacoes { get; set; }

        public Guid? ProfissionalId { get; set; }

        public virtual Profissional Profissional { get; set; }

        public Guid? PacienteId { get; set; }

        public virtual Paciente Paciente { get; set; }
    }
}
