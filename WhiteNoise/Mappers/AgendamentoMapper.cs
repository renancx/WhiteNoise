using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Agendamento;

namespace WhiteNoise.Mappers
{
    public class AgendamentoMapper : Profile
    {
        public AgendamentoMapper()
        {
            CreateMap<AgendamentoViewModel, Agendamento>();

            CreateMap<Agendamento, AgendamentoViewModel>()
                .ForMember(x => x.Paciente, opt => opt.MapFrom(src => src.Paciente.Nome));
        }
    }
}
