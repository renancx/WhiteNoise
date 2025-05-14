using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Domain.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> ObterTodos();
        Task<Paciente> ObterPorId(Guid? id);
        Task<List<Paciente>> ObterPorEstadoClinicoId(Guid? id);
        Task Adicionar(Paciente paciente);
        Task Atualizar(Paciente paciente);
        Task Remover(Guid? id);
    }
}
