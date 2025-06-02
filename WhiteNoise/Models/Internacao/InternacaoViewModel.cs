using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Internacao
{
    public class InternacaoViewModel
    {
        [Display(Name = "Data de Entrada")]
        public DateTime DataEntrada { get; set; } = DateTime.Today;

        [Display(Name = "Data de Alta")]
        public DateTime? DataAlta { get; set; }

        [Required(ErrorMessage = "Informe um motivo.")]
        public string Motivo { get; set; }

        [Display(Name = "Tipo de Saída")]
        public TipoSaidaEnum? TipoSaida { get; set; } = null;

        public Guid Id { get; set; }

        [Display(Name = "Prontuário")]
        [Required(ErrorMessage = "Informe um prontuário.")]
        public Guid? ProntuarioId { get; set; }

        [Display(Name = "Leito")]
        [Required(ErrorMessage = "Informe um leito.")]
        public Guid? LeitoId { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Informe um paciente.")]
        public Guid? PacienteId { get; set; }

        public SelectList? Leitos { get; set; }

        public SelectList? Pacientes { get; set; }
    }
}
