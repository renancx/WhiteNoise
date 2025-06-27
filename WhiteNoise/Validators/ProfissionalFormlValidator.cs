using System;
using FluentValidation;
using WhiteNoise.Domain.Utils;
using WhiteNoise.Models.Profissional;

namespace WhiteNoise.Validators
{
    public class ProfissionalFormValidator : AbstractValidator<ProfissionalViewModel>
    {
        public ProfissionalFormValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .MaximumLength(100).WithMessage("O Nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A Data de Nascimento é obrigatória.")
                .Must(ValidarDataNascimento)
                .WithMessage("Data de nascimento inválida. Idade deve ser entre 0 e 130 anos.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O E-mail é obrigatório.")
                .EmailAddress().WithMessage("Formato de E-mail inválido.")
                .MaximumLength(100).WithMessage("O E-mail deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Must(CpfValidator.IsValid)
                .WithMessage("CPF inválido.");

            RuleFor(x => x.Sexo)
                .IsInEnum().WithMessage("Sexo inválido.");

            RuleFor(x => x.DepartamentoId)
                .Must(id => id == null || id != Guid.Empty)
                .WithMessage("Departamento inválido.");
        }

        private bool ValidarDataNascimento(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Year;
            if (dataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade >= 0 && idade <= 130;
        }
    }
}
