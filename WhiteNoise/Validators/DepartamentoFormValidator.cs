using FluentValidation;
using WhiteNoise.Models.Departamento;

namespace WhiteNoise.Validators
{
    public class DepartamentoFormValidator : AbstractValidator<DepartamentoFormModel>
    {
        public DepartamentoFormValidator()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("Informe uma descrição.")
                .MaximumLength(200).WithMessage("A descrição deve ter no máximo 200 caracteres.");
        }
    }
}
