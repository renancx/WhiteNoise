using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Agendamento
{
    public class AgendamentoGridModel
    {
        public string Profissional { get; set; }

        public TipoAgendamentoEnum Tipo { get; set; }

        [Display(Name = "Data/Hora")] 
        public DateTime DataHora { get; set; }

        public StatusAgendamentoEnum Status { get; set; }
        
        public string Paciente { get; set; }

        [HiddenInGrid]
        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        public Guid Id { get; set; }
    }
}