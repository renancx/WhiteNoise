using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Domain.Entities;
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
