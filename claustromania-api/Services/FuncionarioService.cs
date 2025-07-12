using Claustromania.Data;
using Claustromania.Models;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class FuncionarioService
    {
        private readonly ClaustromaniaDbContext _context;

        public FuncionarioService(ClaustromaniaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Funcionario>> GetAllAsync()
        {
            return await _context.Funcionarios.Include(f => f.Pessoa).ThenInclude(p => p.Endereco).ToListAsync();
        }

        public async Task<Funcionario?> GetByIdAsync(Guid id)
        {
            return await _context.Funcionarios.Include(f => f.Pessoa).ThenInclude(p => p.Endereco).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Funcionario> CreateAsync(Funcionario funcionario)
        {
            if (await _context.Pessoas.AnyAsync(p => p.CPF == funcionario.Pessoa.CPF))
            {
                throw new Exception("CPF já cadastrado.");
            }

            funcionario.Id = Guid.NewGuid();
            _context.Funcionarios.Add(funcionario);
            await _context.SaveChangesAsync();
            return funcionario;
        }

        public async Task<bool> UpdateAsync(Funcionario funcionario)
        {
            var existing = await _context.Funcionarios.FindAsync(funcionario.Id);
            if (existing == null) return false;

            _context.Entry(existing).CurrentValues.SetValues(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Funcionario>> GetByNomeAsync(string nome)
        {
            return await _context.Funcionarios
                                 .Include(f => f.Pessoa)
                                 .ThenInclude(p => p.Endereco)
                                 .Where(f => f.Pessoa != null && f.Pessoa.Nome.Contains(nome))
                                 .ToListAsync();
        }

        public async Task<Funcionario?> GetByEmailAsync(string email)
        {
            return await _context.Funcionarios
                                 .Include(f => f.Pessoa)
                                 .ThenInclude(p => p.Endereco)
                                 .FirstOrDefaultAsync(f => f.Pessoa != null && f.Pessoa.Email == email);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null) return false;

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


