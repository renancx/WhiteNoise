using System;
using System.ComponentModel.DataAnnotations;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;

namespace WhiteNoise.Models.Paciente
{
    public class PacienteGridModel
    {
        public string? Nome { get; set; }
        
        //[HiddenInGrid]
        //public Guid? EstadoClinicoId { get; set; }

        [Display(Name = "Estado Clínico")]
        public string? EstadoClinico { get; set; }
        
        [Display(Name = "Data de Internação")]
        public DateTime DataInternacao { get; set; }

        [Display(Name = "Tipo de Paciente")]
        public TipoPacienteEnum TipoPaciente { get; set; }

        public SexoEnum Sexo { get; set; }

        public Guid Id { get; set; }
    }
}
