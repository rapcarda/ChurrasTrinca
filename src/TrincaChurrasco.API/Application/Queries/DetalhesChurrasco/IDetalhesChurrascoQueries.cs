using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrincaChurrasco.API.Application.Queries.Dtos;
using TrincaChurrasco.API.Enums;

namespace TrincaChurrasco.API.Application.Queries.DetalhesChurrasco
{
    public interface IDetalhesChurrascoQueries
    {
        Task<ICollection<ChurrascoResumoDto>> ObterResumoChurrasco(TipoPesquisa type);

        Task<ChurrascoAnaliticoDto> ObterDadosAnaliticoChurrasco(Guid id);
    }
}
