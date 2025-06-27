using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities.Base;

namespace WhiteNoise.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        Task Salvar();
        Task<List<T>> ObterTodos();
        Task<T> ObterPorId(Guid? id);
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(Guid? id);
    }
}