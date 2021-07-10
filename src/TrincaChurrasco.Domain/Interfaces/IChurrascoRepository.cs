using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrincaChurrasco.Domain.Core.Repository;
using TrincaChurrasco.Domain.Models;

namespace TrincaChurrasco.Domain.Interfaces
{
    public interface IChurrascoRepository : IRepository<Churrasco>
    {
        void Add(Churrasco churrasco);
        void AdicionarParticipante(Participante participante);
        void RemoverParticipante(Participante participante);

        Task<ICollection<Churrasco>> ObterDadosChurrascos();
        Task<Churrasco> ObterDadosChurrasco(Guid id);
        Task<Participante> ObterParticipantePorId(Guid id);
        Task<bool> VerificarParticipanteChurrasco(Guid churrascoId, string nome);
    }
}
