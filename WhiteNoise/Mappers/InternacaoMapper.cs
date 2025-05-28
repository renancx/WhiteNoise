using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Internacao;

namespace WhiteNoise.Mappers
{
    public class InternacaoMapper : Profile
    {
        public InternacaoMapper()
        {
            //Grid
            CreateMap<Internacao, InternacaoGridModel>()
                .ForMember(x => x.Paciente, opt => opt.MapFrom(src => src.Paciente.Nome))
                .ForMember(x => x.Leito, opt => opt.MapFrom(src => src.Leito.Descricao));
        }
    }
}
