using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class SalaService
    {
        private readonly ClaustromaniaDbContext _context;

        public SalaService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sala>> GetAllAsync()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala?> GetByIdAsync(Guid id)
        {
            return await _context.Salas.FindAsync(id);
        }

        public async Task<Sala> CreateAsync(Sala sala)
        {
            sala.Id = Guid.NewGuid();
            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();
            return sala;
        }

        public async Task<bool> UpdateAsync(Sala sala)
        {
            var existing = await _context.Salas.FindAsync(sala.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(sala);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null) return false;

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
