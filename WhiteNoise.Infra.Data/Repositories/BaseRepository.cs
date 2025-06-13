using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public abstract class Repository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> ObterTodos()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> ObterPorId(Guid? id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public virtual async Task Adicionar(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Atualizar(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Remover(Guid? id)
        {
            var entity = await _context.Set<T>().FindAsync(id) ?? throw new KeyNotFoundException("Registro não encontrado.");
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}