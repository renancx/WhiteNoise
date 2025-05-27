using System;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Alergia
{
    public class AlergiaViewModel
    {
        public string Nome { get; set; }
        public TipoAlergiaEnum Tipo { get; set; }
        public Guid Id { get; set; }
    }
}
