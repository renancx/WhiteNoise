using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Application.Interfaces.Services
{
    public interface ILeitoService : IBaseService<Leito>
    {
        Task<List<Leito>> ObterTodosPorStatus(StatusLeitoEnum status);

        Task AtualizarStatus(Guid? leitoId, StatusLeitoEnum status);

        Task<IEnumerable<Leito>> ObterPorStatusOuId(Guid? id, StatusLeitoEnum status);
    }
}
