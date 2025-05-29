using System;
using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Models.Departamento
{
    public class DepartamentoFormModel
    {
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe uma descrição.")]
        public string? Descricao { get; set; }

        public Guid Id { get; set; }

    }
}
