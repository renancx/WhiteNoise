using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Application.Services
{
    public class EstadoClinicoService : Service<EstadoClinico>, IEstadoClinicoService
    {
        public EstadoClinicoService(IBaseRepository<EstadoClinico> repository) : base(repository)
        {
        }
    }
}
