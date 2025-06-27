using System;
using FluentValidation;
using WhiteNoise.Models.Paciente;

namespace WhiteNoise.Validators
{
    public class PacienteFormValidator : AbstractValidator<PacienteFormModel>
    {
        public PacienteFormValidator()
        {
            RuleFor(x => x.DataNascimento)
                .Must(ValidarDataNascimento)
                .WithMessage("Data de nascimento inválida");
        }

        private bool ValidarDataNascimento(DateTime? dataNascimento)
        {
            if (!dataNascimento.HasValue)
                return false;

            var idade = DateTime.Today.Year - dataNascimento.Value.Year;

            if (dataNascimento.Value > DateTime.Today.AddYears(-idade))
                idade--;

            return idade >= 0 && idade <= 130;
        }
    }

}
