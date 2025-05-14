using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        #region Private Fields
        private readonly ApplicationDbContext _context;

        #endregion

        #region Constructors
        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Operations
        public async Task Adicionar(Paciente paciente)
        {
            await _context.Paciente.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Paciente paciente)
        {
            _context.Paciente.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Guid? id)
        {
            var paciente = await _context.Paciente.FindAsync(id) ?? throw new KeyNotFoundException("Registro não encontrado.");
            _context.Paciente.Remove(paciente);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Queries
        public async Task<List<Paciente>> ObterTodos()
        {
            var pacientes = await _context.Paciente
                .Include(x => x.EstadoClinico)
                .AsNoTracking()
                .ToListAsync();

            return pacientes;
        }

        public async Task<Paciente> ObterPorId(Guid? id)
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

        #endregion
    }
}
