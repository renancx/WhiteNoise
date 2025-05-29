using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Prontuario;

namespace WhiteNoise.Mappers
{
    public class ProntuariolMapper : Profile
    {
        public ProntuariolMapper()
        {
            //Grid
            CreateMap<Prontuario, ProntuarioGridModel>()
                .ForMember(dest => dest.Paciente, opt => opt.MapFrom(src => src.Paciente.Nome));

            //Form
            CreateMap<ProntuarioFormModel, Prontuario>();

            CreateMap<Prontuario, ProntuarioFormModel>();
        }
    }
}