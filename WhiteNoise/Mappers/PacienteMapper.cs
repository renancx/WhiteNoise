using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Paciente;

namespace WhiteNoise.Mappers
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<PacienteViewModel, Paciente>();

            CreateMap<Paciente, PacienteViewModel>()
                .ForMember(dest => dest.EstadoClinicoDescricao,
                           opt => opt.MapFrom(src => src.EstadoClinico.Descricao));
        }
    }
}
