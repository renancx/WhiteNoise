using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum TipoSaidaEnum
    {
        [Display(Name = "Recebeu alta")]
        [Description("Recebeu alta")]
        Alta = 1,

        [Description("Transferido")]
        [Display(Name = "Recebeu alta")]
        Transferido = 2,

        [Description("Saiu à Revelia")]
        [Display(Name = "Recebeu alta")]
        Revelia = 3,

        [Description("Veio a Óbito")]
        [Display(Name = "Recebeu alta")]
        Obito = 4,

        [Description("Outros")]
        [Display(Name = "Recebeu alta")]
        Outros = 99
    }
}
