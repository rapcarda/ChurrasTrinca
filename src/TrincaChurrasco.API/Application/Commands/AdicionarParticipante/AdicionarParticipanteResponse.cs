using System;

namespace TrincaChurrasco.API.Application.Commands.AdicionarParticipante
{
    public class AdicionarParticipanteResponse
    {
        public Guid Id { get; set; }
        public Guid ChurrascoId { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        public AdicionarParticipanteResponse(Guid id, Guid churrascoId, string nome, decimal valor)
        {
            Id = id;
            ChurrascoId = churrascoId;
            Nome = nome;
            Valor = valor;
        }
    }
}
