using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class TransacaoService
    {
        private readonly ClaustromaniaDbContext _context;

        public TransacaoService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transacao>> GetAllAsync()
        {
            return await _context.Transacoes.ToListAsync();
        }

        public async Task<Transacao?> GetByIdAsync(Guid id)
        {
            return await _context.Transacoes.FindAsync(id);
        }

        public async Task<Transacao> CreateAsync(Transacao transacao)
        {
            transacao.Id = Guid.NewGuid();
            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();
            return transacao;
        }

        public async Task<bool> UpdateAsync(Transacao transacao)
        {
            var existing = await _context.Transacoes.FindAsync(transacao.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(transacao);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var transacao = await _context.Transacoes.FindAsync(id);
            if (transacao == null) return false;

            _context.Transacoes.Remove(transacao);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
