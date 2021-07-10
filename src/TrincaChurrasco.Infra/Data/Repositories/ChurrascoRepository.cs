using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrincaChurrasco.Domain.Core.Repository;
using TrincaChurrasco.Domain.Dtos;
using TrincaChurrasco.Domain.Interfaces;
using TrincaChurrasco.Domain.Models;

namespace TrincaChurrasco.Infra.Data.Repositories
{
    public class ChurrascoRepository : IChurrascoRepository
    {
        private readonly TrincaChurrascoContext _context;

        public ChurrascoRepository(TrincaChurrascoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(Churrasco churrasco)
        {
            _context.Add(churrasco);
        }

        public void AdicionarParticipante(Participante participante)
        {
            _context.Participantes.Add(participante);
        }

        public void RemoverParticipante(Participante participante)
        {
            _context.Participantes.Remove(participante);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Participante> ObterParticipantePorId(Guid id)
        {
            return await _context.Participantes
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> VerificarParticipanteChurrasco(Guid churrascoId, string nome)
        {
            return await _context.Churrascos
                .Include(p => p.Participantes)
                .AsNoTracking()
                .AnyAsync(c => c.Id == churrascoId && c.Participantes.Any(p => p.Nome.ToUpper() == nome.ToUpper()));
        }

        public async Task<ICollection<Churrasco>> ObterDadosChurrascos()
        {
            return await _context.Churrascos.Include(p => p.Participantes).ToListAsync();
        }

        public async Task<Churrasco> ObterDadosChurrasco(Guid id)
        {
            return await _context.Churrascos.Include(p => p.Participantes).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
