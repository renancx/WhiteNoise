using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Paciente : EntityBase
    {
        public Paciente()
        {
            Ativo = true;
        }

        public Guid EstadoClinicoId { get; set; }

        [Display(Name = "Estado Clínico")]
        public virtual EstadoClinico EstadoClinico { get; set; }

        public string? Nome { get; set; }

        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Data Internação")]
        public DateTime DataInternacao { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        public bool Ativo { get; set; }

        public string? Cpf { get; set; }

        [Display(Name = "Tipo Paciente")]
        public TipoPacienteEnum TipoPaciente { get; set; }

        public SexoEnum Sexo { get; set; }

        public string? Motivo { get; set; }
    }
}
