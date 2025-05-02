using System;
using System.Collections.Generic;

namespace WhiteNoise.Models.Paciente
{
    public class Paciente
    {
        public Paciente()
        {
            Id = Guid.NewGuid();
            Telefones = new List<Telefone>();
        }

        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public IEnumerable<Telefone> Telefones { get; set; }
    }

    public class Telefone
    {
        public Guid Id { get; set; }

        public string? Tipo { get; set; }

        public string? Numero { get; set; }
    }
}
