using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class ProntuarioRepository : Repository<Prontuario>, IProntuarioRepository
    {
        public ProntuarioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}