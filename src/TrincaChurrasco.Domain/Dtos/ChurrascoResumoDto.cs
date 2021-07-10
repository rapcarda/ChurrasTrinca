using System;

namespace TrincaChurrasco.Domain.Dtos
{
    public class ChurrascoResumoDto
    {
        public Guid Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }
        public int QtdParticipantes { get; set; }
        public decimal TotalArrecadado { get; set; }
    }
}
