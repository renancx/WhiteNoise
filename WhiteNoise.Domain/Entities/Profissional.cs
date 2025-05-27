using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Profissional : EntityBase
    {
        public string? Nome { get; set; }

        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        public bool Ativo { get; set; } = true;

        public string? Cpf { get; set; }

        public SexoEnum Sexo { get; set; }

        public Guid? AgendamentoId { get; set; }
        public virtual Agendamento? Agendamento { get; set; }
    }
}