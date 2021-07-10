using System;
using System.Collections.Generic;
using System.Linq;
using TrincaChurrasco.Domain.Core;
using TrincaChurrasco.Domain.Exceptions;

namespace TrincaChurrasco.Domain.Models
{
    public class Churrasco : EntityBase, IAggregateRoot
    {
        public DateTime DataHora { get; private set; }
        public string Descricao { get; private set; }
        public string Observacao { get; private set; }
        public decimal ValorComBebida { get; private set; }
        public decimal ValorSemBebida { get; private set; }

        private readonly List<Participante> _participantes;

        public IReadOnlyCollection<Participante> Participantes => _participantes;

        public Churrasco()
        {
            _participantes = new List<Participante>();
        }

        public Churrasco(DateTime dataHora, string descricao, string observacao, decimal valorComBebida, decimal valorSemBebida)
        {
            DataHora = dataHora;
            Descricao = descricao;
            Observacao = observacao;
            ValorComBebida = valorComBebida;
            ValorSemBebida = valorSemBebida;
            _participantes = new List<Participante>();
        }

        public void AdicionarParticipante(Participante participante)
        {
            if (participante != null)
            {
                if (_participantes.Any(p => p.Id == participante.Id))
                {
                    throw new DomainException("Participante já vinculado ao churrasco");
                }

                _participantes.Add(participante);
            }
        }

        public void RemoverParticipante(Participante participante)
        {
            if (participante != null)
            {
                _participantes.Remove(participante);
            }
        }
    }
}
