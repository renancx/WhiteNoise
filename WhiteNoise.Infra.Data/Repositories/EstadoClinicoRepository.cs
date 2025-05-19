using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class EstadoClinicoRepository : Repository<EstadoClinico>, IEstadoClinicoRepository
    {
        public EstadoClinicoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
