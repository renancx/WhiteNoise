using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum SexoEnum
    {
        [Display(Name = "Masculino")]
        Masculino = 1,

        [Display(Name = "Feminino")]
        Feminino = 2
    }
}
