using System;
using System.Collections.Generic;
using System.Text;
using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Application.Services
{
    public class EstadoClinicoService : Service<EstadoClinico>, IEstadoClinicoService
    {
        public EstadoClinicoService(IBaseRepository<EstadoClinico> repository) : base(repository)
        {
        }
    }
}
