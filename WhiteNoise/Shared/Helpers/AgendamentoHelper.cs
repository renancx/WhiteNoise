using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Shared.Helpers
{
    public static class AgendamentoHelper
    {
        public static int ObterTotalizadorAgendamentosPorPeriodo(ApplicationDbContext context, DateTime dataInicio, DateTime dataFinal)
        {
            return (from agendamento in context.Agendamento.AsNoTracking()
                    .Where(x => x.DataHora >= dataInicio && x.DataHora <= dataFinal) select agendamento).Count();
        }
    }
}
