using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Application.Services
{
    public class InternacaoService : Service<Internacao>, IInternacaoService
    {
        private readonly IInternacaoRepository _internacaoRepository;

        public InternacaoService(IInternacaoRepository internacaoRepository)
            : base(internacaoRepository)
        {
            _internacaoRepository = internacaoRepository;
        }

        public async Task<List<Internacao>> ObterHistorico()
            => await _internacaoRepository.ObterHistorico();

        public async Task<List<Internacao>> ObterTodasAtivas()
            => await _internacaoRepository.ObterTodasAtivas();

        public async Task FinalizarPorId(Guid? internacaoId, TipoSaidaEnum tipoSaida, DateTime dataAlta)
            => await _internacaoRepository.FinalizarPorId(internacaoId, tipoSaida, dataAlta);
    }
}