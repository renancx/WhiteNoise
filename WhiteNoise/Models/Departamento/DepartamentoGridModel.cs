using System;
using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Models.Departamento
{
    public class DepartamentoGridModel
    {
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        public Guid Id { get; set; }

    }
}
