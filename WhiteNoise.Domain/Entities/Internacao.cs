﻿using System;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Internacao : EntityBase
    {
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        public DateTime? DataAlta { get; set; }

        public string Motivo { get; set; }

        public TipoSaidaEnum? TipoSaida { get; set; } = null;

        public bool Ativa { get; set; } = true;

        public Guid? PacienteId { get; set; }

        public virtual Paciente Paciente { get; set; }

        public Guid? LeitoId { get; set; }

        public virtual Leito? Leito { get; set; }

        public Guid? ProntuarioId { get; set; }

        public virtual Prontuario? Prontuario { get; set; }
    }
}
