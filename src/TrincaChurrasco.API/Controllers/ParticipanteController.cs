using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Commands.AdicionarParticipante;
using TrincaChurrasco.API.Application.Commands.RemoverParticipante;
using TrincaChurrasco.API.Mediatr;
using TrincaChurrasco.API.ViewModels;

namespace TrincaChurrasco.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ParticipanteController : ControllerBase
    {
        private readonly IMediatrHandler _mediatrHandler;

        public ParticipanteController(IMediatrHandler mediatrHandler)
        {
            _mediatrHandler = mediatrHandler;
        }

        [HttpPost("adicionar-participante")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> AdicionarParticipante(ParticipanteViewModel participante)
        {
            var command = new AdicionarParticipanteCommand(participante.ChurrascoId, participante.Nome, participante.Valor);
            var result = await _mediatrHandler.EnviarComando(command);

            if (!result.IsValid) return CustomResponse(result);

            var response = new AdicionarParticipanteResponse(command.AggregateId, command.ChurrascoId, command.Nome, command.Valor);
            return Created(string.Empty, response);
        }

        [HttpDelete("remover-participante/{id:guid}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<IActionResult> RemoverParticipante(Guid id)
        {
            var command = new RemoverParticipanteCommand(id);
            var result = await _mediatrHandler.EnviarComando(command);

            if (!result.IsValid) return CustomResponse(result);

            return CustomResponse();
        }
    }
}
