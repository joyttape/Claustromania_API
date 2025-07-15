using Claustromania.Data;
using Claustromania.Models;
using Claustromania.Services;
using Microsoft.EntityFrameworkCore;

namespace Claustromania.Services
{
    public class FuncionarioService
    {
        private readonly ClaustromaniaDbContext _context;
        private readonly PessoaService _pessoaService;



        public FuncionarioService(ClaustromaniaDbContext context, PessoaService pessoaService)
        {
            _context = context;
            _pessoaService = pessoaService;

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

        public async Task<bool> UpdateAsync(Funcionario funcionarioAtualizado)
        {
            var funcionarioExistente = await _context.Funcionarios
                .Include(f => f.Pessoa)
                    .ThenInclude(p => p.Endereco)
                .FirstOrDefaultAsync(f => f.Id == funcionarioAtualizado.Id);

            if (funcionarioExistente == null)
                return false;

            _context.Entry(funcionarioExistente).CurrentValues.SetValues(new
            {
                funcionarioAtualizado.Turno,
                funcionarioAtualizado.Salario,
                funcionarioAtualizado.Cargo,
                funcionarioAtualizado.DataContratacao,
                funcionarioAtualizado.Status,
                funcionarioAtualizado.Senha
            });

            if (funcionarioAtualizado.Pessoa != null)
            {
                if (funcionarioExistente.Pessoa == null)
                {

                    funcionarioAtualizado.Pessoa.Id = Guid.NewGuid();
                    _context.Pessoas.Add(funcionarioAtualizado.Pessoa);
                    funcionarioExistente.Pessoa = funcionarioAtualizado.Pessoa;
                }
                else
                {
                    _context.Entry(funcionarioExistente.Pessoa).CurrentValues.SetValues(new
                    {
                        funcionarioAtualizado.Pessoa.Nome,
                        funcionarioAtualizado.Pessoa.CPF,
                        funcionarioAtualizado.Pessoa.DataNascimento,
                        funcionarioAtualizado.Pessoa.Sexo,
                        funcionarioAtualizado.Pessoa.Email
                    });

                    if (funcionarioAtualizado.Pessoa.Endereco != null)
                    {
                        if (funcionarioExistente.Pessoa.Endereco == null)
                        {
                            funcionarioAtualizado.Pessoa.Endereco.Id = Guid.NewGuid(); 
                            _context.Entry(funcionarioExistente.Pessoa).CurrentValues.SetValues(new { Endereco = funcionarioAtualizado.Pessoa.Endereco });
                        }
                        else
                        {
                            _context.Entry(funcionarioExistente.Pessoa.Endereco).CurrentValues.SetValues(new
                            {
                                funcionarioAtualizado.Pessoa.Endereco.Logradouro,
                                funcionarioAtualizado.Pessoa.Endereco.Numero,
                                funcionarioAtualizado.Pessoa.Endereco.Complemento,
                                funcionarioAtualizado.Pessoa.Endereco.Bairro,
                                funcionarioAtualizado.Pessoa.Endereco.Cidade,
                                funcionarioAtualizado.Pessoa.Endereco.Estado,
                                funcionarioAtualizado.Pessoa.Endereco.CEP
                            });
                        }
                    }
                    else if (funcionarioExistente.Pessoa.Endereco != null)
                    {
                        _context.Entry(funcionarioExistente.Pessoa.Endereco).State = EntityState.Deleted;
                        funcionarioExistente.Pessoa.Endereco = null;
                    }
                }
            }
            else if (funcionarioExistente.Pessoa != null)
            {
                _context.Entry(funcionarioExistente.Pessoa).State = EntityState.Deleted;
                funcionarioExistente.Pessoa = null;
            }

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("ERRO AO SALVAR FUNCIONARIO: " + ex.InnerException?.Message);
                return false;
            }
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
            var funcionario = await _context.Funcionarios
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            if (funcionario == null)
                return false;

            Guid pessoaId = funcionario.FkPessoa;

            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            await _pessoaService.Delete(pessoaId); 

            return true;
        }

    }
}
