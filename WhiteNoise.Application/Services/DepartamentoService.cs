using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Application.Services
{
    public class DepartamentoService : Service<Departamento>, IDepartamentoService
    {
        public DepartamentoService(IBaseRepository<Departamento> repository) : base(repository)
        {
        }
    }
}
