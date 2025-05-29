using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class ProntuarioRepository : Repository<Prontuario>, IProntuarioRepository
    {
        public ProntuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Prontuario>> ObterTodos()
        {
            var pacientes = await _context.Prontuario
                .Include(x => x.Paciente)
                .AsNoTracking()
                .ToListAsync();

            return pacientes;
        }

        public override async Task<Prontuario> ObterPorId(Guid? id)
        {
            var paciente = await _context.Prontuario
                .Include(x => x.Paciente)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return paciente;
        }
    }
}