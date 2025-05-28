using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class InternacaoRepository : Repository<Internacao>, IInternacaoRepository
    {
        public InternacaoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}