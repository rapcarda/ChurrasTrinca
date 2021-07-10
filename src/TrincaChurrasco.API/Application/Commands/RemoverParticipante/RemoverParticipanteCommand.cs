using FluentValidation;
using System;
using TrincaChurrasco.API.Application.Base;

namespace TrincaChurrasco.API.Application.Commands.RemoverParticipante
{
    public class RemoverParticipanteCommand : CommandBase
    {
        public Guid ParticipanteId { get; private set; }

        public RemoverParticipanteCommand(Guid participanteId)
        {
            ParticipanteId = participanteId;
        }

        public override bool CommandIsValid()
        {
            ValidationResult = new RemoverParticipanteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RemoverParticipanteCommandValidation : AbstractValidator<RemoverParticipanteCommand>
    {
        public RemoverParticipanteCommandValidation()
        {
            RuleFor(p => p.ParticipanteId)
                .NotEqual(Guid.Empty);
        }
    }
}
