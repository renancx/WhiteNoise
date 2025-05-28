using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Agendamento;

namespace WhiteNoise.Mappers
{
    public class AgendamentoMapper : Profile
    {
        public AgendamentoMapper()
        {
            CreateMap<AgendamentoFormModel, Agendamento>();

            CreateMap<Agendamento, AgendamentoFormModel>();

            //Grid
            CreateMap<Agendamento, AgendamentoGridModel>()
                .ForMember(x => x.Paciente, opt => opt.MapFrom(src => src.Paciente.Nome))
                .ForMember(x => x.Profissional, opt => opt.MapFrom(src => src.Profissional.Nome));
        }
    }
}
