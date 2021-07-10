using FluentValidation;
using System;
using TrincaChurrasco.API.Application.Base;

namespace TrincaChurrasco.API.Application.Commands.AdicionarParticipante
{
    public class AdicionarParticipanteCommand : CommandBase
    {
        public Guid ChurrascoId { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        public AdicionarParticipanteCommand(Guid churrascoId, string nome, decimal valor)
        {
            ChurrascoId = churrascoId;
            Nome = nome;
            Valor = valor;
        }

        public override bool CommandIsValid()
        {
            ValidationResult = new AdicionarParticipanteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarParticipanteCommandValidation : AbstractValidator<AdicionarParticipanteCommand>
    {
        public AdicionarParticipanteCommandValidation()
        {
            RuleFor(p => p.ChurrascoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Churrasco inválido.");

            RuleFor(p => p.Nome)
                .NotNull()
                .WithMessage("Nome inválido.");

            RuleFor(p => p.Valor)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("Valor inválido.");
        }
    }
}
