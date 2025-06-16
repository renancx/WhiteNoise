using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Application.Interfaces.Repositories
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Task<List<Paciente>> ObterPorEstadoClinicoId(Guid? id);
    }
}
