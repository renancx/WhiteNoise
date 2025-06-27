using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Agendamento>> ObterTodos()
        {
            var agendamentos = await _context.Agendamento
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .AsNoTracking()
                .ToListAsync();

            return agendamentos;
        }

        public override async Task<Agendamento> ObterPorId(Guid? id)
        {
            var agendamento = await _context.Agendamento
                .Include(x => x.Paciente)
                .Include(x => x.Profissional)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return agendamento;
        }
    }
}