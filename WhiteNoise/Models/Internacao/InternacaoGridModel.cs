using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Internacao
{
    public class InternacaoGridModel
    {
        public string? Paciente { get; set; }

        [Display(Name = "Data de Entrada")]
        public DateTime DataEntrada { get; set; }
        
        public string? Leito { get; set; }

        [HiddenInGrid]
        public string Motivo { get; set; }

        [HiddenInGrid]
        public DateTime? DataAlta { get; set; }

        [HiddenInGrid]
        public TipoSaidaEnum? TipoSaida { get; set; }

        public Guid Id { get; set; }

    }
}
