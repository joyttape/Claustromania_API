using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class ClienteService
    {

        private readonly ClaustromaniaDbContext _context;

        public ClienteService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            var existing = await _context.Clientes.FindAsync(cliente.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<IEnumerable<Cliente>> GetAllDetalhadoAsync()
        {
            return await _context.Clientes
                                 .Include(c => c.Pessoa) // <-- Inclui a Pessoa
                                 .ToListAsync();
        }

        public async Task<Cliente?> GetByIdDetalhadoAsync(Guid id)
        {
            return await _context.Clientes
                                 .Include(c => c.Pessoa) // <-- Inclui a Pessoa
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }



}
