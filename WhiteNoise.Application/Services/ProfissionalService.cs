using System;
using System.Collections.Generic;
using System.Text;
using WhiteNoise.Application.Interfaces.Repositories;
using WhiteNoise.Application.Interfaces.Services;
using WhiteNoise.Domain.Entities;

namespace WhiteNoise.Application.Services
{
    public class ProfissionalService : Service<Profissional>, IProfissionalService
    {
        public ProfissionalService(IBaseRepository<Profissional> repository) : base(repository)
        {
        }
    }
}
