using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhiteNoise.Models.Prontuario
{
    public class ProntuarioFormModel
    {
        public DateTime DataCriacao { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Informe uma observação.")]
        public string Observacao { get; set; }

        [Display(Name = "Queixa Principal")]
        public string? QueixaPrincipal { get; set; }

        public Guid Id { get; set; }
    }
}
