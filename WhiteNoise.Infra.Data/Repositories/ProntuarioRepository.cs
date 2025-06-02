using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Interfaces.Repositories;
using WhiteNoise.Infra.Data.Contexts;

namespace WhiteNoise.Infra.Data.Repositories
{
    public class ProntuarioRepository : Repository<Prontuario>, IProntuarioRepository
    {
        public ProntuarioRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}