using System.ComponentModel;

namespace WhiteNoise.Domain.Entities
{
    public enum TipoPacienteEnum
    {
        [Description("Conveniado")]
        Conveniado = 1,

        [Description("Particular")]
        Particular = 2,

        [Description("Outros")]
        Outros = 99
    }
}