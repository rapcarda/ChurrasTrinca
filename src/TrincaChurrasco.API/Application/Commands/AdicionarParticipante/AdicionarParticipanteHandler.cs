using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Base;
using TrincaChurrasco.Domain.Interfaces;
using TrincaChurrasco.Domain.Models;

namespace TrincaChurrasco.API.Application.Commands.AdicionarParticipante
{
    public class AdicionarParticipanteHandler : CommandHandlerBase, IRequestHandler<AdicionarParticipanteCommand, ValidationResult>
    {
        private readonly IChurrascoRepository _churrascoRepository;

        public AdicionarParticipanteHandler(IChurrascoRepository churrascoRepository)
        {
            _churrascoRepository = churrascoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarParticipanteCommand request, CancellationToken cancellationToken)
        {
            if (!request.CommandIsValid()) return request.ValidationResult;

            var participacao = await VerificarParticipacao(request);

            if (participacao)
            {
                AdicionarErro($"Participante {request.Nome} já está participando deste churrasco.");
                return ValidationResult;
            }

            var participante = new Participante(request.ChurrascoId, request.Nome, request.Valor);
            request.AggregateId = participante.Id;

            _churrascoRepository.AdicionarParticipante(participante);

            var result = await PersistirDados(_churrascoRepository.UnitOfWork);

            return result;
        }

        private async Task<bool> VerificarParticipacao(AdicionarParticipanteCommand request)
        {
            return await _churrascoRepository.VerificarParticipanteChurrasco(request.ChurrascoId, request.Nome);
        }
    }
}
