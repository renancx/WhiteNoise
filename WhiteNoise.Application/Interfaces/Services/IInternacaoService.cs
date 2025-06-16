using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Application.Interfaces.Services
{
    public interface IInternacaoService : IBaseService<Internacao>
    {
        Task<List<Internacao>> ObterHistorico();

        Task<List<Internacao>> ObterTodasAtivas();

        Task FinalizarPorId(Guid? internacaoId, TipoSaidaEnum tipoSaida, DateTime dataAlta);

    }
}
