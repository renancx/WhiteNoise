using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Leito
{
    public class LeitoFormModel
    {
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        public TipoLeitoEnum Tipo { get; set; }

        public StatusLeitoEnum Status { get; set; }

        [HiddenInGrid]
        public Guid? DepartamentoId { get; set; }

        public SelectList? Departamentos { get; set; }

        public Guid Id { get; set; }
    }
}
