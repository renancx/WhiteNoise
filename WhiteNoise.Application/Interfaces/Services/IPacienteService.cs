using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Application.Interfaces.Services
{
    public interface IPacienteService : IBaseService<Paciente>
    {
        Task<List<Paciente>> ObterPorEstadoClinicoId(Guid? id);
    }
}
