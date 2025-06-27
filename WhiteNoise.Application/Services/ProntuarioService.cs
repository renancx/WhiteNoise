using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Application.Services
{
    public class ProntuarioService : Service<Prontuario>, IProntuarioService
    {
        public ProntuarioService(IBaseRepository<Prontuario> repository) : base(repository)
        {
        }
    }
}
