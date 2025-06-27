using System;
using FluentValidation;
using WhiteNoise.Models.Internacao;

namespace WhiteNoise.Validators
{
    public class InternacaoFormValidator : AbstractValidator<InternacaoFormModel>
    {
        public InternacaoFormValidator()
        {
            RuleFor(x => x.PacienteId)
                .NotNull().WithMessage("Informe um paciente.")
                .Must(id => id != Guid.Empty).WithMessage("Paciente inválido.");
                        
            RuleFor(x => x.LeitoId)
                .NotNull().WithMessage("Informe um leito.")
                .Must(id => id != Guid.Empty).WithMessage("Leito inválido.");

            RuleFor(x => x.Motivo)
                .NotEmpty().WithMessage("Informe um motivo.")
                .MaximumLength(500).WithMessage("O motivo deve ter no máximo 500 caracteres.");

            RuleFor(x => x.DataAlta)
                .Cascade(CascadeMode.Stop)
                .Must((model, data) => data == null || data >= model.DataEntrada)
                    .WithMessage("A data de alta não pode ser antes da data de entrada.");

            When(x => x.DataAlta.HasValue, () => {
                RuleFor(x => x.TipoSaida)
                    .NotNull().WithMessage("Informe o tipo de saída.")
                    .IsInEnum().WithMessage("Tipo de saída inválido.");
            });

            RuleFor(x => x.QueixaPrincipal)
                .MaximumLength(500).WithMessage("A queixa principal deve ter no máximo 500 caracteres.");

            RuleFor(x => x.DataCriacao)
                .Cascade(CascadeMode.Stop)
                .Must((model, data) => data == null || data >= model.DataEntrada)
                    .WithMessage("A data de criação não pode ser antes da data de entrada.");

            RuleFor(x => x.Observacao)
                .NotEmpty().WithMessage("Informe uma observação.")
                .MaximumLength(1000).WithMessage("A observação deve ter no máximo 1000 caracteres.");
        }
    }
}
