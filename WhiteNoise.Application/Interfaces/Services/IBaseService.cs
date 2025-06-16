using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities.Base;

namespace WhiteNoise.Application.Interfaces.Services
{
    public interface IBaseService<T> where T : EntityBase
    {
        Task<T> ObterPorId(Guid? id);
        Task<List<T>> ObterTodos();

        Task Adicionar(T entity);
        Task Atualizar(T entity);
        Task Remover(Guid? id);

        Task Salvar();
    }
}