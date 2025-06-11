using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WhiteNoise.Domain.Entities;
using WhiteNoise.Domain.Enums;
using WhiteNoise.Shared.Attributes;

namespace WhiteNoise.Models.Paciente
{
    public class PacienteFormModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string? Nome { get; set; }
                
        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [Display(Name = "E-mail")]
        public string? Email { get; set; }

        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [Display(Name = "Tipo de Paciente")]
        [Required(ErrorMessage = "O tipo de paciente é obrigatório.")]
        public TipoPacienteEnum TipoPaciente { get; set; }

        [Display(Name = "Tipo Sanguíneo")]
        [Required(ErrorMessage = "O tipo sanguíneo é obrigatório.")]
        public TipoSanguineoEnum TipoSanguineo { get; set; }

        [Required(ErrorMessage = "O sexo do paciente é obrigatório.")]
        public SexoEnum Sexo { get; set; }

        [Display(Name = "Estado Clínico")]
        public Guid? EstadoClinicoId { get; set; }

        public SelectList? EstadosClinicos { get; set; }

        public Guid Id { get; set; }

    }
}
