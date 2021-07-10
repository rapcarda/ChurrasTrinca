using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Base;

namespace TrincaChurrasco.API.Mediatr
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;

        public MediatrHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> EnviarComando<T>(T comando) where T : CommandBase
        {
            return await _mediator.Send(comando);
        }
    }
}
