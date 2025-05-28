using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Agendamento
{
    public class AgendamentoViewModel
    {
        [Display(Name = "Data/Hora")] 
        public DateTime DataHora { get; set; }

        public TipoAgendamentoEnum Tipo { get; set; }

        public StatusAgendamentoEnum Status { get; set; }

        [Display(Name = "Observações")]
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
