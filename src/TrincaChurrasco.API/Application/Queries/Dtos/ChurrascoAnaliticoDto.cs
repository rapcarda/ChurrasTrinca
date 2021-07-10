using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrincaChurrasco.Domain.Models;

namespace TrincaChurrasco.API.Application.Queries.Dtos
{
    public class ChurrascoAnaliticoDto
    {
        public ChurrascoResumoDto Resumo { get; set; }
        public IReadOnlyCollection<ParticipantesDto> Participantes { get; set; }
    }
}
