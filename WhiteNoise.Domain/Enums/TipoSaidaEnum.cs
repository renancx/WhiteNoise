using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum TipoSaidaEnum
    {
        [Display(Name = "Recebeu alta")]
        Alta = 1,

        [Display(Name = "Transferido")]
        Transferido = 2,

        [Display(Name = "Saiu à Revelia")]
        Revelia = 3,

        [Display(Name = "Veio a Óbito")]
        Obito = 4,

        [Display(Name = "Outros")]
        Outros = 99
    }
}
