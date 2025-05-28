using System;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Leito
{
    public class LeitoFormModel
    {
        public string? Descricao { get; set; }

        public TipoLeitoEnum Tipo { get; set; }

        public StatusLeitoEnum Status { get; set; }

        public Guid Id { get; set; }
    }
}
