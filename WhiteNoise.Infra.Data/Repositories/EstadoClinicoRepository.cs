using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class EstadoClinicoRepository : IEstadoClinicoRepository
    {
        #region Private Fields
        private readonly ApplicationDbContext _context;

        #endregion

        #region Constructors
        public EstadoClinicoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region CRUD Operations
        public async Task Adicionar(EstadoClinico estadoClinico)
        {
            await _context.EstadoClinico.AddAsync(estadoClinico);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(EstadoClinico estadoClinico)
        {
            _context.EstadoClinico.Update(estadoClinico);
            await _context.SaveChangesAsync();
        }

        public async Task Remover(Guid? id)
        {
            var estadoClinico = await _context.EstadoClinico.FindAsync(id) ?? throw new KeyNotFoundException("Registro não encontrado.");
            _context.EstadoClinico.Remove(estadoClinico);
            await _context.SaveChangesAsync();
        }

        #endregion

        public async Task<EstadoClinico> ObterPorId(Guid? id)
        {
            var estadoClinico = await _context.EstadoClinico.FirstOrDefaultAsync(x => x.Id == id);
            return estadoClinico;
        }

        public async Task<List<EstadoClinico>> ObterTodos()
        {
            var estadosClinicos = await _context.EstadoClinico.ToListAsync();
            return estadosClinicos;
        }
    }
}
