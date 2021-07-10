using System;
using TrincaChurrasco.Domain.Core;

namespace TrincaChurrasco.Domain.Models
{
    public class Participante : EntityBase
    {
        public Guid ChurrascoId { get; private set; }
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }
        public Churrasco Churrasco { get; set; }

        public Participante()
        {
        }

        public Participante(Guid churrascoId, string nome, decimal valor)
        {
            ChurrascoId = churrascoId;
            Nome = nome;
            Valor = valor;
        }
    }
}
