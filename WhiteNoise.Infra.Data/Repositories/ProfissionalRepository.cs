using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class ProfissionalRepository : Repository<Profissional>, IProfissionalRepository
    {
        public ProfissionalRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Profissional>> ObterTodos()
        {
            var profissionais = await _context.Profissional
                .Include(x => x.Departamento)
                .AsNoTracking()
                .ToListAsync();

            return profissionais;
        }

        public override async Task<Profissional> ObterPorId(Guid? id)
        {
            var profissional = await _context.Profissional
                .Include(x => x.Departamento)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return profissional;
        }
    }
}