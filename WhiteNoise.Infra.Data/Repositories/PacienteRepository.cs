using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class PacienteRepository : Repository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<List<Paciente>> ObterTodos()
        {
            var pacientes = await _context.Paciente
                .Include(x => x.EstadoClinico)
                .AsNoTracking()
                .ToListAsync();

            return pacientes;
        }

        public override async Task<Paciente> ObterPorId(Guid? id)
        {
            var paciente = await _context.Paciente
                .Include(x => x.EstadoClinico)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return paciente;
        }

        public async Task<List<Paciente>> ObterPorEstadoClinicoId(Guid? id)
        {
            var pacientes = await _context.Paciente
                .Include(x => x.EstadoClinico)
                .AsNoTracking()
                .Where(x => x.EstadoClinico.Id == id)
                .OrderBy(x => x.Nome)
                .ToListAsync();

            return pacientes;
        }
    }
}
