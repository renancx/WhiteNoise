using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Internacao
{
    public class InternacaoHistoricoGridModel
    {
        public string? Paciente { get; set; }

        [Display(Name = "Data de Entrada")]
        public DateTime DataEntrada { get; set; }
        
        [Display(Name = "Data de Saída")]
        public DateTime? DataAlta { get; set; }

        public string? Leito { get; set; }

        [HiddenInGrid]
        public string Motivo { get; set; }


        [StyledBoolean(
        TrueClass = "bg-success text-white",
        FalseClass = "bg-secondary text-white",
        TrueText = "Ativas",
        FalseText = "Inativa"
        )]
        public bool Ativa { get; set; }

        [Display(Name = "Tipo de Saída")]
        public TipoSaidaEnum? TipoSaida { get; set; }

        public Guid Id { get; set; }
    }
}
