using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Application.Services
{
    public class PacienteService : Service<Paciente>, IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository) : base(pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<List<Paciente>> ObterPorEstadoClinicoId(Guid? id)
            => await _pacienteRepository.ObterPorEstadoClinicoId(id);
    }
}
