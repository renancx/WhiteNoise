using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class LeitoRepository : Repository<Leito>, ILeitoRepository
    {
        public LeitoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}