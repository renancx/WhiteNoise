using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Domain.Interfaces.Repositories
{
    public interface IInternacaoRepository : IBaseRepository<Internacao>
    {
        Task<List<Internacao>> ObterTodasAtivas();
    }
}
