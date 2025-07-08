using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class CaixaService
    {
        private readonly ClaustromaniaDbContext _context;



        public CaixaService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Caixa>> GetAllAsync()
        {
            return await _context.Caixas.ToListAsync();
        }

        public async Task<Caixa?> GetByIdAsync(Guid id)
        {
            return await _context.Caixas.FindAsync(id);
        }

        public async Task<Caixa> CreateAsync(Caixa caixa)
        {
            caixa.Id = Guid.NewGuid();
            _context.Caixas.Add(caixa);
            await _context.SaveChangesAsync();
            return caixa;
        }

        public async Task<bool> UpdateAsync(Caixa caixa)
        {
            var existing = await _context.Caixas.FindAsync(caixa.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(caixa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var caixa = await _context.Caixas.FindAsync(id);
            if (caixa == null) return false;

            _context.Caixas.Remove(caixa);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Caixa>> GetAllDetalhadoAsync()
        {
            return await _context.Caixas
                                 .Include(c => c.Funcionario)
                                  .ThenInclude(f => f.Pessoa)
                                 .Include(c => c.Unidade)
                                 .ThenInclude(u => u.Endereco) // <-- Adicionado

                                 .ToListAsync();
        }

    }


}