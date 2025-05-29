using AutoMapper;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Models.Departamento;

namespace WhiteNoise.Mappers
{
    public class DepartamentoMapper : Profile
    {
        public DepartamentoMapper()
        {
            CreateMap<DepartamentoFormModel, Departamento>();

            CreateMap<Departamento, DepartamentoFormModel>();

            //Grid
            CreateMap<Departamento, DepartamentoGridModel>(); ;
        }
    }
}
