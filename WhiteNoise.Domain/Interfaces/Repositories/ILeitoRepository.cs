using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Interfaces.Repositories
{
    public interface ILeitoRepository : IBaseRepository<Leito>
    {
        Task<List<Leito>> ObterTodosPorStatus(StatusLeitoEnum status);

        Task AtualizarStatus(Guid? leitoId, StatusLeitoEnum status);
    }
}
