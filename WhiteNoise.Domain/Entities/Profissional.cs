using System;
using System.Collections.Generic;

namespace WhiteNoise.Domain.Entities
{
    public class Profissional : Pessoa
    {
        public string? RegistroProfissional { get; set; }

        public Guid? DepartamentoId { get; set; }
        public virtual Departamento? Departamento { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
    }
}