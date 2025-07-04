﻿using System;
using System.Collections.Generic;
using WhiteNoise.Domain.Entities.Base;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Domain.Entities
{
    public class Pessoa : EntityBase
    {
        public string? Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string? Email { get; set; }

        public bool? Ativo { get; set; } = true;

        public string? Cpf { get; set; }

        public SexoEnum Sexo { get; set; }
    }
}
