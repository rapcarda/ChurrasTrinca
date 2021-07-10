using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Queries.Dtos;
using TrincaChurrasco.API.Enums;
using TrincaChurrasco.Domain.Interfaces;
using TrincaChurrasco.Domain.Models;

namespace TrincaChurrasco.API.Application.Queries.DetalhesChurrasco
{
    public class DetalhesChurrascoQueries : IDetalhesChurrascoQueries
    {
        private readonly IChurrascoRepository _churrascoRespository;

        public DetalhesChurrascoQueries(IChurrascoRepository churrascoRespository)
        {
            _churrascoRespository = churrascoRespository;
        }

        public async Task<ChurrascoAnaliticoDto> ObterDadosAnaliticoChurrasco(Guid id)
        {
            var churrasco = await _churrascoRespository.ObterDadosChurrasco(id);

            if (churrasco == null)
            {
                return null;
            }

            var participantes = churrasco.Participantes.Select(p => new ParticipantesDto()
            {
                Id = p.Id,
                Nome = p.Nome,
                Valor = p.Valor
            });

            var analitico = new ChurrascoAnaliticoDto()
            {
                Resumo = CriarResumoDto(churrasco),
                Participantes = participantes.ToList()
            };

            return analitico;
        }

        public async Task<ICollection<ChurrascoResumoDto>> ObterResumoChurrasco(TipoPesquisa type)
        {
            var churrascos = await _churrascoRespository.ObterDadosChurrascos();

            var agrupado = churrascos.Select(c => CriarResumoDto(c));

            if (type == TipoPesquisa.Proximos)
            {
                return agrupado.Where(a => a.DataHora >= DateTime.Now).ToList();
            }
            else if (type == TipoPesquisa.Passados)
            {
                return agrupado.Where(a => a.DataHora <= DateTime.Now).ToList();
            }

            return agrupado.ToList();
        }

        private ChurrascoResumoDto CriarResumoDto(Churrasco churrasco)
        {
            return new ChurrascoResumoDto()
            {
                Id = churrasco.Id,
                DataHora = churrasco.DataHora,
                Descricao = churrasco.Descricao,
                QtdParticipantes = churrasco.Participantes.Count(),
                TotalArrecadado = churrasco.Participantes.Sum(p => p.Valor)
            };
        }
    }
}
