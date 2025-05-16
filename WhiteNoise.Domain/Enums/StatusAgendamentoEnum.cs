using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum StatusAgendamentoEnum
    {
        [Display(Name = "Agendado")]
        Agendado = 1,

        [Display(Name = "Realizado")]
        Realizado = 2,

        [Display(Name = "Cancelado")]
        Cancelado = 3,

        [Display(Name = "Não Compareceu")]
        NoShow = 4,

        [Display(Name = "Reagendado")]
        Reagendado = 5
    }
}