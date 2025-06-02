using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Internacao
{
    public class InternacaoFormModel
    {
        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Informe um paciente.")]
        public Guid? PacienteId { get; set; }

        [Display(Name = "Data de Entrada")]
        public DateTime DataEntrada { get; set; } = DateTime.Today;

        [Display(Name = "Leito")]
        [Required(ErrorMessage = "Informe um leito.")]
        public Guid? LeitoId { get; set; }

        [Required(ErrorMessage = "Informe um motivo.")]
        public string Motivo { get; set; }

        [Display(Name = "Data de Alta")]
        public DateTime? DataAlta { get; set; }

        [Display(Name = "Tipo de Saída")]
        public TipoSaidaEnum? TipoSaida { get; set; }

        public Guid Id { get; set; }

        public SelectList? Leitos { get; set; }

        public SelectList? Pacientes { get; set; }

        //Prontuario
        [Display(Name = "Queixa Principal")]
        public string? QueixaPrincipal { get; set; }

        public DateTime? DataCriacao { get; set; }

        [Display(Name = "Observação")]
        [Required(ErrorMessage = "Informe uma observação.")]
        public string Observacao { get; set; }

    }
}
