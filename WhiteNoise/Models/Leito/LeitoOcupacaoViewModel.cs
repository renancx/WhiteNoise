using System;
using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Models.Leito
{
    public class LeitoOcupacaoViewModel
    {
        public string? Paciente { get; set; }

        [Display(Name = "Data de Entrada")]
        public DateTime DataEntrada { get; set; }

        public string? EstadoClinico { get; set; }
    }
}