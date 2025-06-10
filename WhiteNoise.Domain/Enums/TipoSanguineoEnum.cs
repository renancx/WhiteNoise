using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum TipoSanguineoEnum
    {
        [Display(Name = "A+")]
        APositivo = 1,

        [Display(Name = "A-")]
        ANegativo = 2,

        [Display(Name = "B+")]
        BPositivo = 3,

        [Display(Name = "B-")]
        BNegativo = 4,

        [Display(Name = "AB+")]
        ABPositivo = 5,

        [Display(Name = "AB-")]
        ABNegativo = 6,

        [Display(Name = "O+")]
        OPositivo = 7,

        [Display(Name = "O-")]
        ONegativo = 8,

        [Display(Name = "Desconhecido")]
        Desconhecido = 9
    }
}