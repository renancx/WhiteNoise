using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WhiteNoise.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task Salvar();
        Task<List<T>> ObterTodos();
        Task<T> ObterPorId(Guid? id);
        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(Guid? id);
    }
}