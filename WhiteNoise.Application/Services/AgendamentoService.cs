using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Application.Services
{
    public class AgendamentoService : Service<Agendamento>, IAgendamentoService
    {
        public AgendamentoService(IBaseRepository<Agendamento> repository) : base(repository)
        {
        }
    }
}