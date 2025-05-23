using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Profissional;

namespace WhiteNoise.Mappers
{
    public class ProfissionalMapper : Profile
    {
        public ProfissionalMapper()
        {
            CreateMap<ProfissionalViewModel, Profissional>();

            CreateMap<Profissional, ProfissionalViewModel>();
        }
    }
}