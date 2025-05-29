using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Leito
{
    public class LeitoGridModel
    {
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        public TipoLeitoEnum Tipo { get; set; }

        public StatusLeitoEnum Status { get; set; }

        public string? Departamento { get; set; }

        public Guid Id { get; set; }
    }
}
