using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Alergia
{
    public class AlergiaViewModel
    {
        [Required(ErrorMessage = "O Nome é obrigatório.")]
        public string Nome { get; set; }
        public TipoAlergiaEnum Tipo { get; set; }
        public Guid Id { get; set; }
    }
}
