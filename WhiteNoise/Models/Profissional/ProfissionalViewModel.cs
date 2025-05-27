using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Profissional
{
    public class ProfissionalViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        public string? Cpf { get; set; }

        public SexoEnum Sexo { get; set; }

        public Guid Id { get; set; }

        [HiddenInGrid]
        public Guid? AgendamentoId { get; set; }
    }
}
