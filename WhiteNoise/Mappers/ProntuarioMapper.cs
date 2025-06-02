using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Prontuario;

namespace WhiteNoise.Mappers
{
    public class ProntuariolMapper : Profile
    {
        public ProntuariolMapper()
        {
            //Form
            CreateMap<ProntuarioFormModel, Prontuario>();

            CreateMap<Prontuario, ProntuarioFormModel>();

            //Grid
            CreateMap<ProntuarioGridModel, Prontuario>();

            CreateMap<Prontuario, ProntuarioGridModel>();
        }
    }
}