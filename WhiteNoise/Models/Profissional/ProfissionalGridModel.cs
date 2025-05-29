using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Profissional
{
    public class ProfissionalGridModel
    {
        public string? Nome { get; set; }

        public string? Departamento { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        public SexoEnum Sexo { get; set; }

        public Guid Id { get; set; }
    }
}
