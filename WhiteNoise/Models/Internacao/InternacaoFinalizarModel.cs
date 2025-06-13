using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Internacao
{
    public class InternacaoFinalizarModel
    {
        public string? Paciente { get; set; }

        [Display(Name = "Data de Entrada")]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Leito")]
        public string? Leito { get; set; }

        public Guid? LeitoId { get; set; }

        public string? Motivo { get; set; }

        [Display(Name = "Data de Alta")]
        [Required(ErrorMessage = "Informe a data de alta.")]
        public DateTime DataAlta { get; set; } = DateTime.Now;

        [Display(Name = "Tipo de Saída")]
        [Required(ErrorMessage = "Informe o tipo de saída.")]
        public TipoSaidaEnum TipoSaida { get; set; }

        public Guid Id { get; set; }
    }
}
