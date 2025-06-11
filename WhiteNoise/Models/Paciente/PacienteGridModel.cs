using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Paciente
{
    public class PacienteGridModel
    {
        public string? Nome { get; set; }

        [Display(Name = "Data de Nascimento")]
        [HiddenInGrid]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "E-mail")]
        [HiddenInGrid]
        public string? Email { get; set; }

        [Display(Name = "CPF")]
        [HiddenInGrid]
        public string? Cpf { get; set; }

        [HiddenInGrid]
        public bool Ativo { get; set; }

        [Display(Name = "Estado Clínico")]
        public string? EstadoClinico { get; set; }

        [Display(Name = "Tipo de Paciente")]
        public TipoPacienteEnum TipoPaciente { get; set; }

        [Display(Name = "Tipo Sanguíneo")]
        [HiddenInGrid]
        public TipoSanguineoEnum TipoSanguineo { get; set; }

        [HiddenInGrid]
        public SexoEnum Sexo { get; set; }

        public Guid Id { get; set; }
    }
}
