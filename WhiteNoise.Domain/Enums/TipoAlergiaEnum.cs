using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum TipoAlergiaEnum
    {
        [Display(Name = "Alimentar")]
        Alimentar = 1,

        [Display(Name = "Medicamento")]
        Medicamento = 2,

        [Display(Name = "Ambiental")]
        Ambiental = 3,

        [Display(Name = "Contato")]
        Contato = 4,

        [Display(Name = "Inseto")]
        Inseto = 5,

        [Display(Name = "Latex")]
        Latex = 6,

        [Display(Name = "Outros")]
        Outros = 99
    }
}
