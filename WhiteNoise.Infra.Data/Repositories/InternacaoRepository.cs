using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class InternacaoRepository : Repository<Internacao>, IInternacaoRepository
    {
        public InternacaoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Internacao>> ObterHistorico()
        {
            var internacoes = await _context.Internacao
                .Include(x => x.Paciente)
                .Include(x => x.Leito)
                .AsNoTracking()
                .ToListAsync();

            return internacoes;
        }

        public async Task<List<Internacao>> ObterTodasAtivas()
        {
            var internacoes = await _context.Internacao
                .Include(x => x.Paciente)
                .Include(x => x.Leito)
                .Where(x => x.Ativa == true)
                .AsNoTracking()
                .ToListAsync();

            return internacoes;
        }

        public override async Task<Internacao> ObterPorId(Guid? id)
        {
            var internacao = await _context.Internacao
                .Include(x => x.Paciente)
                .Include(x => x.Leito)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            return internacao;
        }

        public async Task FinalizarPorId(Guid? internacaoId, TipoSaidaEnum tipoSaida, DateTime dataAlta)
        {
            var internacao = await ObterPorId(internacaoId);

            internacao.TipoSaida = tipoSaida;
            internacao.Ativa = false;
            internacao.DataAlta = dataAlta;

            await Atualizar(internacao);
        }
    }
}