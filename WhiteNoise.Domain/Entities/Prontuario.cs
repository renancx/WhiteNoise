using System;
using WhiteNoise.Domain.Entities.Base;

namespace WhiteNoise.Domain.Entities
{
    public class Prontuario : EntityBase
    {
        public string? QueixaPrincipal {  get; set; }

        public DateTime DataCriacao { get; set; }

        public string Observacao { get; set; }
    }
}
