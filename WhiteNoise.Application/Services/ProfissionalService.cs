using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Application.Services
{
    public class ProfissionalService : Service<Profissional>, IProfissionalService
    {
        public ProfissionalService(IBaseRepository<Profissional> repository) : base(repository)
        {
        }
    }
}
