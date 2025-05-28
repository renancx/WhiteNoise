using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;

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

        public Guid Id { get; set; }
    }
}
