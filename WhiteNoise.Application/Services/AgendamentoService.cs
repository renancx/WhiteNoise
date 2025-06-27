using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;

namespace WhiteNoise.Application.Services
{
    public class AgendamentoService : Service<Agendamento>, IAgendamentoService
    {
        public AgendamentoService(IBaseRepository<Agendamento> repository) : base(repository)
        {
        }
    }
}