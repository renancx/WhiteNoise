using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Application.Services
{
    public class LeitoService : Service<Leito>, ILeitoService
    {
        private readonly ILeitoRepository _leitoRepository;

        public LeitoService(ILeitoRepository leitoRepository) : base(leitoRepository)
        {
            _leitoRepository = leitoRepository;
        }

        public async Task<List<Leito>> ObterTodosPorStatus(StatusLeitoEnum status)
        => await _leitoRepository.ObterTodosPorStatus(status);

        public async Task AtualizarStatus(Guid? leitoId, StatusLeitoEnum status)
            => await _leitoRepository.AtualizarStatus(leitoId, status);

        public async Task<IEnumerable<Leito>> ObterPorStatusOuId(Guid? id, StatusLeitoEnum status)
            => await _leitoRepository.ObterPorStatusOuId(id, status);
    }
}
