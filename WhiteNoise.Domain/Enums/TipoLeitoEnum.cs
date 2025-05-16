using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum TipoLeitoEnum
    {
        [Display(Name = "Enfermaria")]
        Enfermaria = 1,

        [Display(Name = "UTI")]
        UTI = 2,

        [Display(Name = "Isolamento")]
        Isolamento = 3,

        [Display(Name = "Pediatria")]
        Pediatria = 4,

        [Display(Name = "Quarto Privativo")]
        QuartoPrivativo = 5
    }
}