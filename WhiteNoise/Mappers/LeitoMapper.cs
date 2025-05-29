using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Leito;

namespace WhiteNoise.Mappers
{
    public class LeitoMapper : Profile
    {
        public LeitoMapper()
        {
            //Grid
            CreateMap<Leito, LeitoGridModel>()
                .ForMember(x => x.Departamento, opt => opt.MapFrom(src => src.Departamento.Descricao));

            //Form
            CreateMap<LeitoFormModel, Leito>();

            CreateMap<Leito, LeitoFormModel>();
        }
    }
}
