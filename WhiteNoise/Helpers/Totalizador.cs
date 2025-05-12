using Microsoft.EntityFrameworkCore;
using WhiteNoise.Infra.Data.Contexts;
using System.Linq;

namespace WhiteNoise.Helpers
{
    public static class Totalizador
    {
        public static int ObterTotalizadorPaciente(ApplicationDbContext context)
        {
            //return (from paciente in context.Paciente.AsNoTracking() select paciente).Count();
            return (from paciente in context.EstadoClinico.AsNoTracking() select paciente).Count();
        }

        public static decimal ObterTotalPacientesPorEstadoClinico(ApplicationDbContext context, string estadoClinico)
        {
            //return context.Paciente.AsNoTracking().Count(x => x.EstadoClinico.Descricao.ToLower().Contains(estadoClinico.ToLower()));
            return context.EstadoClinico.AsNoTracking().Count(x => x.Descricao.ToLower().Contains(estadoClinico.ToLower()));
        }
    }
}
