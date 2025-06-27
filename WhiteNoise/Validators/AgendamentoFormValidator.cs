using System;
using FluentValidation;
using WhiteNoise.Models.Agendamento;

namespace WhiteNoise.Validators
{
    public class AgendamentoFormValidator : AbstractValidator<AgendamentoFormModel>
    {
        public AgendamentoFormValidator()
        {
            RuleFor(x => x.Tipo)
                .IsInEnum().WithMessage("Tipo de agendamento inválido.");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Status de agendamento inválido.");

            RuleFor(x => x.Observacoes)
                .MaximumLength(1000).WithMessage("As observações devem ter no máximo 1000 caracteres.");

            RuleFor(x => x.PacienteId)
                .NotNull().WithMessage("Informe um paciente.")
                .Must(id => id != Guid.Empty).WithMessage("Paciente inválido.");

            RuleFor(x => x.ProfissionalId)
                .NotNull().WithMessage("Informe um profissional.")
                .Must(id => id != Guid.Empty).WithMessage("Profissional inválido.");
        }
    }
}
