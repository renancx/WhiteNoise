using System;
using System.Collections.Generic;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Paciente : EntityBase
    {
        public string? Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string? Email { get; set; }

        public bool? Ativo { get; set; } = true;

        public bool EmInternacao { get; set; } = false;

        public string? Cpf { get; set; }

        public TipoPacienteEnum TipoPaciente { get; set; }

        public SexoEnum Sexo { get; set; }

        public string? Motivo { get; set; }

        public Guid? EstadoClinicoId { get; set; }

        public virtual EstadoClinico? EstadoClinico { get; set; }

        public virtual ICollection<Internacao> Internacoes { get; set; } = new List<Internacao>();

        public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
