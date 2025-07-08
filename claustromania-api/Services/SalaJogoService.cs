using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class SalaJogoService
    {
        private readonly ClaustromaniaDbContext _context;

        public SalaJogoService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<SalaJogo>> GetAllAsync()
        {
            return await _context.SalaJogos.ToListAsync();
        }

        public async Task<SalaJogo?> GetByIdAsync(Guid id)
        {
            return await _context.SalaJogos.FindAsync(id);
        }

        public async Task<SalaJogo> CreateAsync(SalaJogo entity)
        {
            entity.Id = Guid.NewGuid();
            _context.SalaJogos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateAsync(SalaJogo entity)
        {
            var existing = await _context.SalaJogos.FindAsync(entity.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.SalaJogos.FindAsync(id);
            if (entity == null) return false;

            _context.SalaJogos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
