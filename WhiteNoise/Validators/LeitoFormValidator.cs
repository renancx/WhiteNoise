using System;
using FluentValidation;
using WhiteNoise.Models.Leito;

namespace WhiteNoise.Validators
{
    public class LeitoFormValidator : AbstractValidator<LeitoFormModel>
    {
        public LeitoFormValidator()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(200).WithMessage("A descrição deve ter no máximo 200 caracteres.");

            RuleFor(x => x.Tipo)
                .IsInEnum().WithMessage("Tipo de leito inválido.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status do leito inválido.");

            RuleFor(x => x.DepartamentoId)
                .NotNull().WithMessage("O departamento é obrigatório.")
                .Must(id => id != Guid.Empty).WithMessage("Departamento inválido.");
        }
    }
}
