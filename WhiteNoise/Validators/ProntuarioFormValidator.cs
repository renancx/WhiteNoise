using System;
using FluentValidation;
using WhiteNoise.Models.Prontuario;

namespace WhiteNoise.Validators
{
    public class ProntuarioFormValidator : AbstractValidator<ProntuarioFormModel>
    {
        public ProntuarioFormValidator()
        {
            RuleFor(x => x.Observacao)
                .NotEmpty().WithMessage("Informe uma observação.")
                .MaximumLength(1000).WithMessage("A observação deve ter no máximo 1000 caracteres.");

            RuleFor(x => x.QueixaPrincipal)
                .MaximumLength(500).WithMessage("A queixa principal deve ter no máximo 500 caracteres.");
        }
    }
}
