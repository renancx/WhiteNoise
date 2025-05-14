using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Paciente;

namespace WhiteNoise.Mappers
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<Paciente, PacienteViewModel>();
        }
    }
}
