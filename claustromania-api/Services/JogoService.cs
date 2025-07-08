using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class JogoService
    {
        private readonly ClaustromaniaDbContext _context;

        public JogoService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Jogo>> GetAllAsync()
        {
            return await _context.Jogos.ToListAsync();
        }

        public async Task<Jogo?> GetByIdAsync(Guid id)
        {
            return await _context.Jogos.FindAsync(id);
        }

        public async Task<Jogo> CreateAsync(Jogo jogo)
        {
            jogo.Id = Guid.NewGuid();
            _context.Jogos.Add(jogo);
            await _context.SaveChangesAsync();
            return jogo;
        }

        public async Task<bool> UpdateAsync(Jogo jogo)
        {
            var existing = await _context.Jogos.FindAsync(jogo.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(jogo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var jogo = await _context.Jogos.FindAsync(id);
            if (jogo == null) return false;

            _context.Jogos.Remove(jogo);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
