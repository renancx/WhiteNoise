using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Shared.Helpers
{
    public static class ProfissionalHelper
    {
        public static int ObterTotalizadorProfissionaisAtivos(ApplicationDbContext context)
        {
            return (from profissional in context.Profissional.AsNoTracking().Where(x => x.Ativo == true) select profissional).Count();
        }
    }
}
