using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class InternacaoRepository : Repository<Internacao>, IInternacaoRepository
    {
        public InternacaoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Internacao>> ObterTodos()
        {
            var leitos = await _context.Internacao
                .Include(x => x.Paciente)
                .Include(x => x.Leito)
                .AsNoTracking()
                .ToListAsync();

            return leitos;
        }

        public override async Task<Internacao> ObterPorId(Guid? id)
        {
            var leito = await _context.Internacao
                .Include(x => x.Paciente)
                .Include(x => x.Leito)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return leito;
        }
    }
}