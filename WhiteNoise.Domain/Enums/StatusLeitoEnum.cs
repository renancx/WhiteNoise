using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum StatusLeitoEnum
    {
        [Display(Name = "Livre")]
        Livre = 1,

        [Display(Name = "Ocupado")]
        Ocupado = 2,

        [Display(Name = "Em Manutenção")]
        EmManutencao = 3,

        [Display(Name = "Reservado")]
        Reservado = 4
    }
}