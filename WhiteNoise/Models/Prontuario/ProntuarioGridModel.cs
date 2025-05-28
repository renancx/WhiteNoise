using System;
using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Models.Prontuario
{
    public class ProntuarioGridModel
    {
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [Display(Name = "Observação")]
        public string Observacao { get; set; }

        public string? Paciente { get; set; }

        public Guid Id { get; set; }
    }
}
