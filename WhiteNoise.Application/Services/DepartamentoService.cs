using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Application.Services
{
    public class DepartamentoService : Service<Departamento>, IDepartamentoService
    {
        public DepartamentoService(IBaseRepository<Departamento> repository) : base(repository)
        {
        }
    }
}
