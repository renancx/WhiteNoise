using System;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Internacao
{
    public class InternacaoFormModel
    {
        public DateTime DataEntrada { get; set; } = DateTime.Now;

        public DateTime? DataAlta { get; set; }

        public string Motivo { get; set; }

        public TipoSaidaEnum? TipoSaida { get; set; } = null;

        public Guid Id { get; set; }

    }
}
