
using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class EnderecoService
    {
        private readonly ClaustromaniaDbContext _context;

        public EnderecoService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Endereco>> GetAllAsync()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco?> GetByIdAsync(Guid id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<Endereco> CreateAsync(Endereco endereco)
        {
            endereco.Id = Guid.NewGuid();
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<bool> UpdateAsync(Endereco endereco)
        {
            var existing = await _context.Enderecos.FindAsync(endereco.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(endereco);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null) return false;

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<Endereco?> GetByIdDetalhadoAsync(Guid id)
        {
            return await _context.Enderecos
                                 .Include(e => e.Pessoas) // <-- Inclui a coleção de Pessoas
                                 .FirstOrDefaultAsync(e => e.Id == id);


        }
    }
}
