using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Alergia;

namespace WhiteNoise.Mappers
{
    public class AlergiaMapper : Profile
    {
        public AlergiaMapper()
        {
            CreateMap<AlergiaViewModel, Alergia>();

            CreateMap<Alergia, AlergiaViewModel>();
        }
    }
}
