using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class AlergiaRepository : Repository<Alergia>, IAlergiaRepository
    {
        public AlergiaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}