using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Profissional
{
    public class ProfissionalViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatória.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        public bool Ativo { get; set; } = true;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        public SexoEnum Sexo { get; set; }

        [HiddenInGrid]
        public Guid? DepartamentoId { get; set; }

        [Display(Name = "Departamento")]
        public string? Departamento { get; set; }

        public Guid Id { get; set; }
    }
}
