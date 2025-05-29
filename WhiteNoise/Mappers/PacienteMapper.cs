using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Paciente;

namespace WhiteNoise.Mappers
{
    public class PacienteMapper : Profile
    {
        public PacienteMapper()
        {
            //Grid
            CreateMap<Paciente, PacienteGridModel>()
                .ForMember(dest => dest.EstadoClinico, opt => opt.MapFrom(src => src.EstadoClinico.Descricao));

            CreateMap<PacienteFormModel, Paciente>()
                .ForMember(dest => dest.EstadoClinicoId, opt => opt.MapFrom(src => src.EstadoClinicoId))
                .ForMember(dest => dest.EstadoClinico, opt => opt.Ignore());

            CreateMap<Paciente, PacienteFormModel>();
        }
    }
}