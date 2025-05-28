using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Paciente
{
    public class PacienteFormModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string? Nome { get; set; }
        
        [HiddenInGrid]
        public Guid? EstadoClinicoId { get; set; }

        [Display(Name = "Estado Clínico")]
        public string? EstadoClinico { get; set; }
        
        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "A Data de Internação é obrigatória.")]
        [Display(Name = "Data de Internação")]
        public DateTime DataInternacao { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        [HiddenInGrid]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [Display(Name = "Tipo de Paciente")]
        public TipoPacienteEnum TipoPaciente { get; set; }

        public SexoEnum Sexo { get; set; }

        [HiddenInGrid]
        public string? Motivo { get; set; }

        public Guid Id { get; set; }

        [HiddenInGrid]
        public Guid? ProntuarioId { get; set; }

        [HiddenInGrid]
        public Guid? AgendamentoId { get; set; }

        [HiddenInGrid]
        public Guid? InternacaoId { get; set; }
    }
}
