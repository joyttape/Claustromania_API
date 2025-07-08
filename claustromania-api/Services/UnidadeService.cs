using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class UnidadeService
    {
        private readonly ClaustromaniaDbContext _context;

        public UnidadeService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Unidade>> GetAllAsync()
        {
            return await _context.Unidades.ToListAsync();
        }

        public async Task<Unidade?> GetByIdAsync(Guid id)
        {
            return await _context.Unidades.FindAsync(id);
        }

        public async Task<Unidade> CreateAsync(Unidade unidade)
        {
            unidade.Id = Guid.NewGuid();
            _context.Unidades.Add(unidade);
            await _context.SaveChangesAsync();
            return unidade;
        }

        public async Task<bool> UpdateAsync(Unidade unidade)
        {
            var existing = await _context.Unidades.FindAsync(unidade.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(unidade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var unidade = await _context.Unidades.FindAsync(id);
            if (unidade == null) return false;

            _context.Unidades.Remove(unidade);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
