using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Application.Services
{
    public abstract class Service<T> : IBaseService<T> where T : EntityBase
    {

        protected readonly IBaseRepository<T> _repository;

        protected Service(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> ObterPorId(Guid? id)
            => await _repository.ObterPorId(id);

        public virtual async Task<List<T>> ObterTodos()
            => await _repository.ObterTodos();

        public virtual async Task Adicionar(T entity)
        {
            entity.Id = Guid.NewGuid();

            await _repository.Adicionar(entity);
        }

        public virtual async Task Atualizar(T entity)
            => await _repository.Atualizar(entity);

        public virtual async Task Remover(Guid? id) 
            => await _repository.Remover(id);

        public virtual async Task Salvar()
            => await _repository.Salvar();
    }
}
