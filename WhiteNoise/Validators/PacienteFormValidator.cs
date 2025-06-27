using System;
using FluentValidation;
using WhiteNoise.Domain.Utils;
using WhiteNoise.Models.Paciente;

namespace WhiteNoise.Validators
{
    public class PacienteFormValidator : AbstractValidator<PacienteFormModel>
    {
        public PacienteFormValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(ValidarDataNascimento)
                .WithMessage("Data de nascimento inválida.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("Formato de e-mail inválido.")
                .MaximumLength(100).WithMessage("O e-mail deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Must(CpfValidator.IsValid).WithMessage("CPF inválido.");

            RuleFor(x => x.TipoPaciente)
                .IsInEnum().WithMessage("Tipo de paciente inválido.");

            RuleFor(x => x.TipoSanguineo)
                .IsInEnum().WithMessage("Tipo sanguíneo inválido.");

            RuleFor(x => x.Sexo)
                .IsInEnum().WithMessage("Sexo do paciente inválido.");

            RuleFor(x => x.EstadoClinicoId)
                .Must(id => id == null || id != Guid.Empty)
                .WithMessage("Estado clínico inválido.");
        }

        private bool ValidarDataNascimento(DateTime? dataNascimento)
        {
            if (!dataNascimento.HasValue)
                return false;

            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Value.Year;
            if (dataNascimento.Value.Date > hoje.AddYears(-idade))
                idade--;

            return idade >= 0 && idade <= 130;
        }              
    }
}
