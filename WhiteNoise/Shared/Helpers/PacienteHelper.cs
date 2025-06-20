using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Shared.Helpers
{
    public static class PacienteHelper
    {
        public static int ObterTotalizadorPacientesAtivos(ApplicationDbContext context)
        {
            return (from paciente in context.Paciente.AsNoTracking().Where(x => x.Ativo == true) select paciente).Count();
        }
    }
}
