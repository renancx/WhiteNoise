using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Shared.Helpers
{
    public static class LeitoHelper
    {
        public static int ObterTotalizadorLeitos(ApplicationDbContext context)
        {
            return (from leito in context.Leito.AsNoTracking() select leito).Count();
        }

        public static int ObterTotalLeitosPorStatus(ApplicationDbContext context, StatusLeitoEnum status)
        {
            return context.Leito.AsNoTracking().Count(x => x.Status == status);
        }

        public static Internacao ObterInternacaoDoLeito(ApplicationDbContext context, Guid? leitoId)
        {
            var internacao = context.Internacao
                .Include(x => x.Paciente)
                .Include(x => x.Paciente.EstadoClinico)
                .Where(x => x.LeitoId == leitoId)
                .FirstOrDefault();

            return internacao;
        }
    }
}
