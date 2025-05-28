using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Internacao
{
    public class InternacaoGridModel
    {
        [Display(Name = "Data de Entrada")]
        public DateTime DataEntrada { get; set; }

        public string? Paciente { get; set; }

        public string? Leito { get; set; }

        public Guid Id { get; set; }

    }
}
