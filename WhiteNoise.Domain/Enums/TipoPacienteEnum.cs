using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Entities
{
    public enum TipoPacienteEnum
    {
        [Display(Name = "Conveniado")]
        Conveniado = 1,

        [Display(Name = "Particular")]
        Particular = 2,

        [Display(Name = "Outros")]
        Outros = 99
    }
}