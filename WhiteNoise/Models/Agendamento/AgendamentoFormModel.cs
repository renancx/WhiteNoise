using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Agendamento
{
    public class AgendamentoFormModel
    {
        [Display(Name = "Data/Hora")]
        public DateTime DataHora { get; set; } = DateTime.Today;

        public TipoAgendamentoEnum Tipo { get; set; }

        public StatusAgendamentoEnum Status { get; set; }

        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        [Display(Name = "Paciente")]
        [Required(ErrorMessage = "Informe um paciente.")]
        public Guid? PacienteId { get; set; }

        [Display(Name = "Profissional")]
        [Required(ErrorMessage = "Informe um profissional.")]
        public Guid? ProfissionalId { get; set; }

        public Guid Id { get; set; }

        public SelectList? Pacientes { get; set; }

        public SelectList? Profissionais { get; set; }

    }
}
