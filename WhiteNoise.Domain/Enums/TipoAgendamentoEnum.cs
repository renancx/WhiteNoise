using System.ComponentModel.DataAnnotations;

namespace WhiteNoise.Domain.Enums
{
    public enum TipoAgendamentoEnum
    {
        [Display(Name = "Consulta")]
        Consulta = 1,

        [Display(Name = "Exame")]
        Exame = 2,

        [Display(Name = "Cirurgia")]
        Cirurgia = 3,

        [Display(Name = "Retorno")]
        Retorno = 4,

        [Display(Name = "Procedimento")]
        Procedimento = 5,

        [Display(Name = "Triagem")]
        Triagem = 6
    }
}