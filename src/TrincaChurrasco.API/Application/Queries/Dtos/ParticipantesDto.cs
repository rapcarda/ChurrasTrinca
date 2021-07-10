using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrincaChurrasco.API.Application.Queries.Dtos
{
    public class ParticipantesDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
