using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Internacao;

namespace WhiteNoise.Mappers
{
    public class InternacaoMapper : Profile
    {
        public InternacaoMapper()
        {
            //ViewModel
            CreateMap<InternacaoViewModel, Internacao>();

            CreateMap<Internacao, InternacaoViewModel>();

            //Grid
            CreateMap<Internacao, InternacaoGridModel>()
                .ForMember(x => x.Paciente, opt => opt.MapFrom(src => src.Paciente.Nome))
                .ForMember(x => x.Leito, opt => opt.MapFrom(src => src.Leito.Descricao));

            //Form
            CreateMap<InternacaoFormModel, Internacao>()
                .IncludeMembers(src => src)
                .ForMember(d => d.Prontuario, opt => opt.Ignore());

            CreateMap<InternacaoFormModel, Prontuario>();

            CreateMap<Internacao, InternacaoFormModel>();

            //Finalizar
            CreateMap<InternacaoFinalizarModel, Internacao>();

            CreateMap<Internacao, InternacaoFinalizarModel>()
                .ForMember(x => x.Paciente, opt => opt.MapFrom(src => src.Paciente.Nome));

        }
    }
}
