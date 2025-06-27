using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Domain.Interfaces.Repositories
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        Task<List<Paciente>> ObterPorEstadoClinicoId(Guid? id);
    }
}
