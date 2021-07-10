using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Base;
using TrincaChurrasco.Domain.Interfaces;
using TrincaChurrasco.Domain.Models;

namespace TrincaChurrasco.API.Application.Commands.CriarChurrasco
{
    public class CriarChurrascoHandler : CommandHandlerBase, IRequestHandler<CriarChurrascoCommand, ValidationResult>
    {
        private readonly IChurrascoRepository _churrascoRepository;

        public CriarChurrascoHandler(IChurrascoRepository churrascoRepository)
        {
            _churrascoRepository = churrascoRepository;
        }

        public async Task<ValidationResult> Handle(CriarChurrascoCommand request, CancellationToken cancellationToken)
        {
            if (!request.CommandIsValid()) return request.ValidationResult;

            var churrasco = new Churrasco(request.DataHora, request.Descricao, request.Observacao, request.ValorComBebida, request.ValorSemBebida);
            request.AggregateId = churrasco.Id;

            _churrascoRepository.Add(churrasco);

            var result = await PersistirDados(_churrascoRepository.UnitOfWork);

            return result;
        }
    }
}
