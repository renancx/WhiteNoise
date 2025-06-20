using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Shared.Helpers
{
    public static class InternacaoHelper
    {
        public static int ObterTotalizadorInternacoesAtivas(ApplicationDbContext context)
        {
            return (from internacao in context.Internacao.AsNoTracking().Where(x => x.Ativa == true) select internacao).Count();
        }
    }
}
