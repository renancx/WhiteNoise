using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class LeitoRepository : Repository<Leito>, ILeitoRepository
    {
        public LeitoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Leito>> ObterTodos()
        {
            var leitos = await _context.Leito
                .Include(x => x.Departamento)
                .AsNoTracking()
                .ToListAsync();

            return leitos;
        }

        public override async Task<Leito> ObterPorId(Guid? id)
        {
            var leito = await _context.Leito
                .Include(x => x.Departamento)
                .FirstOrDefaultAsync(x => x.Id == id);

            return leito;
        }

        public async Task<List<Leito>> ObterTodosPorStatus(StatusLeitoEnum status)
        {
            var leitos = await _context.Leito
                .Include(x => x.Departamento)
                .Where(x => x.Status == status)
                .AsNoTracking()
                .ToListAsync();

            return leitos;
        }

        public async Task AtualizarStatus(Guid? leitoId, StatusLeitoEnum status)
        {
            var leito = await ObterPorId(leitoId);

            leito.Status = status;
        }

        public async Task<IEnumerable<Leito>> ObterPorStatusOuId(Guid? id, StatusLeitoEnum status)
        {
            return await _context.Leito
                .Where(l => l.Status == status || l.Id == id)
                .ToListAsync();
        }
    }
}