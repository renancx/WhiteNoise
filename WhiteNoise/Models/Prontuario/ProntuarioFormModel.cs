using System;
using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Models.Prontuario
{
    public class ProntuarioFormModel
    {
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public string Observacao { get; set; }

        public Guid Id { get; set; }
    }
}
