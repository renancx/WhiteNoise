using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Domain.Interfaces.Repositories
{
    public interface IEstadoClinicoRepository
    {
        Task<List<EstadoClinico>> ObterTodos();
        Task<EstadoClinico> ObterPorId(Guid? id);
        Task Adicionar(EstadoClinico estadoClinico);
        Task Atualizar(EstadoClinico estadoClinico);
        Task Remover(Guid? id);
    }
}
