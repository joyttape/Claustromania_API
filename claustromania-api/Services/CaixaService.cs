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
            return await _context.Caixas
                                 .Include(c => c.Funcionario)
                                    .ThenInclude(f => f.Pessoa)
                                        .ThenInclude(e => e.Endereco)
                                 .Include(c => c.Unidade)
                                 .ThenInclude(u => u.Endereco) 

                                 .ToListAsync();
        }

        public async Task<Caixa?> GetByIdAsync(Guid id)
        {
            return await _context.Caixas
                .Include(c => c.Funcionario)
                .ThenInclude(f => f.Pessoa)
                .Include(c => c.Unidade)
                .ThenInclude(u => u.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Caixa> CreateAsync(Caixa caixa)
        {
            caixa.Id = Guid.NewGuid();

            // =========================
            // 🔍 Verificar/Salvar Pessoa
            // =========================
            var pessoa = caixa.Funcionario.Pessoa;
            var pessoaExistente = await _context.Pessoas
                .FirstOrDefaultAsync(p => p.CPF == pessoa.CPF);

            if (pessoaExistente != null)
            {
                caixa.Funcionario.FkPessoa = pessoaExistente.Id;
                caixa.Funcionario.Pessoa = null; // Evita conflito
            }
            else
            {
                pessoa.Id = Guid.NewGuid();
                pessoa.Endereco.Id = Guid.NewGuid();
                _context.Pessoas.Add(pessoa);
                await _context.SaveChangesAsync(); // Salva Pessoa + Endereco
                caixa.Funcionario.FkPessoa = pessoa.Id;
            }

            // =============================
            // 👨‍💼 Verificar/Salvar Funcionario
            // =============================
            var funcionario = caixa.Funcionario;
            var funcionarioExistente = await _context.Funcionarios
                .FirstOrDefaultAsync(f => f.FkPessoa == funcionario.FkPessoa);

            if (funcionarioExistente != null)
            {
                caixa.FkFuncionario = funcionarioExistente.Id;
                caixa.Funcionario = null; // Evita conflito
            }
            else
            {
                funcionario.Id = Guid.NewGuid();
                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();
                caixa.FkFuncionario = funcionario.Id;
            }

            // ======================
            // 🏢 Verificar Unidade
            // ======================
            var unidade = caixa.Unidade;
            var unidadeExistente = await _context.Unidades
                .FirstOrDefaultAsync(u =>
                    u.Nome == unidade.Nome &&
                    u.Telefone == unidade.Telefone);

            if (unidadeExistente != null)
            {
                caixa.FkUnidade = unidadeExistente.Id;
                caixa.Unidade = null;
            }
            else
            {
                unidade.Id = Guid.NewGuid();
                _context.Unidades.Add(unidade);
                await _context.SaveChangesAsync();
                caixa.FkUnidade = unidade.Id;
            }

            // =====================
            // 💾 Salvar o Caixa
            // =====================
            _context.Caixas.Add(caixa);
            await _context.SaveChangesAsync();

            return caixa;
        }


        public async Task<bool> UpdateAsync(Caixa caixa)
        {
            var existing = await _context.Caixas
                .Include(c => c.Funcionario).ThenInclude(f => f.Pessoa).ThenInclude(p => p.Endereco)
                .Include(c => c.Unidade).ThenInclude(u => u.Endereco)
                .FirstOrDefaultAsync(c => c.Id == caixa.Id);

            if (existing == null)
                return false;

            // Pessoa
            var pessoa = caixa.Funcionario?.Pessoa;
            if (pessoa != null)
            {
                var pessoaExistente = await _context.Pessoas.FirstOrDefaultAsync(p => p.CPF == pessoa.CPF);
                if (pessoaExistente == null)
                {
                    pessoa.Id = Guid.NewGuid();
                    pessoa.Endereco.Id = Guid.NewGuid();
                    _context.Pessoas.Add(pessoa);
                    await _context.SaveChangesAsync();
                    caixa.Funcionario.FkPessoa = pessoa.Id;
                }
                else
                {
                    caixa.Funcionario.FkPessoa = pessoaExistente.Id;
                    caixa.Funcionario.Pessoa = null;
                }
            }

            // Funcionario
            var funcionario = caixa.Funcionario;
            if (funcionario != null)
            {
                var funcionarioExistente = await _context.Funcionarios
                    .FirstOrDefaultAsync(f => f.FkPessoa == funcionario.FkPessoa);

                if (funcionarioExistente == null)
                {
                    funcionario.Id = Guid.NewGuid();
                    _context.Funcionarios.Add(funcionario);
                    await _context.SaveChangesAsync();
                    caixa.FkFuncionario = funcionario.Id;
                }
                else
                {
                    caixa.FkFuncionario = funcionarioExistente.Id;
                    caixa.Funcionario = null;
                }
            }

            // Unidade
            var unidade = caixa.Unidade;
            if (unidade != null)
            {
                var unidadeExistente = await _context.Unidades
                    .FirstOrDefaultAsync(u => u.Nome == unidade.Nome && u.Telefone == unidade.Telefone);

                if (unidadeExistente == null)
                {
                    unidade.Id = Guid.NewGuid();
                    unidade.Endereco.Id = Guid.NewGuid();
                    _context.Unidades.Add(unidade);
                    await _context.SaveChangesAsync();
                    caixa.FkUnidade = unidade.Id;
                }
                else
                {
                    caixa.FkUnidade = unidadeExistente.Id;
                    caixa.Unidade = null;
                }
            }

            // Atualiza os campos do Caixa
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
                                        .ThenInclude(e => e.Endereco)
                                 .Include(c => c.Unidade)
                                 .ThenInclude(u => u.Endereco) // <-- Adicionado

                                 .ToListAsync();
        }

    }
}
