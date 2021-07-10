using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Base;
using TrincaChurrasco.Domain.Interfaces;

namespace TrincaChurrasco.API.Application.Commands.RemoverParticipante
{
    public class RemoverParticipanteCommandHandler : CommandHandlerBase, IRequestHandler<RemoverParticipanteCommand, ValidationResult>
    {
        private readonly IChurrascoRepository _churrascoRepository;

        public RemoverParticipanteCommandHandler(IChurrascoRepository churrascoRepository)
        {
            _churrascoRepository = churrascoRepository;
        }

        public async Task<ValidationResult> Handle(RemoverParticipanteCommand request, CancellationToken cancellationToken)
        {
            if (!request.CommandIsValid()) return request.ValidationResult;

            var participante = await _churrascoRepository.ObterParticipantePorId(request.ParticipanteId);

            if (participante == null)
            {
                AdicionarErro("404 - Not Found");
                return ValidationResult;
            }

            _churrascoRepository.RemoverParticipante(participante);

            var result = await PersistirDados(_churrascoRepository.UnitOfWork);

            return result;
        }
    }
}
