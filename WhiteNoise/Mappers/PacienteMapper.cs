using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Paciente;

namespace WhiteNoise.Mappers
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            CreateMap<PacienteViewModel, Paciente>()
                .ForMember(dest => dest.EstadoClinicoId, opt => opt.MapFrom(src => src.EstadoClinicoId))
                .ForMember(dest => dest.EstadoClinico, opt => opt.Ignore());

            CreateMap<Paciente, PacienteViewModel>()
                .ForMember(dest => dest.EstadoClinicoDescricao, opt => opt.MapFrom(src => src.EstadoClinico.Descricao))
                .ForMember(dest => dest.EstadoClinicoId, opt => opt.MapFrom(src => src.EstadoClinico.Id));
        }
    }
}