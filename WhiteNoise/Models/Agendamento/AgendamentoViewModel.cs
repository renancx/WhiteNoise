using System;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Agendamento
{
    public class AgendamentoViewModel
    {
        public DateTime DataHora { get; set; }

        public TipoAgendamentoEnum Tipo { get; set; }

        public StatusAgendamentoEnum Status { get; set; }

        public string? Observacoes { get; set; }

        [HiddenInGrid]
        public Guid? PacienteId { get; set; }
        
        public string Paciente { get; set; }

        [HiddenInGrid]
        public Guid? ProfissionalId { get; set; }

        public string Profissional { get; set; }

        public Guid Id { get; set; }

    }
}
