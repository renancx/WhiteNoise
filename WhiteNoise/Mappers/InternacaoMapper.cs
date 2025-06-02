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
            CreateMap<InternacaoFormModel, Prontuario>()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<InternacaoFormModel, Internacao>()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Internacao, InternacaoFormModel>()
               .ForAllOtherMembers(opt => opt.Ignore());

        }
    }
}
