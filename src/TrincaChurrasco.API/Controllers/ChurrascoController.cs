using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Commands.CriarChurrasco;
using TrincaChurrasco.API.Application.Queries.DetalhesChurrasco;
using TrincaChurrasco.API.Enums;
using TrincaChurrasco.API.Mediatr;
using TrincaChurrasco.API.ViewModels;

namespace TrincaChurrasco.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class ChurrascoController : ControllerBase
    {
        private readonly IMediatrHandler _mediatrHandler;
        private readonly IDetalhesChurrascoQueries _detalhesChurrascoQueries;

        public ChurrascoController(IMediatrHandler mediatrHandler, IDetalhesChurrascoQueries detalhesChurrascoQueries)
        {
            _mediatrHandler = mediatrHandler;
            _detalhesChurrascoQueries = detalhesChurrascoQueries;
        }

        [HttpGet("resumo/{type}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> ObterResumoChurrascos(TipoPesquisa type)
        {
            var resumo = await _detalhesChurrascoQueries.ObterResumoChurrasco(type);

            return resumo == null ? NotFound() : CustomResponse(resumo);
        }

        [HttpGet("analitico")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<IActionResult> ObterAnaliticoChurrasco(Guid id)
        {
            var resumo = await _detalhesChurrascoQueries.ObterDadosAnaliticoChurrasco(id);

            return resumo == null ? NotFound() : CustomResponse(resumo);
        }

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> CriarChurrasco([FromBody] ChurrascoViewModel churrasco)
        {
            var command = new CriarChurrascoCommand(churrasco.DataHora, churrasco.Descricao, churrasco.Observacao, churrasco.ValorComBebida, churrasco.ValorSemBebida);
            var result = await _mediatrHandler.EnviarComando(command);

            if (!result.IsValid) return CustomResponse(result);

            var response = new CriarChurrascoResponse(command.AggregateId, command.DataHora, command.Descricao, command.Observacao, command.ValorComBebida, command.ValorSemBebida);

            return Created(string.Empty, response);
        }

    }
}
