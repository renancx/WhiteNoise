using System;
using System.Collections.Generic;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Paciente : Pessoa
    {
        public bool EmInternacao { get; set; } = false;

        public TipoSanguineoEnum TipoSanguineo { get; set; }

        public TipoPacienteEnum TipoPaciente { get; set; }

        public Guid? EstadoClinicoId { get; set; }

        public virtual EstadoClinico? EstadoClinico { get; set; }

        public virtual ICollection<Internacao> Internacoes { get; set; } = new List<Internacao>();

        public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
    }
}
