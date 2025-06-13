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
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string? Descricao { get; set; }

        public TipoLeitoEnum Tipo { get; set; }

        public StatusLeitoEnum Status { get; set; } = StatusLeitoEnum.Livre;

        [HiddenInGrid]
        [Required(ErrorMessage = "O departamento é obrigatório.")]
        [Display(Name = "Departamento")]
        public Guid? DepartamentoId { get; set; }

        public SelectList? Departamentos { get; set; }

        public Guid Id { get; set; }
    }
}
