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
            return await _context.Clientes.Include(c => c.Pessoa).ThenInclude(p => p.Endereco).ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.Include(c => c.Pessoa).ThenInclude(p => p.Endereco).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente?> GetByEmailAsync(string email)
        {
            return await _context.Clientes
                                 .Include(c => c.Pessoa)
                                 .ThenInclude(p => p.Endereco)
                                 .FirstOrDefaultAsync(c => c.Pessoa != null && c.Pessoa.Email == email);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            // Removendo a lógica de transação e geração de ID aqui, conforme a nova solicitação do usuário.
            // A geração de ID deve ser tratada no nível do modelo ou DTO, ou pelo banco de dados.
            // Para este exemplo, vamos assumir que os IDs são gerados antes de chegar ao serviço ou pelo EF Core.

            // Verificar se já existe um cliente com o mesmo e-mail
            if (cliente.Pessoa != null && !string.IsNullOrEmpty(cliente.Pessoa.Email))
            {
                var existingCliente = await _context.Clientes.Include(c => c.Pessoa).FirstOrDefaultAsync(c => c.Pessoa != null && c.Pessoa.Email == cliente.Pessoa.Email);
                if (existingCliente != null)
                {
                    throw new ArgumentException("Já existe um cliente cadastrado com este e-mail.");
                }
            }

            cliente.Id = Guid.NewGuid(); // Gerar ID para o Cliente
            if (cliente.Pessoa != null)
            {
                cliente.Pessoa.Id = Guid.NewGuid(); // Gerar ID para a Pessoa
                if (cliente.Pessoa.Endereco != null)
                {
                    cliente.Pessoa.Endereco.Id = Guid.NewGuid(); // Gerar ID para o Endereco
                }
            }

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
