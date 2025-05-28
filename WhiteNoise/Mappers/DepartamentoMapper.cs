using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Agendamento;
using WhiteNoise.Models.Departamento;

namespace WhiteNoise.Mappers
{
    public class DepartamentoMapper : Profile
    {
        public DepartamentoMapper()
        {
            //Grid
            CreateMap<Departamento, DepartamentoGridModel>(); ;
        }
    }
}
