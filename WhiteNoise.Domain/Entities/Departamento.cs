using WhiteNoise.Domain.Entities.Base;

namespace WhiteNoise.Domain.Entities
{
    public class Departamento : EntityBase
    {
        public string? Descricao { get; set; }

        public Leito Leito { get; set; }

        public Profissional Profissional { get; set; }
    }
}